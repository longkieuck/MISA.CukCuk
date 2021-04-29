﻿using MISA.Core.AttributeCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin khách khách
    /// </summary>
    /// CreatedBy: KDLong 20/04/2021
    public class Customer
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequired("Mã khách hàng không được phép để trống!")]
        [MISAMaxLength(20)]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        /// 
        [MISARequired("Họ tên khách hàng không được phép để trống!")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string MemberCardCode { get; set; }
        public Guid? customerGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}