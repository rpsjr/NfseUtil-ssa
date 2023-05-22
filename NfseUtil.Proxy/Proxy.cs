using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;

namespace NfseUtil.Proxy
{
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class Proxy : ServicedComponent, IProxy
	{
		private X509Certificate2 _certificado;

		public bool AtribuirCertificadoDigital(string LocalRepositorio, string NomeCertificado, string NomeRepositorio)
		{
			X509Certificate2 val = Certificado.ObterCertificado(LocalRepositorio, NomeCertificado, NomeRepositorio);
			if (val == null)
			{
				return false;
			}
			AtribuirCertificadoDigital(val);
			return true;
		}

		public bool AtribuirCertificadoDigital(string LocalRepositorio, string NomeCertificado)
		{
			X509Certificate2 val = Certificado.ObterCertificado(LocalRepositorio, NomeCertificado);
			if (val == null)
			{
				return false;
			}
			AtribuirCertificadoDigital(val);
			return true;
		}

		private void AtribuirCertificadoDigital(X509Certificate2 certificado)
		{
			_certificado = certificado;
		}

		public string ConsultarLoteRps(string loteXml)
		{
			return ConsultarLoteRpsUrl(loteXml, null);
		}

		public string ConsultarLoteRpsUrl(string loteXml, string url)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			ConsultaLoteRPSClient consultaLoteRPSClient = null;
			try
			{
				consultaLoteRPSClient = (string.IsNullOrEmpty(url) ? new ConsultaLoteRPSClient() : new ConsultaLoteRPSClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IConsultaLoteRPS>)consultaLoteRPSClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IConsultaLoteRPS>)consultaLoteRPSClient).Open();
				return consultaLoteRPSClient.ConsultarLoteRPS(loteXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (consultaLoteRPSClient != null && (int)((ClientBase<IConsultaLoteRPS>)consultaLoteRPSClient).get_State() == 2)
				{
					((ClientBase<IConsultaLoteRPS>)consultaLoteRPSClient).Close();
				}
			}
		}

		public string ConsultarNfse(string consultaXml)
		{
			return ConsultarNfseUrl(consultaXml, null);
		}

		public string ConsultarNfseUrl(string consultaXml, string url)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			ConsultaNfseClient consultaNfseClient = null;
			try
			{
				consultaNfseClient = (string.IsNullOrEmpty(url) ? new ConsultaNfseClient() : new ConsultaNfseClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IConsultaNfse>)consultaNfseClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IConsultaNfse>)consultaNfseClient).Open();
				return consultaNfseClient.ConsultarNfse(consultaXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (consultaNfseClient != null && (int)((ClientBase<IConsultaNfse>)consultaNfseClient).get_State() == 2)
				{
					((ClientBase<IConsultaNfse>)consultaNfseClient).Close();
				}
			}
		}

		public string ConsultarNfseRPS(string consultaXml)
		{
			return ConsultarNfseRPSUrl(consultaXml, null);
		}

		public string ConsultarNfseRPSUrl(string consultaXml, string url)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			ConsultaNfseRPSClient consultaNfseRPSClient = null;
			try
			{
				consultaNfseRPSClient = (string.IsNullOrEmpty(url) ? new ConsultaNfseRPSClient() : new ConsultaNfseRPSClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IConsultaNfseRPS>)consultaNfseRPSClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IConsultaNfseRPS>)consultaNfseRPSClient).Open();
				return consultaNfseRPSClient.ConsultarNfseRPS(consultaXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (consultaNfseRPSClient != null && (int)((ClientBase<IConsultaNfseRPS>)consultaNfseRPSClient).get_State() == 2)
				{
					((ClientBase<IConsultaNfseRPS>)consultaNfseRPSClient).Close();
				}
			}
		}

		public string ConsultarSituacaoLoteRPS(string loteXml)
		{
			return ConsultarSituacaoLoteRPSUrl(loteXml, null);
		}

		public string ConsultarSituacaoLoteRPSUrl(string loteXml, string url)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			ConsultaSituacaoLoteRPSClient consultaSituacaoLoteRPSClient = null;
			try
			{
				consultaSituacaoLoteRPSClient = (string.IsNullOrEmpty(url) ? new ConsultaSituacaoLoteRPSClient() : new ConsultaSituacaoLoteRPSClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IConsultaSituacaoLoteRPS>)consultaSituacaoLoteRPSClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IConsultaSituacaoLoteRPS>)consultaSituacaoLoteRPSClient).Open();
				return consultaSituacaoLoteRPSClient.ConsultarSituacaoLoteRPS(loteXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (consultaSituacaoLoteRPSClient != null && (int)((ClientBase<IConsultaSituacaoLoteRPS>)consultaSituacaoLoteRPSClient).get_State() == 2)
				{
					((ClientBase<IConsultaSituacaoLoteRPS>)consultaSituacaoLoteRPSClient).Close();
				}
			}
		}

		public string ConsultarSituacaoNfse(string consultaXml)
		{
			return ConsultarSituacaoNfseUrl(consultaXml, null);
		}

		public string ConsultarSituacaoNfseUrl(string consultaXml, string url)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			ConsultaSituacaoNfseClient consultaSituacaoNfseClient = null;
			try
			{
				consultaSituacaoNfseClient = (string.IsNullOrEmpty(url) ? new ConsultaSituacaoNfseClient() : new ConsultaSituacaoNfseClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IConsultaSituacaoNfse>)consultaSituacaoNfseClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IConsultaSituacaoNfse>)consultaSituacaoNfseClient).Open();
				return consultaSituacaoNfseClient.ConsultarSituacaoNfse(consultaXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (consultaSituacaoNfseClient != null && (int)((ClientBase<IConsultaSituacaoNfse>)consultaSituacaoNfseClient).get_State() == 2)
				{
					((ClientBase<IConsultaSituacaoNfse>)consultaSituacaoNfseClient).Close();
				}
			}
		}

		public string EnviarLoteRPS(string loteXml)
		{
			return EnviarLoteRPSUrl(loteXml, null);
		}

		public string EnviarLoteRPSUrl(string loteXml, string url)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Invalid comparison between Unknown and I4
			EnvioLoteRPSClient envioLoteRPSClient = null;
			try
			{
				envioLoteRPSClient = (string.IsNullOrEmpty(url) ? new EnvioLoteRPSClient() : new EnvioLoteRPSClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).Open();
				return envioLoteRPSClient.EnviarLoteRPS(loteXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (envioLoteRPSClient != null && (int)((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).get_State() == 2)
				{
					((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).Close();
				}
			}
		}

		public string EnviarLoteRPSComplementar(string loteXml, string dadosComplementaresXml)
		{
			return EnviarLoteRPSComplementarUrl(loteXml, dadosComplementaresXml, null);
		}

		public string EnviarLoteRPSComplementarUrl(string loteXml, string dadosComplementaresXml, string url)
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Invalid comparison between Unknown and I4
			EnvioLoteRPSClient envioLoteRPSClient = null;
			try
			{
				envioLoteRPSClient = (string.IsNullOrEmpty(url) ? new EnvioLoteRPSClient() : new EnvioLoteRPSClient(CriarBinding(), CriarEndPoint(url)));
				if (_certificado != null)
				{
					((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).get_ClientCredentials().get_ClientCertificate().set_Certificate(_certificado);
				}
				((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).Open();
				return envioLoteRPSClient.EnviarLoteRPSComplementar(loteXml, dadosComplementaresXml);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (envioLoteRPSClient != null && (int)((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).get_State() == 2)
				{
					((ClientBase<IEnvioLoteRPS>)envioLoteRPSClient).Close();
				}
			}
		}

		private Binding CriarBinding()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			BasicHttpBinding val = new BasicHttpBinding();
			((Binding)val).set_Name("nfseBasicHttpBinding");
			val.set_AllowCookies(false);
			val.set_HostNameComparisonMode((HostNameComparisonMode)0);
			val.set_MessageEncoding((WSMessageEncoding)0);
			val.set_TextEncoding(Encoding.UTF8);
			val.set_TransferMode((TransferMode)0);
			val.set_UseDefaultWebProxy(true);
			val.get_Security().set_Mode((BasicHttpSecurityMode)1);
			val.get_Security().get_Transport().set_ClientCredentialType((HttpClientCredentialType)5);
			val.get_Security().get_Transport().set_ProxyCredentialType((HttpProxyCredentialType)0);
			val.get_Security().get_Transport().set_Realm(string.Empty);
			val.get_Security().get_Message().set_ClientCredentialType((BasicHttpMessageCredentialType)0);
			val.get_Security().get_Message().set_AlgorithmSuite(SecurityAlgorithmSuite.get_Default());
			val.set_MaxReceivedMessageSize(2147483647L);
			val.set_MaxBufferSize(int.MaxValue);
			val.get_ReaderQuotas().set_MaxStringContentLength(int.MaxValue);
			return (Binding)(object)val;
		}

		private EndpointAddress CriarEndPoint(string endereco)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			return new EndpointAddress(endereco);
		}

		public Proxy()
			: this()
		{
		}
	}
}
