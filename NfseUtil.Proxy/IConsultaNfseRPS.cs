using System.CodeDom.Compiler;
using System.ServiceModel;

namespace NfseUtil.Proxy
{
	[ServiceContract(ConfigurationName = "ConsultaNfseRps.IConsultaNfseRPS")]
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	internal interface IConsultaNfseRPS
	{
		[OperationContract(Action = "http://tempuri.org/IConsultaNfseRPS/ConsultarNfseRPS", ReplyAction = "http://tempuri.org/IConsultaNfseRPS/ConsultarNfseRPSResponse")]
		string ConsultarNfseRPS(string consultaxml);
	}
}
