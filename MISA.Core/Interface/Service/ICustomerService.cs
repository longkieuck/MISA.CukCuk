using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Service
{
    public interface ICustomerService : IBaseService<Customer>
    {
        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
    }
}
