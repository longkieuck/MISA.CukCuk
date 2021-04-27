using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public bool CheckCustomerCodeExist(string customerCode);
        public bool CheckPhoneNumberExist(string customerCode);
    }
}
