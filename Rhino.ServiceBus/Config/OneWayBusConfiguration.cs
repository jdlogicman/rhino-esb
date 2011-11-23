using System;
using System.Collections.Generic;
using Rhino.ServiceBus.Impl;

namespace Rhino.ServiceBus.Config
{
    public class OneWayBusConfiguration : IBusConfigurationAware
    {
        public void Configure(AbstractRhinoServiceBusConfiguration config, IBusContainerBuilder builder)
        {
            var oneWayConfig = config as OnewayRhinoServiceBusConfiguration;
            if (oneWayConfig == null)
                return;

            var messageOwners = new List<MessageOwner>();
            var messageOwnersReader = new MessageOwnersConfigReader(config.ConfigurationSection, messageOwners);
            messageOwnersReader.ReadMessageOwners();
            oneWayConfig.MessageOwners = messageOwners.ToArray();
			// JED - TODO
			// Bad coupling - extend or rewrite?
			var scheme = messageOwnersReader.EndpointScheme;
            if (IsRhinoQueues(scheme))
            {
                builder.RegisterRhinoQueuesOneWay();
            }
            else if (IsMsmq(scheme))
            {
                builder.RegisterMsmqOneWay();
            }
			else if (IsAmazonSQS(scheme))
			{
				builder.RegisterAmazonSQSOneWay();
			}
			else
			{
				throw new ApplicationException(string.Format("Unknown endpoint scheme '{0}'", scheme));
			}
        }

        private static bool IsRhinoQueues(string endpointScheme)
        {
            return endpointScheme.Equals("rhino.queues", StringComparison.InvariantCultureIgnoreCase);
        }
		private static bool IsAmazonSQS(string endpointScheme)
		{
			return endpointScheme.Equals("amazon.sqs", StringComparison.InvariantCultureIgnoreCase);
		}
		private static bool IsMsmq(string endpointScheme)
		{
			return endpointScheme.Equals("msmq", StringComparison.InvariantCultureIgnoreCase);
		}
    }
}