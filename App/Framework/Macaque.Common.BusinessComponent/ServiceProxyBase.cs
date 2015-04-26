using Macaque.Common.BusinessContract;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Macaque.Common.BusinessComponent
{
    public abstract class ServiceProxyBase
    {
        public abstract void Abort();

        public abstract void Close();

        public abstract bool IsConnective();

        public abstract void Refresh();

    }

    public abstract class ServiceProxyBase<IContract> : ServiceProxyBase, IServiceProxy
    {
        #region Constructors

        protected ServiceProxyBase()
        {
        }

        protected ServiceProxyBase(string endpointName)
        {
            EndpointName = endpointName;
            Channel = GetChannelByEndpointName(endpointName);
            (this as IServiceProxy).Channel = Channel;
        }

        #endregion

        #region Properties

        public string EndpointName { get; set; }

        public IContract Channel
        {
            get;
            set;
        }

        protected IContract PolicyInjectionProxy
        {
            get;
            set;
        }

        protected IContract Proxy
        {
            get
            {
                if (PolicyInjectionProxy != null)
                {
                    return PolicyInjectionProxy;
                }
                return Channel;
            }
        }

        object IServiceProxy.Channel
        {
            get;
            set;
        }

        protected void WrapObject(IContract objectInitWithEndpointName)
        {
            PolicyInjectionProxy = PolicyInjection.Wrap<IContract>(objectInitWithEndpointName);
        }

        #endregion

        #region IServiceProxy Members

        public void Dispose()
        {
            ICommunicationObject channel = Channel as ICommunicationObject;
            CloseChannel(channel);

            IDisposable obj = Channel as IDisposable;
            if (null != obj)
                obj.Dispose();

            if (null != PolicyInjectionProxy)
            {
                obj = PolicyInjectionProxy as IDisposable;
                if (null != obj)
                    obj.Dispose();
            }
        }

        private static void CloseChannel(ICommunicationObject channel)
        {
            if (null == channel)
            {
                return;
            }

            switch (channel.State)
            {
                case CommunicationState.Opened:
                    try
                    {
                        channel.Close();
                    }
                    catch (Exception)
                    {
                        channel.Abort();
                    }
                    break;
                case CommunicationState.Closed:
                    break;
                case CommunicationState.Faulted:
                case CommunicationState.Closing:
                case CommunicationState.Created:
                case CommunicationState.Opening:
                default:
                    channel.Abort();
                    break;
            }

        }

        public override void Abort()
        {
            ICommunicationObject channel = ExtractChannel();

            if (null == channel)
            {
                return;
            }
            channel.Abort();
        }

        public override void Close()
        {
            ICommunicationObject channel = ExtractChannel();

            if (null == channel)
            {
                return;
            }

            channel.Close();
        }

        public override bool IsConnective()
        {
            ICommunicationObject channel = ExtractChannel();

            if (null == channel)
            {
                return false;
            }

            return channel.State != CommunicationState.Closed
                && channel.State != CommunicationState.Closing
                && channel.State != CommunicationState.Faulted;
        }

        public override void Refresh()
        {
            IServiceProxy proxy = PolicyInjectionProxy as IServiceProxy;

            if (null != proxy)
            {
                proxy.Channel = GetChannelByEndpointName(EndpointName);
            }
            else
            {
                Channel = GetChannelByEndpointName(EndpointName);
                (this as IServiceProxy).Channel = Channel;
            }
        }

        private ICommunicationObject ExtractChannel()
        {
            ICommunicationObject channel = null;
            IServiceProxy proxy = PolicyInjectionProxy as IServiceProxy;

            if (null != proxy)
            {
                channel = proxy.Channel as ICommunicationObject;
            }
            else
            {
                channel = Channel as ICommunicationObject;
            }

            return channel;
        }

        #endregion

        protected IContract GetChannelByEndpointName(string endpointName)
        {
            string prefix = ConfigurationManager.AppSettings["EndpointPrefix"];
            return new ChannelFactory<IContract>(endpointName, new EndpointAddress(prefix + EndpointElements[endpointName].Address.OriginalString)).CreateChannel();
        }

        protected static Dictionary<string, ChannelEndpointElement> _endpointElements { get; set; }

        protected static Dictionary<string, ChannelEndpointElement> EndpointElements
        {
            get
            {
                if (_endpointElements == null)
                {
                    _endpointElements = new Dictionary<string, ChannelEndpointElement>();

                    Configuration config;
                    if (System.Web.HttpContext.Current != null)
                        config = WebConfigurationManager.OpenWebConfiguration("~/");
                    else config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    ServiceModelSectionGroup sct = config.SectionGroups["system.serviceModel"] as ServiceModelSectionGroup;

                    foreach (ChannelEndpointElement endpoint in sct.Client.Endpoints)
                    {
                        _endpointElements[endpoint.Name] = endpoint;
                    }
                }

                return _endpointElements;

                //var _endpointElements = new Dictionary<string, ChannelEndpointElement>();

                //Configuration config;
                //if (System.Web.HttpContext.Current != null)
                //    config = WebConfigurationManager.OpenWebConfiguration("~/");
                //else config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //ServiceModelSectionGroup sct = config.SectionGroups["system.serviceModel"] as ServiceModelSectionGroup;

                //foreach (ChannelEndpointElement endpoint in sct.Client.Endpoints)
                //{
                //    _endpointElements[endpoint.Name] = endpoint;
                //}
                //return _endpointElements;
            }
        }
    }
}
