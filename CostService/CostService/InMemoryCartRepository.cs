using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class InMemoryCartRepository : ICartRepository
	{
		readonly IDictionary<Guid, Cart> _carts;

		public InMemoryCartRepository()
		{
			_carts = new Dictionary<Guid, Cart>();
		}

		/// <summary>
		/// Calculates the cost of the shipment
		/// </summary>
		/// <param name="cartId">The cartId we want to calculate the cost for</param>
		/// <param name="postalCode">The postal code we're sending the order to</param>
		/// <returns>A cart with updated subtotal, shippingCost, and total</returns>
		public Cart GetCost(Guid cartId, string postalCode)
		{
			// get cart and starting values
			Cart cart = _carts[cartId];
			cart.SubTotal = 0;
			decimal weight = 0;

			// sum up total weight and subtotal of items
			foreach (Item item in cart.Items)
			{
				cart.SubTotal += (item.Price * item.Qty);
				weight += (item.Product.ShippingCharacteristics.Weight * item.Qty);
			}

			// calculate shipping cost (just the weight)
			cart.ShippingCost = weight;

			// update total
			cart.Total = cart.SubTotal + cart.ShippingCost;

			// return the cart
			return cart;
		}


	}
}