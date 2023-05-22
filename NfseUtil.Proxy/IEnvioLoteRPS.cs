using System.CodeDom.Compiler;
using System.ServiceModel;

namespace NfseUtil.Proxy
{
	[GeneratedCode("System.ServiceModel", "3.0.0.0")]
	[ServiceContract(ConfigurationName = "EnvioLoteRps.IEnvioLoteRPS")]
	internal interface IEnvioLoteRPS
	{
		[OperationContract(Action = "http://tempuri.org/IEnvioLoteRPS/EnviarLoteRPSComplementar", ReplyAction = "http://tempuri.org/IEnvioLoteRPS/EnviarLoteRPSComplementarResponse")]
		string EnviarLoteRPSComplementar(string loteXML, string pxmlDadosComplementares);

		[OperationContract(Action = "http://tempuri.org/IEnvioLoteRPS/EnviarLoteRPS", ReplyAction = "http://tempuri.org/IEnvioLoteRPS/EnviarLoteRPSResponse")]
		string EnviarLoteRPS(string loteXML);
	}
}
