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
	}
}