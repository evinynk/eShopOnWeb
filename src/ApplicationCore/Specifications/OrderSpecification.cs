using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public class OrderSpecification : Specification<Order>
{
    public OrderSpecification()
    {
        Query
       .Include(o => o.OrderItems)
       .ThenInclude(i => i.ItemOrdered);
    }
}
