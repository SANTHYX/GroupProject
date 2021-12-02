using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Options
{
    public class SecuritySettings
    {
        public const string Section = "AuToken";
        public string Key { get; set; }
    }
}
