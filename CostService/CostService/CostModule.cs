using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace CostService
{
	public class CostModule : NancyModule
	{
		private readonly ICartRepository _cartRepository;
		private readonly IShippingInventoryRepository _shippingInventoryRepository;

		public CostModule(ICartRepository cartRepository, IShippingInventoryRepository shippingInventoryRepository)
		{
			_cartRepository = cartRepository;
			_shippingInventoryRepository = shippingInventoryRepository;

			Get["/"] = x => "TEST";
			Get["/cache"] = x => "";

			CachingHelper.CacheShippingItems(_shippingInventoryRepository);

			//shippingInventoryRepository.GetItem(1);
		}
	}
}