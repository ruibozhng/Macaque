using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig.UnityIntercetpion
{
    public interface ITenantStore
    {
        void Initialize();
        Tenant GetTenant(string tenant);
        IEnumerable<string> GetTenantNames();
        void SaveTenant(Tenant tenant);
        void UpdateTenant(Tenant tenant);
    }

    public interface ITenantLogoStore
    {
        void SaveLogo(string tenant, byte[] logo);
        void UploadLogo(string tenant, byte[] logo);
    }

    public interface ILogger
    {
        void WriteLogMessage(string message);
    }

    public interface ISurveyStore
    {
        Tenant GetTenant(string tenant);
        void SaveTenant(Tenant tenant);
        void UpdateTenant(Tenant tenant);
    }

    public class SurveyStore : ISurveyStore
    {
        [LoggingCallHandler(1)]
        public Tenant GetTenant(string tenant)
        {
            Console.WriteLine("GetTenant");
            return new Tenant();
        }

        [LoggingCallHandler(1)]
        [CachingCallHandler(2)]
        public void SaveTenant(Tenant tenant)
        {
            Console.WriteLine("Save Tenant");
        }

        [Tag("UpdatePolicyRule")]
        public void UpdateTenant(Tenant tenant)
        {
            Console.WriteLine("Update Tenant");
        }
    }

    public class Tenant
    {
    }

    public class TenantStore : ITenantStore, ITenantLogoStore
    {
        public void Initialize()
        {
            Console.WriteLine("Initialize");
        }
        public Tenant GetTenant(string tenant)
        {
            Console.WriteLine("GetTenant");
            return new Tenant();
        }
        public IEnumerable<string> GetTenantNames()
        {
            Console.WriteLine("GetTenantNames");
            List<string> list = new List<string>();
            return list.AsEnumerable();
        }
        public void SaveTenant(Tenant tenant)
        {
            Console.WriteLine("Save Tenant");
        }

        public virtual void UpdateTenant(Tenant tenant)
        {
            Console.WriteLine("UpdateTenant");
        }

        public void UploadLogo(string tenant, byte[] logo)
        {
            Console.WriteLine("UploadLogo");
        }

        public void SaveLogo(string tenant, byte[] logo)
        {
            Console.WriteLine("SaveLogo");
        }
    }
}
