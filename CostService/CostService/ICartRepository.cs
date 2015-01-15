using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostService
{
	interface ICartRepository
	{
		Cart GetCost(Guid cartId, string postalCode);
	}
}
