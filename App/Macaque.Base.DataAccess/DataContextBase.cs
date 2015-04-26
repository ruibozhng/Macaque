using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.DataAccess
{
    public abstract class DataContextBase : DataContext
    {
        public DataContextBase()
            : base(ConfigurationManager.ConnectionStrings[Constant.DATABASE_DEFAULT].ConnectionString)
        {

        }

        public DataContextBase(string connection)
            : base(connection)
        {

        }

        public DataContextBase(IDbConnection connection)
            : base(connection)
        {

        }
    }
}
