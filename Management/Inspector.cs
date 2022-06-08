using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace QlikView_CLI.Management
{
    internal class ServiceKeyEndpointBehavior : IEndpointBehavior
    {
        public ServiceKeyClientMessageInspector inspector;

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            this.inspector = new ServiceKeyClientMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }
    }

    internal class ServiceKeyClientMessageInspector : IClientMessageInspector
    {
        private const string SERVICE_KEY_HTTP_HEADER = "X-Service-Key";

        public string ServiceKey { get; set; }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            object httpRequestMessageObject;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                HttpRequestMessageProperty httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                if (httpRequestMessage != null)
                {
                    httpRequestMessage.Headers[SERVICE_KEY_HTTP_HEADER] = (ServiceKey ?? string.Empty);
                }
                else
                {
                    httpRequestMessage = new HttpRequestMessageProperty();
                    httpRequestMessage.Headers.Add(SERVICE_KEY_HTTP_HEADER, (ServiceKey ?? string.Empty));
                    request.Properties[HttpRequestMessageProperty.Name] = httpRequestMessage;
                }
            }
            else
            {
                HttpRequestMessageProperty httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add(SERVICE_KEY_HTTP_HEADER, (ServiceKey ?? string.Empty));
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
