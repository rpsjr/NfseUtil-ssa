using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NfseUtil.Proxy
{
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[DebuggerStepThrough]
	internal class ConsultaLoteRPSClient : ClientBase<IConsultaLoteRPS>, IConsultaLoteRPS
	{
		public ConsultaLoteRPSClient()
		{
		}

		public ConsultaLoteRPSClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ConsultaLoteRPSClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaLoteRPSClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaLoteRPSClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public string ConsultarLoteRPS(string loteXML)
		{
			return base.get_Channel().ConsultarLoteRPS(loteXML);
		}
	}
}
