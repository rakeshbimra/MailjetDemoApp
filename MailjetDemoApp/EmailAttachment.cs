using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    /// <summary>
    /// Email attachment
    /// </summary>
    public class EmailAttachment
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Base64EncodedContent { get; set; }
    }
}
