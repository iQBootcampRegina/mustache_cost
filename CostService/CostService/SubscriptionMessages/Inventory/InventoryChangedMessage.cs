using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryChangedMessage
{
	public class InventoryChangedMessage
	{
		public int Id { get; set; }
		public double Weight { get; set; }
		public double Height { get; set; }
		public double Depth { get; set; }
		public double Width { get; set; }
		public decimal ListPrice { get; set; }
	}
}