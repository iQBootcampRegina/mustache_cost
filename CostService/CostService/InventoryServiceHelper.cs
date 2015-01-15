using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CostService
{
	public static class InventoryServiceHelper
	{
		public static RestSharp.RestClient GetInventoryClient()
		{
			return new RestSharp.RestClient(ConfigurationManager.AppSettings["InventoryServiceBaseUrl"]);
		}

		public static RestSharp.RestRequest RequestProducts()
		{
			return new RestSharp.RestRequest(ConfigurationManager.AppSettings["ProductsEndpoint"]);
		}

		public static RestSharp.RestRequest RequestProduct(int productId)
		{
			return new RestSharp.RestRequest(string.Format("{0}({1})", ConfigurationManager.AppSettings["ProductsEndpoint"], productId));
		}
	}
}