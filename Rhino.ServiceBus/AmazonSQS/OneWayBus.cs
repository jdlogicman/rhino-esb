using System;
using System.Transactions;
using Rhino.Queues;
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;

namespace Rhino.ServiceBus.AmazonSQS
{
	[CLSCompliant(false)]
	public class SQSOneWayBus : SQSTransport, IOnewayBus
	{
		private MessageOwnersSelector messageOwners;
		public SQSOneWayBus(MessageOwner[] messageOwners, IMessageSerializer messageSerializer, string path, bool enablePerformanceCounters, IMessageBuilder<MessagePayload> messageBuilder)
		{
			this.messageOwners = new MessageOwnersSelector(messageOwners, new EndpointRouter());
			(this as ITransport).Start();
		}

		public void Send(params object[] msgs)
		{
			(this as ITransport).Send(messageOwners.GetEndpointForMessageBatch(msgs), msgs);
		}
	}
}
