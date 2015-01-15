using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace CostService
{
	public class CostModule : NancyModule
	{
		public CostModule()
		{
			Get["/"] = x => "TEST";
		}
	}
}