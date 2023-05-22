using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NfseUtil.Proxy
{
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[DebuggerStepThrough]
	internal class ConsultaNfseRPSClient : ClientBase<IConsultaNfseRPS>, IConsultaNfseRPS
	{
		public ConsultaNfseRPSClient()
		{
		}

		public ConsultaNfseRPSClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ConsultaNfseRPSClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaNfseRPSClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaNfseRPSClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public string ConsultarNfseRPS(string consultaxml)
		{
			return base.get_Channel().ConsultarNfseRPS(consultaxml);
		}
	}
}
