using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Service
{
    /// <summary>
    /// Interface EmployeeService
    /// </summary>
    /// CreatedBy KDLong 07/05/2021
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Tạo ra mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        /// CreatedBy KDLong 07/05/2021
        public string GetNewEmployeeCode();

        /// <summary>
        /// Lấy danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="employeeFilter">
        /// Page - Trang cần lấy
        /// PageSize - Số bản ghi trong trang
        /// Search - Mã,Tên nhân viên
        /// </param>
        /// <returns>
        /// PageSize nhân viên trong trang Page theo tiêu chí Search 
        /// </returns>
        /// CreatedBy KDLong 07/05/2021
        public Pagging<Employee> GetEmployees(EmployeeFilter employeeFilter);
    }
}
