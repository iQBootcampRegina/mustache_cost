using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class ShippingCharacteristics
	{
		/// <summary>
		/// The height of a package
		/// </summary>
		public decimal Height { get; set; }

		/// <summary>
		/// The width of the package
		/// </summary>
		public decimal Width { get; set; }

		/// <summary>
		/// Depth of the package
		/// </summary>
		public decimal Depth { get; set; }

		/// <summary>
		/// Weight of the package
		/// </summary>
		public decimal Weight { get; set; }
	}
}