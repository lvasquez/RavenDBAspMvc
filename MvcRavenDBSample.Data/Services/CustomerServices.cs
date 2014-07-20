using MvcRavenDBSample.Data.Repository;
using MvcRavenDBSample.Domain.Model;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRavenDBSample.Data.Service
{
    public class CustomerServices : ICustomerService
    {

        DocumentStore _store = null;

        public CustomerServices(string url)
        {
            _store = new DocumentStore() { Url = url };
            _store.Initialize();
        }
        
        public IEnumerable<Customer> GetCustomers()
        {
            using (var documentSession = _store.OpenSession())
            {
                var list = documentSession.Query<Customer>().ToList();
                return list;
            }
        }

        public Customer Create(Customer customer)
        {
            using (var documentSession = _store.OpenSession())
            {
                documentSession.Store(customer);
                documentSession.SaveChanges();
                return customer;
            }
        }

        public Customer Read(int id)
        {
            using (var documentSession = _store.OpenSession())
            {
                var customer = documentSession.Load<Customer>(id);
                return customer;
            }
        }

        public Customer Update(Customer customer)
        {
            using (var documentSession = _store.OpenSession())
            {
                Customer currentCustomer = documentSession.Load<Customer>(customer.Id);
                currentCustomer.Name = customer.Name;
                currentCustomer.Address = customer.Address;

                documentSession.Store(currentCustomer);
                documentSession.SaveChanges();
                return customer;
            }
        }

        public Customer Delete(int id)
        {
            using (var documentSession = _store.OpenSession())
            {
                var customer = documentSession.Load<Customer>(id);
                documentSession.Delete<Customer>(customer);
                documentSession.SaveChanges();
                return customer;
            }
        }
    }
}
