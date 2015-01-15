using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class ShippingInventoryItem
	{
		public int ProductId { get; set; }
		public decimal Weight { get; set; }
		public decimal Dimensions { get; set; }
	}
}