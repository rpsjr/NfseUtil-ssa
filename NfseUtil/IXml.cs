using System.Xml;

namespace NfseUtil
{
	public interface IXml
	{
		string IdentarXmlString(string xml);

		string IdentarXmlDocument(XmlDocument doc);

		string CanonicalizarXmlString(string xml);

		string CanonicalizarXmlDocument(XmlDocument doc);

		string AssinarXmlString(string xml, string tagAssinatura, string repositorio, string nomeCertificado);

		void AssinarXmlDocument(XmlDocument doc, string tagAssinatura, string repositorio, string nomeCertificado);

		bool ValidarAssinaturaXmlString(string xml);

		bool ValidarAssinaturaXmlDocument(XmlDocument doc);

		bool ValidarEstruturaXmlString(string xml, string xsl, out string erros);
	}
}
