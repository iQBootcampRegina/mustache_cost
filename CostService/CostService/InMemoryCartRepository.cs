using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class InMemoryCartRepository : ICartRepository
	{
		// HACK - I'm sorry :(
		public static InMemoryCartRepository Instance { get; private set; }

		readonly IDictionary<Guid, Cart> _carts;
		private readonly IShippingInventoryRepository _shippingInventoryRepository;

		public InMemoryCartRepository(IShippingInventoryRepository shippingInventoryRepository)
		{
			_carts = new Dictionary<Guid, Cart>();
			_shippingInventoryRepository = shippingInventoryRepository;

			Instance = this;
		}

		/// <summary>
		/// Calculates the cost of the shipment
		/// </summary>
		/// <param name="cartId">The cartId we want to calculate the cost for</param>
		/// <returns>A cart with updated subtotal, shippingCost, and total</returns>
		public Cart GetCost(Guid cartId)
		{
			// get cart and starting values
			var cart = _carts[cartId];
			decimal subTotal = 0;
			decimal weight = 0;
			
			// sum up total weight and subtotal of items
			foreach (Item item in cart.Items)
			{
				var product = _shippingInventoryRepository.GetItem(item.ProductId);
				item.Price = product.ListPrice;
				subTotal += (item.Price * item.Qty);
				weight += (product.ShippingCharacteristics.Weight * item.Qty);
			}

			// calculate subtotal
			cart.SubTotal = subTotal;

			// calculate shipping cost (just the weight)
			if (cart.PostalCode != null)
				cart.ShippingCost = weight;

			// update total
			cart.Total = cart.SubTotal + cart.ShippingCost;

			// return the cart
			return cart;
		}

		public Cart GetOrCreateNewCartForCache(Guid cartId)
		{
			Cart c;
			if (_carts.TryGetValue(cartId, out c))
				return c;
			
			c = new Cart {CartId = cartId};
			_carts[cartId] = c;
			return c;
		}
	}
}