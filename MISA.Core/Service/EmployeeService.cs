using MISA.Core.Entities;
using MISA.Core.Enum;
using MISA.Core.Exceptions;
using MISA.Core.Interface.Repository;
using MISA.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    /// <summary>
    /// Employee Service
    /// </summary>
    /// CreatedBy KDLong 07/05/2021
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
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
        public Pagging<Employee> GetEmployees(EmployeeFilter employeeFilter)
        {
            var pagging = _employeeRepository.GetEmployees(employeeFilter);
            return pagging;
        }
        /// <summary>
        /// Lấy mã nhân viên lớn nhất trong db để tạo ra mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// CreatedBy KDLong 08/05/2021
        public string GetNewEmployeeCode()
        {
            var maxEmployeeCode = _employeeRepository.GetMaxEmployeeCode();
            if (maxEmployeeCode == null)
            {
                return "NV-0001";
            }
            var res = maxEmployeeCode.Substring(0, 3);

            var numStr = maxEmployeeCode.Substring(3);

            var numInt = Int32.Parse(numStr) + 1;
            var numNew = Convert.ToString(numInt);
            var lengthNumNew = numNew.Length;
            for (int i = 0; i < 4 - lengthNumNew; i++)
            {
                numNew = "0" + numNew;
            }
            res = res + numNew;

            return res;
        }

        protected override void CustomValidate(Employee entity)
        {
            var isEmployeeCodeExist = _employeeRepository.CheckEmployeeCodeExist(entity.EmployeeCode);
            if(isEmployeeCodeExist) throw new BaseException("EmployeeCode" + MISAConstant.Dev_Msg_Exist);
        }
    }
}
