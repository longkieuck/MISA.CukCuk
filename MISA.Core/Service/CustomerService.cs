using MISA.Core.Interface.Service;
using MISA.Core.Interface.Repository;
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter)
        {
            var pagging = _customerRepository.GetCustomers(customerFilter);
            return pagging;
        }
        protected override void CustomValidate(Customer entity)
        {
            base.CustomValidate(entity);
        }
    }
}
