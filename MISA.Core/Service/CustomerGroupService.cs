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
    /// <summary>
    /// Các service riêng của CustomerGroup
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
    }
}
