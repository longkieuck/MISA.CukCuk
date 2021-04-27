using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Interface
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// Created by : KDLong 22/04/2021
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Lấy thông tin khách hàng theo customerId
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Thông tin khách hàng</returns>
        /// /// Created by : KDLong 22/04/2021

        Customer GetById(Guid customerId);
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin cụ thể của khách hàng</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// Created by : KDLong 22/04/2021

        int Insert(Customer customer);
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin cụ thể của khách hàng</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// /// Created by : KDLong 22/04/2021
        int Update(Customer customer);

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Mã khách hàng</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// /// Created by : KDLong 22/04/2021
        int Delete(Guid customerId);
    }
}
