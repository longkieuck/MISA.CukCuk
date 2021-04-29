
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public bool CheckCustomerCodeExist(string customerCode);
        public bool CheckPhoneNumberExist(string customerCode);

        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
    }
}
