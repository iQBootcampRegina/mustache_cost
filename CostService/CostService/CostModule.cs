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
			Get["/cache({id})"] = x => _shippingInventoryRepository.GetItem(x.id);
			Get["/cache"] = x => CacheProducts();
		}

		private object CacheProducts()
		{
			CachingHelper.CacheShippingItems(_shippingInventoryRepository);
			return HttpStatusCode.OK;
		}
	}
}