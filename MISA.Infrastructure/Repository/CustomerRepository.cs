using Dapper;
using MISA.Core.Interface.Repository;
using MISA.Core.Entities;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    /// <summary>
    /// Repository của riêng Customer
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>bool</returns>#
        /// CreatedBy: KDLong 27/04/2021
        public bool CheckCustomerCodeExist(string customerCode)
        {

            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customerCode", customerCode);
                var res = dbConnection.QueryFirstOrDefault<bool>("Proc_KDLong_CheckCustomerCodeExist", parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        /// <summary>
        /// Check trùng SĐT
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>bool</returns>
        /// CreatedBy: KDLong 27/04/2021
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@phoneNumber", phoneNumber);
                var res = dbConnection.QueryFirstOrDefault<bool>("Proc_KDLong_CheckPhoneNumberExist", parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        /// <summary>
        /// Check trùng Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        /// CreatedBy: KDLong 27/04/2021
        public bool CheckEmailExist(string email)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@email", email);
                var res = dbConnection.QueryFirstOrDefault<bool>("Proc_KDLong_CheckEmailExist", parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        /// <summary>
        /// Lấy CustomerCode theo CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>CustomerCode</returns>
        /// CreatedBy: KDLong 27/04/2021
        public string GetCustomerCodeById(Guid customerId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@customerId", customerId);
                var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return customer.CustomerCode;
            }
        }
        /// <summary>
        /// Lấy Email theo CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Email</returns>
        /// CreatedBy: KDLong 27/04/2021
        public string GetEmailById(Guid customerId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@customerId", customerId);
                var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return customer.Email;
            }
        }

        /// <summary>
        /// Lấy PhoneNumber theo CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>PhoneNumber</returns>
        /// CreatedBy: KDLong 27/04/2021
        public string GetPhoneNumberById(Guid customerId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@customerId", customerId);
                var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return customer.PhoneNumber;
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
