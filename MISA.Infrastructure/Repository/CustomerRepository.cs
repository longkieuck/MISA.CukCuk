using Dapper;
using MISA.Infrastructure.Interface;
using MISA.Infrastructure.Model;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public bool CheckCustomerCodeExist(string customerCode)
        {
            return true;
        }

        public bool CheckPhoneNumberExist(string customerCode)
        {
            return true;
        }

        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="customerFilter">
        /// Page = Trang hiện tại
        /// PageSize = Số khách hàng trên 1 trang
        /// FullName = Tên dùng để filter
        /// PhoneNumber = Số điện thoại dùng để filter
        /// CustomerGroupId = Nhóm khách hàng dùng để filter
        /// </param>
        /// <returns></returns>
        /// CreatedBy KDLong 28/04/2021
        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FullName", customerFilter.FullName);
                parameters.Add("@PhoneNumber", customerFilter.PhoneNumber);
                parameters.Add("@CustomerGroupId", customerFilter.CustomerGroupId);

                var totalRecords = dbConnection.QueryFirstOrDefault<int>("Proc_KDLong_GetTotalCustomers", param: parameters, commandType: CommandType.StoredProcedure);

                var totalPages = Math.Ceiling((decimal)totalRecords / customerFilter.PageSize);

                var customers = dbConnection.Query<Customer>("Proc_KDLong_GetCustomers", customerFilter, commandType: CommandType.StoredProcedure);

                // Dữ liệu pagging 
                var paging = new Pagging<Customer>()
                {
                    TotalRecords = totalRecords,
                    TotalPages = (int)totalPages,
                    Data = customers,
                    PageIndex = customerFilter.Page,
                    PageSize = customerFilter.PageSize
                };
                return paging;
            }
        }
    }
}
