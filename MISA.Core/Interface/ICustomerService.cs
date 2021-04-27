using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface
{
    public interface ICustomerService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách toàn bộ khách hàng</returns>
        /// Created by: KDLong 22/04/2021
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id khách hàng</param
        /// <returns>Khách hàng theo Id</returns>
        /// Created by: KDLong 22/04/2021
        Customer GetById(Guid customerId);

        /// <summary>
        /// Thêm mới 1 khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: KDLong 22/04/2021 
        int Insert(Customer customer);

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: KDLong 22/04/2021 
        int Update(Customer customer);

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: KDLong 22/04/2021 
        int Delete(Guid customerId);

    }
}
