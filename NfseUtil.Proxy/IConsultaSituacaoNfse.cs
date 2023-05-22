using System.CodeDom.Compiler;
using System.ServiceModel;

namespace NfseUtil.Proxy
{
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[ServiceContract(ConfigurationName = "ConsultaSituacaoNfse.IConsultaSituacaoNfse")]
	internal interface IConsultaSituacaoNfse
	{
		[OperationContract(Action = "http://tempuri.org/IConsultaSituacaoNfse/ConsultarSituacaoNfse", ReplyAction = "http://tempuri.org/IConsultaSituacaoNfse/ConsultarSituacaoNfseResponse")]
		string ConsultarSituacaoNfse(string consultaXml);
	}
}
