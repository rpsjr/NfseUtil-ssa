using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace NfseUtil.Proxy
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	internal class EnvioLoteRPSClient : ClientBase<IEnvioLoteRPS>, IEnvioLoteRPS
	{
		public EnvioLoteRPSClient()
		{
		}

		public EnvioLoteRPSClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public EnvioLoteRPSClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public EnvioLoteRPSClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public EnvioLoteRPSClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public string EnviarLoteRPSComplementar(string loteXML, string pxmlDadosComplementares)
		{
			return base.get_Channel().EnviarLoteRPSComplementar(loteXML, pxmlDadosComplementares);
		}

		public string EnviarLoteRPS(string loteXML)
		{
			return base.get_Channel().EnviarLoteRPS(loteXML);
		}
	}
}
