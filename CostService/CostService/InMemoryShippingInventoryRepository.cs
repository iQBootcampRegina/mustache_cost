using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class InMemoryShippingInventoryRepository : IShippingInventoryRepository
	{
		private readonly Dictionary<int, ShippingInventoryItem> _products;

		public InMemoryShippingInventoryRepository()
		{
			_products = new Dictionary<int, ShippingInventoryItem>();
		}

		public ShippingInventoryItem CacheItem(int productId, decimal weight, decimal width, decimal length, decimal depth)
		{
			throw new NotImplementedException();
		}

		public ShippingInventoryItem GetItem(int productId)
		{
			return _products[productId] ?? GetItemFromInventoryService(productId);
		}

		private ShippingInventoryItem GetItemFromInventoryService(int productId)
		{
			//call inventory service and get item;
			var item = new ShippingInventoryItem(){ ProductId = productId };
			_products.Add(productId, item);

			return item;
		}
	}
}