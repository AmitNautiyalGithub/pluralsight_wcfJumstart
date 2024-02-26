using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Zza.Client.ZzaService;
using Zza.Entities;

namespace Zza.Client
{
    public class ZzaProxy : ClientBase<IZzaService>, IZzaService
    {

        public ZzaProxy() { }
        public ZzaProxy(string endpointname) : base(endpointname) { }
        public ZzaProxy(Binding binding, string address) : base(binding, new EndpointAddress(address)) { }

        public List<Customer> GetCustomers()
        {
            return Channel.GetCustomers();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Channel.GetCustomersAsync();
        }

        public List<Product> GetProducts()
        {
            return Channel.GetProducts();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Channel.GetProductsAsync();
        }

        public void SubmitOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task SubmitOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
