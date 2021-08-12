using GraphDemo.Context;
using GraphDemo.Models;
using GraphDemo.Services;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphDemo.Entities
{
    public class OrderQueries
    {
        public List<LineItem> AllLineItemList([Service] IQueryService service) =>
           service.AllLineItemList();

        public List<Order> AllOrderSummeryList([Service] IQueryService service) =>
            service.AllOrderSummeryList();

        public List<Order> AllOrderDetailsHistory([Service] IQueryService service) =>
           service.AllOrderDetailsHistory();

        public Order AllOrderDetailsById([Service] IQueryService service, int id) =>
          service.AllOrderDetailsById(id);

        //public List<LineItem> AllLineItemList([Service] OMSOrdersContext context) =>
        //   context.LineItems.ToList();

        //public List<Order> AllOrderSummeryList([Service] OMSOrdersContext context) =>
        //    context.Orders.ToList();

        //public List<Order> AllOrderDetailsHistory([Service] OMSOrdersContext context) =>
        //   context.Orders.Include(d => d.OrderDetail).Include(l=> l.LineItems)
        //        .ToList();

        //public Order AllOrderDetailsById([Service] OMSOrdersContext context, int id) =>
        //  context.Orders.Where(x=> x.Id == id).Include(d => d.OrderDetail).Include(l => l.LineItems)
        //       .FirstOrDefault();
    }
}