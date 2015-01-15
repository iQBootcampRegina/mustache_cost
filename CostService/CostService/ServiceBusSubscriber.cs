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
			servicebusBootstrapper.MessageHandlerRegisterer.Register<SubscriptionMessages.Cart.CartItemUpdatedMessage>(HandleCartItemUpdatedMessage);
			
			servicebusBootstrapper.Subscribe();
		}


		private static void HandleInventoryChangedMessage(InventoryChangedMessage.InventoryChangedMessage message)
		{
			// HACK - I'm sorry :(
			if (InMemoryShippingInventoryRepository.Instance == null) return; // we don't care about messages until the repository is initialized

			bool addItem = false;
			var item = InMemoryShippingInventoryRepository.Instance.GetItemIfExisting(message.Id);
			if (item == null)
			{
				addItem = true;
				item = new ShippingInventoryItem {Id = message.Id, ShippingCharacteristics = new ShippingCharacteristics()};
			}

			item.ListPrice = message.ListPrice;
			item.ShippingCharacteristics.Weight = (decimal)message.Weight;
			item.ShippingCharacteristics.Height = (decimal)message.Height;
			item.ShippingCharacteristics.Depth = (decimal)message.Depth;
			item.ShippingCharacteristics.Width = (decimal)message.Width;

			if (addItem)
				InMemoryShippingInventoryRepository.Instance.CacheItem(item);
		}

		private static void HandleCartItemUpdatedMessage(SubscriptionMessages.Cart.CartItemUpdatedMessage message)
		{
			// HACK - I'm sorry :(
			if (InMemoryCartRepository.Instance == null) return; // we don't care about messages until the repository is initialized

			var cart = InMemoryCartRepository.Instance.GetOrCreateNewCartForCache(message.CartId);
			var prod = cart.Items.FirstOrDefault(x => x.ProductId == message.ProductId);
			if (prod == null)
			{
				prod = new Item {ProductId = message.ProductId};
				cart.Items.Add(prod);
			}
			prod.Qty = message.Quantity;
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