using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Employee class
    /// </summary>
    /// Createdby KDLong 07/05/2021
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Giới tính
        /// 0 - Nam
        /// 1 - Nữ
        /// 2 - Khác
        /// null - Không xác định
        /// </summary>
        public int Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0:
                        return "Nam";
                    case 1:
                        return "Nữ";
                    case 2:
                        return "Khác";
                    default:
                        return "Không xác định";
                }
            }
        }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfbirth { get; set; }
        /// <summary>
        /// Số CMT
        /// </summary>
        public string IdentifyNumber { get; set; }
        /// <summary>
        /// Vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Đơn vị  
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// Chi nhánh
        /// </summary>
        public string BankBranch { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày cấp CMT
        /// </summary>
        public DateTime IdentifyDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentifyPlace { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string ConstantPhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
