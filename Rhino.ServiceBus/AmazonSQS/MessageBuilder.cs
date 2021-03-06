﻿using System;
using System.Collections.Specialized;
using System.IO;
using Rhino.Queues;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Messages;
using Rhino.ServiceBus.Transport;

namespace Rhino.ServiceBus.AmazonSQS
{
	public class SQSMessageBuilder : IMessageBuilder<MessagePayload>
	{
		private readonly IMessageSerializer messageSerializer;
		private Endpoint endpoint;
		public SQSMessageBuilder(IMessageSerializer messageSerializer)
		{
			this.messageSerializer = messageSerializer;
		}

		public event Action<MessagePayload> MessageBuilt;

		[CLSCompliant(false)]
		public MessagePayload BuildFromMessageBatch(params object[] msgs)
		{
			if (endpoint == null)
				throw new InvalidOperationException("A source endpoint is required for Amazon SQS transport, did you Initialize me? try providing a null Uri.");

			var messageId = Guid.NewGuid();
			byte[] data = new byte[0];
			using (var memoryStream = new MemoryStream())
			{
				messageSerializer.Serialize(msgs, memoryStream);
				data = memoryStream.ToArray();
                // JED - TODO
                // encode in valid characters
			}
			var payload = new MessagePayload
			{
				Data = data,
				Headers =
                        {
                            {"id", messageId.ToString()},
                            {"type", GetAppSpecificMarker(msgs).ToString()},
                            {"source", endpoint.Uri.ToString()},
                        }
			};

            // JED - TODO
            // throw if over max size for SQS
        	var copy = MessageBuilt;
			if (copy != null)
				copy(payload);

			return payload;
		}

		public void Initialize(Endpoint source)
		{
			endpoint = source;
		}



		private static MessageType GetAppSpecificMarker(object[] msgs)
		{
			var msg = msgs[0];
			if (msg is AdministrativeMessage)
				return MessageType.AdministrativeMessageMarker;
			if (msg is LoadBalancerMessage)
				return MessageType.LoadBalancerMessageMarker;
			return 0;
		}
	}
}