using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CostService
{
	public static class CachingHelper
	{
		public static void CacheShippingItems(IShippingInventoryRepository repository)
		{
			//call rest API, hydrate repo
			var response = InventoryServiceHelper.GetInventoryClient().Execute(InventoryServiceHelper.RequestProducts());
			var products = JsonConvert.DeserializeObject<List<ShippingInventoryItem>>(response.Content);

			repository.ClearCache();
			products.ForEach(item => repository.CacheItem(item));
		}

		
	}
}