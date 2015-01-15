using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace CostService
{
	public class CostModule : NancyModule
	{
		private readonly ICartRepository _cartRepository;

		public CostModule()
		{
			Get["/"] = x => "TEST";
			Get["/cache"] = x => "";
		}
	}
}