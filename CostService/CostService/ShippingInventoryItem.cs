using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService
{
	public class ShippingInventoryItem
	{
		/// <summary>
		/// Unique Identifier for the Product
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name for the Product
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Description for the Product
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Supplier cost of the product
		/// </summary>
		public decimal Cost { get; set; }

		/// <summary>
		/// List price for sale of the product
		/// </summary>
		public decimal ListPrice { get; set; }

		/// <summary>
		/// Where in the warehouse the product can be found
		/// </summary>
		public string WarehouseLocation { get; set; }

		/// <summary>
		/// Amount of the product available for sale
		/// </summary>
		public int QuantityAvailable { get; set; }

		/// <summary>
		/// Packaging information for the product
		/// </summary>
		public ShippingCharacteristics ShippingCharacteristics { get; set; }

		
	}
}