using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NfseUtil.Proxy
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	internal class ConsultaSituacaoNfseClient : ClientBase<IConsultaSituacaoNfse>, IConsultaSituacaoNfse
	{
		public ConsultaSituacaoNfseClient()
		{
		}

		public ConsultaSituacaoNfseClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ConsultaSituacaoNfseClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaSituacaoNfseClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ConsultaSituacaoNfseClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public string ConsultarSituacaoNfse(string consultaXml)
		{
			return base.get_Channel().ConsultarSituacaoNfse(consultaXml);
		}
	}
}
