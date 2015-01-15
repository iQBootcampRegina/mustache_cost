using System.Collections;
using System.Collections.Generic;

namespace CostService
{
	public class Cart
	{
		public Cart()
		{
			Items = new List<Item>();
		}

		public int cartId { get; set; }
		public IList<Item> Items { get; set; }
		public string postalCode { get; set; }
		public decimal subTotal { get; set; }
		public decimal shippingCost { get; set; }
		public decimal total { get; set; }
	}
}