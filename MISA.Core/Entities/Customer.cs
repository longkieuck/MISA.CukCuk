using MISA.Core.AttributeCustom;
using MISA.Core.Enum;
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
        /// Là trường bắt buộc, Độ dài tối đa 20 ký tự
        /// </summary>
        [MISARequired]
        [MISAMaxLength(20)]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// Là trường bắt buộc
        /// </summary>
        /// 
        [MISARequired]
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Id nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Số điện thoại
        /// Là trường bắt buộc,Đúng các định dạng về số điện thoại
        /// </summary>
        [MISARequired]
        [MISAFormat(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// Là trường bắt buộc
        /// Đúng định dạng Email
        /// </summary>

        [MISARequired]
        [MISAFormat(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày thay đổi gần ngày hiện tại nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người thay đổi gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}
