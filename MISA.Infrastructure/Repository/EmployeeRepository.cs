using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interface.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    /// <summary>
    /// Employee Repository
    /// </summary>
    /// CreatedBy KDLong 07/05/2021
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Check trùng mã
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>bool</returns>
        /// CreatedBy KDLong 07/05/2021
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", employeeCode);
                var res = dbConnection.QueryFirstOrDefault<bool>($"Proc_CheckEmployeeCodeExist", param: parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Lấy mã nhân viên mới nhất trong hệ thống
        /// </summary>
        /// <returns>Mã nhân viên mới nhất để xử lý</returns>
        /// CreatedBy KDLong 07/05/2021
        public string GetMaxEmployeeCode()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var res = dbConnection.QueryFirstOrDefault<string>($"Proc_GetMaxEmployeeCode", commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Lấy nhanh sách nhân viên theo điều kiện
        /// </summary>
        /// <param name="employeeFilter">
        /// Page
        /// PageSize
        /// Search
        /// </param>
        /// <returns>Danh sách nv</returns>
        /// CreatedBy KDLong 07/05/2021
        public Pagging<Employee> GetEmployees(EmployeeFilter employeeFilter)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Search", employeeFilter.Search);

                var totalRecords = dbConnection.QueryFirstOrDefault<int>("Proc_GetTotalEmployees", param: parameters, commandType: CommandType.StoredProcedure);

                var totalPages = Math.Ceiling((decimal)totalRecords / employeeFilter.PageSize);

                var employees = dbConnection.Query<Employee>("Proc_GetEmployeesFilter", param: employeeFilter, commandType: CommandType.StoredProcedure);

                // Dữ liệu pagging 
                var paging = new Pagging<Employee>()
                {
                    TotalRecords = totalRecords,
                    TotalPages = (int)totalPages,
                    Data = employees,
                    PageIndex = employeeFilter.Page,
                    PageSize = employeeFilter.PageSize
                };
                return paging;
            }
        }
    }
}
