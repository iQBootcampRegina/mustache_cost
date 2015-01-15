using System;
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

		public Guid CartId { get; set; }
		public IList<Item> Items { get; set; }
		public string PostalCode { get; set; }
		public decimal SubTotal { get; set; }
		public decimal ShippingCost { get; set; }
		public decimal Total { get; set; }
	}
}