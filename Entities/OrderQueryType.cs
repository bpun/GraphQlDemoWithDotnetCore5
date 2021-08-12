using GraphDemo.Context;
using GraphDemo.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphDemo.Entities
{
    public class OrderQueryType : ObjectType<OrderQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderQueries> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}