using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace CostService
{
	public class CostBootstrapper : DefaultNancyBootstrapper	
	{
		protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);
		}
	}
}