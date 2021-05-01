using Dapper;
using MISA.Core.Interface.Repository;
using MISA.Core.Entities;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public bool CheckCustomerCodeExist(string customerCode)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@customerCode", customerCode);
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var res = dbConnection.QueryFirstOrDefault<Customer>("Proc_KDLong_CheckCustomerCodeExist", param: parameters, commandType: CommandType.StoredProcedure);
                if (res == null) return true;
                return false;
            }
        }

        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@phoneNumber", phoneNumber);
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var res = dbConnection.QueryFirstOrDefault<Customer>("Proc_KDLong_CheckPhoneNumberExist", param: parameters, commandType: CommandType.StoredProcedure);
                if (res == null) return true;
                return false;
            }
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
