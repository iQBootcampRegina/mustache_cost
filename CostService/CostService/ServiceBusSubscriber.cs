using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Foundation.Messaging.AzureServiceBus;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;

namespace CostService
{
	public class ServiceBusSubscriber
	{
		public static ServiceBusSubscriber Instance { get { return _instance; } }
		private static readonly ServiceBusSubscriber _instance;
		static ServiceBusSubscriber()
		{
			_instance = new ServiceBusSubscriber();
		}
		private ServiceBusSubscriber()
		{
		}

		private bool _subscribed;
		public void Subscribe()
		{
			if (_subscribed)
				return;
			_subscribed = true;

			var servicebusBootstrapper = new DefaultAzureServiceBusBootstrapper(new ServiceBusSubscriberConfiguration());

			// Register handlers
			servicebusBootstrapper.MessageHandlerRegisterer.Register<InventoryChangedMessage.InventoryChangedMessage>(HandleInventoryChangedMessage);
			
			servicebusBootstrapper.Subscribe();
		}


		private static void HandleInventoryChangedMessage(InventoryChangedMessage.InventoryChangedMessage message)
		{
			// TODO
		}
	}

	public class ServiceBusSubscriberConfiguration : ConventionServiceBusConfiguration
	{
		public override string ConnectionString
		{
			get { return "Endpoint=sb://iqbootcamp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DYR29cbRrvBi1ADCztJQ99vlTOyPDVFAtLOgO8yWgN8="; }
		}

		public override string ServiceIdentifier
		{
			get { return "mustache.cost"; }
		}

		protected override IEnumerable<string> SubscriptionTopics
		{
			get
			{
				yield return "beard.inventory";
			}
		}
	}
}