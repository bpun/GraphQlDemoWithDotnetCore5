using GraphDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphDemo.Services
{
    public interface IQueryService
    {
        List<LineItem> AllLineItemList();

        List<Order> AllOrderSummeryList();

        List<Order> AllOrderDetailsHistory();

        Order AllOrderDetailsById(int id);
    }
}
