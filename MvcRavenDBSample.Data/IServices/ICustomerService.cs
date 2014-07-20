using MvcRavenDBSample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRavenDBSample.Data.Repository
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer Create(Customer customer);
        Customer Read(int id);
        Customer Update(Customer customer);
        Customer Delete(int id);
    }
}
