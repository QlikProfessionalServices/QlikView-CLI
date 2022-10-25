using System;
using System.Collections.Generic;
using System.ServiceModel;
using QlikView_CLI.Management;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI
{
    public delegate void MessageEventHandler(string Message);

    public class QMS
    {
        public dynamic client;

        public event MessageEventHandler OnMessage;

        public Uri Uri { get; internal set; } = new Uri("http://localhost:4799/QMS/Service");
        internal static long MaxReceivedMessageSize = 2147483647; //65536

        public List<ServiceInfo> ServiceInfo;
        public List<ServiceInfo> QlikViewServer;
        public List<ServiceInfo> QlikViewManagementService;
        public List<ServiceInfo> QlikViewWebServer;
        public List<ServiceInfo> QlikViewDistributionService;
        public List<ServiceInfo> QlikViewDirectoryServiceConnector;
        public List<ServiceInfo> LicenseService;
        public List<ServiceInfo> RemoteQlikViewManagementService;

        internal virtual void Message(string msg)
        {
            try
            {
                OnMessage?.Invoke(msg);
            }
            catch
            {
                // remove invalid event handler
                OnMessage -= OnMessage;
            }
        }

        public dynamic GetClient(string Url, string version)
        {
            switch (version)
            {
                case "IQMS":
                    client = NewQMSClient(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS1":
                    client = NewQMS2Client(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS2":
                    client = NewQMS2Client(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS3":
                    client = NewQMS3Client(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS4":
                    client = NewQMS4Client(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS5":
                    client = NewQMS5Client(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS6":
                    client = NewQMS6Client(Url: Uri.AbsoluteUri);
                    break;

                case "IQMS7":
                    client = NewQMS7Client(Url: Uri.AbsoluteUri);
                    break;

                default:
                    client = NewQMS7Client(Url: Uri.AbsoluteUri);
                    break;

            }
            return client;
        }

        public void Connect(string version = "IQMS7")
        {
            client = GetClient(Url: Uri.AbsoluteUri, version);
            SetupBindings();
            Message(string.Format("Connected to {0}", client.Endpoint.Address.Uri.Host));
        }

        public void Connect(string url, string version = "IQMS7")
        {
            Uri = new Uri(url);
            client = GetClient(Url: Uri.AbsoluteUri, version);
            SetupBindings();
            Message(string.Format("Connected to {0}", client.Endpoint.Address.Uri.Host));
        }

        public void Connect(string url, System.Net.NetworkCredential Credential, string version = "IQMS7")
        {
            Uri = new Uri(url);
            client = GetClient(Url: Uri.AbsoluteUri, version);
            client.ClientCredentials.Windows.ClientCredential.Domain = Credential.Domain;
            client.ClientCredentials.Windows.ClientCredential.UserName = Credential.UserName;
            client.ClientCredentials.Windows.ClientCredential.Password = Credential.Password;
            SetupBindings();
            Message(string.Format("Connected to {0}", client.Endpoint.Address.Uri.Host));
        }

        private static QMS7Client NewQMS7Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS7Client proxy = new QMS7Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            return proxy;
        }

        private static QMS6Client NewQMS6Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS6Client proxy = new QMS6Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            return proxy;
        }

        private static QMS5Client NewQMS5Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS5Client proxy = new QMS5Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            return proxy;
        }

        private static QMS3Client NewQMS3Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS3Client proxy = new QMS3Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            return proxy;
        }

        private static QMS4Client NewQMS4Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS4Client proxy = new QMS4Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            return proxy;
        }

        private static QMS2Client NewQMS2Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS2Client proxy = new QMS2Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            return proxy;
        }

        private static QMS1Client NewQMS1Client(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMS1Client proxy = new QMS1Client(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            return proxy;
        }

        private static QMSClient NewQMSClient(string Url)
        {
            Uri serviceUri = new Uri(Url);
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            QMSClient proxy = new QMSClient(HttpBinding(), endpointAddress);
            proxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            return proxy;
        }

        private static BasicHttpBinding HttpBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = MaxReceivedMessageSize;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;
            binding.UseDefaultWebProxy = true;
            return binding;
        }

        /// <summary>
        /// Setup bindings to ensure a service key is added to all API requests
        /// </summary>
        private void SetupBindings()
        {
            ServiceKeyEndpointBehavior behavior = new ServiceKeyEndpointBehavior();
            client.ChannelFactory.Endpoint.Behaviors.Add(behavior);
            string key = client.GetTimeLimitedServiceKey();
            behavior.inspector.ServiceKey = key;
            SetServices();
        }

        private void SetServices()
        {
            ServiceInfo = client.GetServices(ServiceTypes.All);
            QlikViewServer = client.GetServices(ServiceTypes.QlikViewServer);
            QlikViewWebServer = client.GetServices(ServiceTypes.QlikViewWebServer);
            QlikViewManagementService = client.GetServices(ServiceTypes.QlikViewManagementService);
            QlikViewDirectoryServiceConnector = client.GetServices(ServiceTypes.QlikViewDirectoryServiceConnector);
            QlikViewDistributionService = client.GetServices(ServiceTypes.QlikViewDistributionService);
            RemoteQlikViewManagementService = client.GetServices(ServiceTypes.RemoteQlikViewManagementService);
            LicenseService = client.GetServices(ServiceTypes.LicenseService);
        }
    }
}
