using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostService
{
	public interface IShippingInventoryRepository
	{
		ShippingInventoryItem CacheItem(ShippingInventoryItem item);
		void ClearCache();
		ShippingInventoryItem GetItem(int productId);
	}
}
