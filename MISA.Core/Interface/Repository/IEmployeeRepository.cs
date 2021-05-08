using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Repository
{
    /// <summary>
    /// Interface EmployeeRepository
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Kiểm tra mã trùng
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// CreatedBy KDLong 07/05/2021
        bool CheckEmployeeCodeExist(string employeeCode);
        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns></returns>
        /// CreatedBy KDLong 07/05/2021
        string GetMaxEmployeeCode();
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
        public Pagging<Employee> GetEmployees(EmployeeFilter employeeFilter);
    }
}
