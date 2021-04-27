using MISA.Core.Interface;
using MISA.Infrastructure.Interface;
using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách toàn bộ khách hàng</returns>
        /// Created by: KDLong 22/04/2021
        public IEnumerable<Customer> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id khách hàng</param
        /// <returns>Khách hàng theo Id</returns>
        /// Created by: KDLong 22/04/2021
        public Customer GetById(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return customer;
        }

        /// <summary>
        /// Thêm mới 1 khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: KDLong 22/04/2021 
        public int Insert(Customer customer)
        {
            var rowsAffect = _customerRepository.Insert(customer);
            return rowsAffect;
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: KDLong 22/04/2021 
        public int Update(Customer customer)
        {
            var rowsAffect = _customerRepository.Update(customer);
            return rowsAffect;
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by: KDLong 22/04/2021 
        public int Delete(Guid customerId)
        {
            var rowsAffect = _customerRepository.Delete(customerId);
            return rowsAffect;
        }
    }
}
