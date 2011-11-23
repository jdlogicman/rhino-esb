using System;
using System.Configuration;
using Rhino.ServiceBus.Impl;

namespace Rhino.ServiceBus.Config
{
	public class SQSConfigurationAware : IBusConfigurationAware
	{
		public void Configure(AbstractRhinoServiceBusConfiguration configuration, IBusContainerBuilder builder)
		{
			var busConfig = configuration as RhinoServiceBusConfiguration;
			if (busConfig == null)
				return;

			if (configuration.Endpoint.Scheme.Equals("amazon.sqs", StringComparison.InvariantCultureIgnoreCase) ==
				false)
				return;

			var busConfigSection = configuration.ConfigurationSection.Bus;

			builder.RegisterAmazonSQSTransport();
		}
	}
}