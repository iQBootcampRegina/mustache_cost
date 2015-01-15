using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostService.SubscriptionMessages.Cart
{
	public class CartItemUpdatedMessage
	{
		public Guid CartId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}
}