using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Transactions;
using System.Xml;
using log4net;
using Microsoft.Isam.Esent.Interop;
using Rhino.Queues;
using Rhino.Queues.Model;
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Transport;
using Rhino.ServiceBus.Util;
using Transaction = System.Transactions.Transaction;

namespace Rhino.ServiceBus.AmazonSQS
{
	public class SQSTransport : ITransport
	{
		void ITransport.Start()
		{
			throw new NotImplementedException();
		}

		Endpoint ITransport.Endpoint
		{
			get { throw new NotImplementedException(); }
		}

		int ITransport.ThreadCount
		{
			get { throw new NotImplementedException(); }
		}

		CurrentMessageInformation ITransport.CurrentMessageInformation
		{
			get { throw new NotImplementedException(); }
		}

		void ITransport.Send(Endpoint destination, object[] msgs)
		{
			throw new NotImplementedException();
		}

		void ITransport.Send(Endpoint endpoint, DateTime processAgainAt, object[] msgs)
		{
			throw new NotImplementedException();
		}

		void ITransport.Reply(params object[] messages)
		{
			throw new NotImplementedException();
		}

		event Action<CurrentMessageInformation> ITransport.MessageSent
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Func<CurrentMessageInformation, bool> ITransport.AdministrativeMessageArrived
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Func<CurrentMessageInformation, bool> ITransport.MessageArrived
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Action<CurrentMessageInformation, Exception> ITransport.MessageSerializationException
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Action<CurrentMessageInformation, Exception> ITransport.MessageProcessingFailure
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Action<CurrentMessageInformation, Exception> ITransport.MessageProcessingCompleted
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Action<CurrentMessageInformation> ITransport.BeforeMessageTransactionCommit
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Action<CurrentMessageInformation, Exception> ITransport.AdministrativeMessageProcessingCompleted
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		event Action ITransport.Started
		{
			add { throw new NotImplementedException(); }
			remove { throw new NotImplementedException(); }
		}

		void IDisposable.Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
