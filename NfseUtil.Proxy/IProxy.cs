namespace NfseUtil.Proxy
{
	public interface IProxy
	{
		bool AtribuirCertificadoDigital(string repositorio, string nomeCertificado);

		string ConsultarLoteRps(string loteXml);

		string ConsultarLoteRpsUrl(string loteXml, string url);

		string ConsultarNfse(string consultaXml);

		string ConsultarNfseRPS(string consultaXml);

		string ConsultarNfseRPSUrl(string consultaXml, string url);

		string ConsultarNfseUrl(string consultaXml, string url);

		string ConsultarSituacaoLoteRPS(string loteXml);

		string ConsultarSituacaoLoteRPSUrl(string loteXml, string url);

		string ConsultarSituacaoNfse(string consultaXml);

		string ConsultarSituacaoNfseUrl(string consultaXml, string url);

		string EnviarLoteRPS(string loteXml);

		string EnviarLoteRPSComplementar(string loteXml, string dadosComplementaresXml);

		string EnviarLoteRPSComplementarUrl(string loteXml, string dadosComplementaresXml, string url);

		string EnviarLoteRPSUrl(string loteXml, string url);
	}
}
