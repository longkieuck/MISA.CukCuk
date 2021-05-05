using MISA.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Custom một só Attribute phục vụ cho việc auto Validate
/// </summary>
/// CreatedBy: KDLong 28/04/2021
namespace MISA.Core.AttributeCustom
{
    /// <summary>
    /// Validate bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string MsgError = string.Empty;
        public MISARequired()
        {
            MsgError = MISAConstant.Dev_Msg_Require;
        }
    }
    /// <summary>
    /// Validate quá độ dài tối đa
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;
        public string MsgError = string.Empty;
        public MISAMaxLength(int maxLength)
        {
            MaxLength = maxLength;
            var builder = new StringBuilder();
            builder.AppendFormat(MISAConstant.Dev_Msg_MaxLength, maxLength);
            MsgError = builder.ToString();
        }
    }
    /// <summary>
    /// Validate đã tồn tại
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAExist : Attribute
    {
        public string MsgError = string.Empty;
        public MISAExist()
        {
            MsgError = MISAConstant.Dev_Msg_Exist;
        }
    }
    /// <summary>
    /// Validate định dạng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISAFormat : Attribute
    {
        public string MsgError = string.Empty;
        public string Regex = string.Empty;
        public MISAFormat(string regex = "")
        {
            Regex = regex;
            MsgError = MISAConstant.Dev_Msg_Format;
        }
    }

}
