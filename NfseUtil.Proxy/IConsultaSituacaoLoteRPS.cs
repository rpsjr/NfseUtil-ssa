using System.CodeDom.Compiler;
using System.ServiceModel;

namespace NfseUtil.Proxy
{
	[ServiceContract(ConfigurationName = "ConsultaSituacaoLoteRps.IConsultaSituacaoLoteRPS")]
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	internal interface IConsultaSituacaoLoteRPS
	{
		[OperationContract(Action = "http://tempuri.org/IConsultaSituacaoLoteRPS/ConsultarSituacaoLoteRPS", ReplyAction = "http://tempuri.org/IConsultaSituacaoLoteRPS/ConsultarSituacaoLoteRPSResponse")]
		string ConsultarSituacaoLoteRPS(string loteXML);
	}
}
