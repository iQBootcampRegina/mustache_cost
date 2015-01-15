using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class ShippingInventoryItem
	{
		public int ProductId { get; set; }
		public decimal Price { get; set; }
		public decimal Weight { get; set; }
		public decimal Width { get; set; }
		public decimal Length { get; set; }
		public decimal Depth { get; set; }

		public void SetDimensions(decimal width, decimal height, decimal depth)
		{
			Width = width;
			Length = Length;
			Depth = depth;
		}

		
	}
}