using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;

namespace EnterpriseLibConfig.UnityIntercetpion
{
    class InterceptionManagement
    {
        public static void TestInterception()
        {
            //Console.WriteLine("**************************TestInstanceInterceptor*********************");
            //InterceptionManagement.TestInstanceInterceptor();
            //Console.WriteLine("**************************TestTransparentProxyInterceptor*********************");
            //InterceptionManagement.TestTransparentProxyInterceptor();
            //Console.WriteLine("**************************TestVirtualMethodInterceptor*********************");
            //InterceptionManagement.TestVirtualMethodInterceptor();
            //Console.WriteLine("**************************TestBehaviorInterceptor*********************");
            //InterceptionManagement.TestBehaviorInterceptor();
            //Console.WriteLine("**************************TestInterceptionWithoutUnity*********************");
            //InterceptionManagement.TestInterceptionWithoutUnity();
            //TestConfigInterceptor();
            //TestPolicyInjection();
            //TestPolicyInjectionAttributes();
            TestRealExample();
        }

        private static void TestRealExample()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ISurveyStore, SurveyStore>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());
            // Get Entlib config source (Current is in Web.EnterpriseLibrary.config)
            IConfigurationSource source = ConfigurationSourceFactory.Create();

            // Config container from Policy injection config settings 
            var policyInjectionSettings = (PolicyInjectionSettings)source.GetSection(PolicyInjectionSettings.SectionName);
            policyInjectionSettings.ConfigureContainer(container);
            
            var surveyStore = container.Resolve<ISurveyStore>();
            var tenant = new Tenant();
            surveyStore.UpdateTenant(tenant);
            //throw new NotImplementedException();
        }

        private static void TestInstanceInterceptor()
        {
            IUnityContainer container = new UnityContainer();

            // Example 1. Using a container.
            // Configure the container for interception.
            container = new UnityContainer();
            container.AddNewExtension<Interception>();
            // Register the TenantStore type for interception.
            container.RegisterType<ITenantStore, TenantStore>(
            new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>(),
            new InterceptionBehavior<CachingInterceptionBehavior>());
            // Obtain a proxy object with an interception pipeline
            var tenantStore = container.Resolve<ITenantStore>();
            var tenant = new Tenant();
            tenantStore.SaveTenant(tenant);
        }

        private static void TestInterceptionWithoutUnity()
        {
            // Example 2. Using the Intercept class.
            ITenantStore tenantStore = Intercept.ThroughProxy<ITenantStore>(
            new TenantStore(),
            new InterfaceInterceptor(),
            new IInterceptionBehavior[] { new LoggingInterceptionBehavior(), new CachingInterceptionBehavior() });
            var tenant = new Tenant();
            tenantStore.SaveTenant(tenant);
        }

        private static void TestTransparentProxyInterceptor()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ITenantStore, TenantStore>(
                new Interceptor<TransparentProxyInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>());

            var tenantStore = container.Resolve<ITenantStore>();
            // From the ITenantStore interface.
            var tenant = new Tenant();
            tenantStore.SaveTenant(tenant);
            // From the ITenantLogoStore interface.
            var logo = new byte[] { 1, 2 };
            ((ITenantLogoStore)tenantStore).SaveLogo("adatum", logo);
        }

        //Virtual-MethodInterceptor are much faster than those made with the TransparentProxy-Interceptor 
        private static void TestVirtualMethodInterceptor()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ITenantStore, TenantStore>(
                new Interceptor<VirtualMethodInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>());
            var tenantStore = container.Resolve<ITenantStore>();
            var tenant = new Tenant();
            //the SaveTenant method in the TenantStore class must be virtual, and the TenantStore class must be public.
            tenantStore.UpdateTenant(tenant);
        }

        //Using a Behavior to Add an Interface to an Existing Class
        private static void TestBehaviorInterceptor()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ITenantStore, TenantStore>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>(),
                new AdditionalInterface<ILogger>());
            var tenantStore = container.Resolve<ITenantStore>();
            var tenant = new Tenant();
            //the SaveTenant method in the TenantStore class must be virtual, and the TenantStore class must be public.
            tenantStore.SaveTenant(tenant);
            ((ILogger)tenantStore).WriteLogMessage("Message: Write to the log directly...");
        }

        private static void TestConfigInterceptor()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.LoadConfiguration();
            // Obtain a proxy object with an interception pipeline.
            var tenantStore = container.Resolve<ITenantStore>();
            var tenant = new Tenant();
            tenantStore.SaveTenant(tenant);
        }

        private static void TestPolicyInjection()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ITenantStore, TenantStore>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());
            container.RegisterType<ISurveyStore, SurveyStore>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());

            var first = new InjectionProperty("Order", 1);
            var second = new InjectionProperty("Order", 2);

            container.Configure<Interception>()
            .AddPolicy("logging")
            .AddMatchingRule<AssemblyMatchingRule>(
                new InjectionConstructor(
                new InjectionParameter("EnterpriseLibConfig")))
            .AddCallHandler<LoggingCallHandler>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(),
                first);

            //The LogCallHandler class from the Logging Application Block is a call handler to use with the policy injection framework.
            //An alternative approach to configuring the Enterprise Library call handlers is through the PolicyInjection static façade.
            //container.Configure<Interception>()
            //.AddPolicy("logging2")
            //.AddMatchingRule<AssemblyMatchingRule>(
            //    new InjectionConstructor(
            //    new InjectionParameter("EnterpriseLibConfig")))
            //.AddCallHandler<LogCallHandler>(
            //    new ContainerControlledLifetimeManager(),
            //    new InjectionConstructor(),
            //    first);

            container.Configure<Interception>()
            .AddPolicy("caching")
            .AddMatchingRule<MemberNameMatchingRule>(
                new InjectionConstructor(new[] { "Get*", "Save*" }, true))
            .AddMatchingRule<NamespaceMatchingRule>(
                new InjectionConstructor("EnterpriseLibConfig.UnityIntercetpion", true))
            .AddCallHandler<CachingCallHandler>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(),
                second);

            var tenantStore = container.Resolve<ITenantStore>();
            var tenant = new Tenant();
            tenantStore.SaveTenant(tenant);
            tenantStore.UpdateTenant(tenant);
        }

        private static void TestPolicyInjectionAttributes()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ISurveyStore, SurveyStore>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());

            var surveyStore = container.Resolve<ISurveyStore>();
            var tenant = new Tenant();
            surveyStore.GetTenant("");
            surveyStore.SaveTenant(tenant);
        }
    }
}
