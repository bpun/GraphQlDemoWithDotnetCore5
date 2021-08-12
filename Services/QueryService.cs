using GraphDemo.Context;
using GraphDemo.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Services
{
    public class QueryService: IQueryService
    {
        private readonly OMSOrdersContext _context;
        public QueryService([Service]  OMSOrdersContext context)
        {
            _context = context;
        }
        public List<LineItem> AllLineItemList()
        {
           return _context.LineItems.ToList();
        }

        public Order AllOrderDetailsById(int id)
        {
            return _context.Orders.Where(x => x.Id == id).Include(d => d.OrderDetail).Include(l => l.LineItems)
               .FirstOrDefault();
        }

        public List<Order> AllOrderDetailsHistory()
        {
            return _context.Orders.Include(d => d.OrderDetail).Include(l => l.LineItems)
                .ToList();
        }

        public List<Order> AllOrderSummeryList()
        {
            return _context.Orders.ToList(); 
        }
    }
}
