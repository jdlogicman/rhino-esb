using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using Rhino.PersistentHashTable;
using Rhino.ServiceBus.DataStructures;
using Rhino.ServiceBus.Exceptions;
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.MessageModules;
using Rhino.ServiceBus.Messages;
using Rhino.ServiceBus.Transport;

namespace Rhino.ServiceBus.AmazonSQS
{
	public class SQSSubscriptionStorage : ISubscriptionStorage, IDisposable, IMessageModule
	{
		public void Initialize()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Uri> GetSubscriptionsFor(Type type)
		{
			throw new NotImplementedException();
		}

		public void AddLocalInstanceSubscription(IMessageConsumer consumer)
		{
			throw new NotImplementedException();
		}

		public void RemoveLocalInstanceSubscription(IMessageConsumer consumer)
		{
			throw new NotImplementedException();
		}

		public object[] GetInstanceSubscriptions(Type type)
		{
			throw new NotImplementedException();
		}

		public bool AddSubscription(string type, string endpoint)
		{
			throw new NotImplementedException();
		}

		public void RemoveSubscription(string type, string endpoint)
		{
			throw new NotImplementedException();
		}

		public void Init(ITransport transport, IServiceBus bus)
		{
			throw new NotImplementedException();
		}

		public void Stop(ITransport transport, IServiceBus bus)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		event Action ISubscriptionStorage.SubscriptionChanged
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

	}
}
