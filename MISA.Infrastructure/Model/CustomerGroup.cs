﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Model
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// </summary>
    /// CreatedBy KDLong 27/04/2021
    public class CustomerGroup
    {
        public Guid customerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
