using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CostService
{
	public class InMemoryShippingInventoryRepository : IShippingInventoryRepository
	{
		private readonly Dictionary<int, ShippingInventoryItem> _products;

		public InMemoryShippingInventoryRepository()
		{
			_products = new Dictionary<int, ShippingInventoryItem>();
			CachingHelper.CacheShippingItems(this);
		}

		public ShippingInventoryItem CacheItem(ShippingInventoryItem item)
		{
			_products[item.Id] = item;
			return item;
		}

		public ShippingInventoryItem GetItem(int productId)
		{
			return _products.ContainsKey(productId) ? _products[productId] : GetItemFromInventoryService(productId);
		}

		private ShippingInventoryItem GetItemFromInventoryService(int productId)
		{
			//call inventory service and get item;
			var response = InventoryServiceHelper.GetInventoryClient().Execute(InventoryServiceHelper.RequestProduct(productId));
			var item = JsonConvert.DeserializeObject<ShippingInventoryItem>(response.Content);
			_products[item.Id] = item;

			return item;
		}
	}
}