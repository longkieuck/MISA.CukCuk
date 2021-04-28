﻿using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface
{
    public interface ICustomerService : IBaseService<Customer>
    {
        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
    }
}
