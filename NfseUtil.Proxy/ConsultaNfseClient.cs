using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NfseUtil.Proxy
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	internal class ConsultaNfseClient : ClientBase<IConsultaNfse>, IConsultaNfse
	{
		public ConsultaNfseClient()
		{
		}

		public ConsultaNfseClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ConsultaNfseClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaNfseClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaNfseClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public string ConsultarNfse(string consultaxml)
		{
			return base.get_Channel().ConsultarNfse(consultaxml);
		}
	}
}
