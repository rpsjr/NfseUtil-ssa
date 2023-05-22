using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NfseUtil.Proxy
{
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[DebuggerStepThrough]
	internal class ConsultaSituacaoLoteRPSClient : ClientBase<IConsultaSituacaoLoteRPS>, IConsultaSituacaoLoteRPS
	{
		public ConsultaSituacaoLoteRPSClient()
		{
		}

		public ConsultaSituacaoLoteRPSClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ConsultaSituacaoLoteRPSClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaSituacaoLoteRPSClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaSituacaoLoteRPSClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public string ConsultarSituacaoLoteRPS(string loteXML)
		{
			return base.get_Channel().ConsultarSituacaoLoteRPS(loteXML);
		}
	}
}
