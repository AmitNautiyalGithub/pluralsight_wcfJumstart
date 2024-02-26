using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zza.Entities;

namespace Zza.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ZzaService : IZzaService, IDisposable
    {
        private static List<Customer> Customers = new List<Customer>()
        {
            new Customer() { Id = Guid.NewGuid(), FirstName="Amit", City="New Delhi", Phone="123456", Zip = "110062" },
            new Customer() { Id = Guid.NewGuid(), FirstName="Sumit", City="New Delhi", Phone="123456", Zip = "110062" },
            new Customer() { Id = Guid.NewGuid(), FirstName="Rohit", City="New Delhi", Phone="123456", Zip = "110062" },
            new Customer() { Id = Guid.NewGuid(), FirstName="Nitin", City="New Delhi", Phone="123456", Zip = "110062" }
        };

        private static List<Product> Products = new List<Product>()
        {
             new Product() { Id = 1 , Name = "Product 1", Description="Description here" },
             new Product() { Id = 2 , Name = "Product 2", Description="Description here" },
             new Product() { Id = 3 , Name = "Product 3", Description="Description here" },
             new Product() { Id = 4 , Name = "Product 4", Description="Description here" },

        };
        
        [PrincipalPermission(SecurityAction.Demand, Role ="BUILTIN\\Administrators")]
        public List<Customer> GetCustomers()
        {
            var principal = Thread.CurrentPrincipal;
            if (!principal.IsInRole("BUILTIN\\Administrators"))
            {
                throw new SecurityException("Access denied!");
            }

            //Claim based authentication
            // ClaimsPrincipal.Current.HasClaim( )
            return Customers;
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SubmitOrder(Order order)
        {
            //_context.Orders.Add(order);
            //order.OrderItems.ToList().ForEach(oi => _context.OrderItems.Add(oi));
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            //if (_context != null)
            //{
            //    _context.Dispose();
            //}
        }
    }
}
