﻿using System;
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
			base.ConfigureApplicationContainer(container);

			container.Register<IShippingInventoryRepository, InMemoryShippingInventoryRepository>().AsSingleton();
			container.Register<ICartRepository, InMemoryCartRepository>().AsSingleton();
			ServiceBusSubscriber.Instance.Subscribe();
		}

	
	}
}