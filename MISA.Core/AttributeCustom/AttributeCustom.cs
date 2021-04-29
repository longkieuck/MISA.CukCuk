using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.AttributeCustom
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string MsgError = string.Empty;
        public MISARequired(string msgError = "")
        {
            MsgError = msgError;
        }
    }
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;
        public string MsgError = string.Empty;
        public MISAMaxLength(int maxLength = 20)
        {
            MaxLength = maxLength;
            MsgError = "không được dài quá " + maxLength + " kí tự";
        }
    }
}
