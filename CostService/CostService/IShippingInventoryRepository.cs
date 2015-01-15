using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostService
{
	interface IShippingInventoryRepository
	{
		ShippingInventoryItem CacheItem(int productId, decimal weight, decimal width, decimal length, decimal depth);
		ShippingInventoryItem GetItem(int productId);
	}
}
