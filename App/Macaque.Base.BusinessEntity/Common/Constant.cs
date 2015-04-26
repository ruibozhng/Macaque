using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    public class Constant
    {
        public const string Namespace = "http://pop/";

        public const string DATABASE_DEFAULT = DATABASE_POP;
        public const string DATABASE_POP = "dbTest";

        public const string ERROR_APPSETTING_NOT_FOUND = "APPSETTING NOT FOUND: {0}";
        public const string ERROR_SYSTEM_PARAMETER_NOT_FOUND = "SYSTEM PARAMETER NOT FOUND: {0}";

        public const string EMAIL_SENDER = "Email_Sender";

    }
}
