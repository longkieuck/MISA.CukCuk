using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Enum
{
    /// <summary>
    /// Hằng số lấy trong resource
    /// </summary>
    /// CreatedBy: KDLong 05/05/2021
    public class MISAConstant
    {
        /// <summary>
        /// không được phép để trống!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Dev_Msg_Require = Properties.Resources.Dev_Msg_Require;
        /// <summary>
        /// sai định dạng!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Dev_Msg_Format = Properties.Resources.Dev_Msg_Format;
        /// <summary>
        /// vượt quá độ dài!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Dev_Msg_MaxLength = Properties.Resources.Dev_Msg_MaxLength;
        /// <summary>
        /// đã tồn tại trong hệ thống
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Dev_Msg_Exist = Properties.Resources.Dev_Msg_Exist;
        /// <summary>
        /// Có lỗi sảy ra vui lòng liên hệ MISA!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string User_Msg_Error = Properties.Resources.User_Msg_Error;

        /// <summary>
        /// Sửa thành công!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Update_Success = Properties.Resources.Update_Success;
        /// <summary>
        /// Sửa thất bại!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Update_Fail = Properties.Resources.Update_Fail;
        /// <summary>
        /// Xóa thành công!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Delete_Success = Properties.Resources.Delete_Success;
        /// <summary>
        /// Xóa thất bại!
        /// </summary>
        /// CreatedBy: KDLong 05/05/2021
        public static string Delete_Fail = Properties.Resources.Delete_Fail;
    }
}
