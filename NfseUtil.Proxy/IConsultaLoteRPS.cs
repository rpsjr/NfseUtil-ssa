using System.CodeDom.Compiler;
using System.ServiceModel;

namespace NfseUtil.Proxy
{
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[ServiceContract(ConfigurationName = "ConsultaLoteRps.IConsultaLoteRPS")]
	internal interface IConsultaLoteRPS
	{
		[OperationContract(Action = "http://tempuri.org/IConsultaLoteRPS/ConsultarLoteRPS", ReplyAction = "http://tempuri.org/IConsultaLoteRPS/ConsultarLoteRPSResponse")]
		string ConsultarLoteRPS(string loteXML);
	}
}
