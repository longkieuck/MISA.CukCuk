using MISA.Core.Entities;
using MISA.Core.Interface.Repository;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Lấy mã nhân viên mới nhất trong hệ thống
        /// </summary>
        /// <returns>Mã nhân viên mới nhất để xử lý</returns>
        /// CreatedBy KDLong 07/05/2021
        public string GetMaxEmployeeCode()
        {
            throw new NotImplementedException();
        }
    }
}
