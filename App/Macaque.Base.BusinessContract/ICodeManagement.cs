using Macaque.Base.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessContract
{
    [ServiceContract]
    public interface ICodeManagement
    {
        [OperationContract]
        List<CodeEntity> GetAllGrades();
    }
}
