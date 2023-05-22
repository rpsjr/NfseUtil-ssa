using System.CodeDom.Compiler;
using System.ServiceModel;

namespace NfseUtil.Proxy
{
	[ServiceContract(ConfigurationName = "ConsultaNfse.IConsultaNfse")]
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	internal interface IConsultaNfse
	{
		[OperationContract(Action = "http://tempuri.org/IConsultaNfse/ConsultarNfse", ReplyAction = "http://tempuri.org/IConsultaNfse/ConsultarNfseResponse")]
		string ConsultarNfse(string consultaxml);
	}
}
