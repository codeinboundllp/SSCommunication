using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SSCommunication.Enum;

namespace SSCommunication.Models
{
    public class CustomEmailTemplateFields
    {
        /// <summary>
        /// Identifies the field in the template eg $Name will be replaced by Name (put the field name in class)
        /// </summary>
        public string FieldIndentifier { get; set; }
        public EmailTemplateTag Tag { get; set; }
        public string TagValue { get; set; }
    }
}
