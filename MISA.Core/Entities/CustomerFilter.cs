using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Endpoint filter dùng cho việc lọc các khách hàng
    /// </summary>
    /// CreatedBy: KDLong 28/04/2021
    public class CustomerFilter
    {
        /// <summary>
        /// Trang muốn lấy dữ liệu
        /// </summary>
        public int Page { get; set; } = 1;
        /// <summary>
        /// Tổng số bản ghi trên 1 trang
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// Tên dùng để filter
        /// </summary>
        public string FullName { get; set; } = "";
        /// <summary>
        /// Số điện thoại dùng để filter
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// Filter theo nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; } = null;
    }
}
