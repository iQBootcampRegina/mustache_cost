using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CostService
{
	public class InMemoryShippingInventoryRepository : IShippingInventoryRepository
	{
		// HACK - I'm sorry :(
		public static InMemoryShippingInventoryRepository Instance { get; private set; }

		private readonly Dictionary<int, ShippingInventoryItem> _products;

		public InMemoryShippingInventoryRepository()
		{
			_products = new Dictionary<int, ShippingInventoryItem>();
			Instance = this;
		}

		public void ClearCache()
		{
			_products.Clear();
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

		public ShippingInventoryItem GetItemIfExisting(int productId)
		{
			ShippingInventoryItem item;
			_products.TryGetValue(productId, out item);
			return item;
		}
	}
}