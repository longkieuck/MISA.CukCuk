using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Department class
    /// </summary>
    /// Createdby KDLong 07/05/2021
    public class Department
    {
        /// <summary>
        /// Id đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
