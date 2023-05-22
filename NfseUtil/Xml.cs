using System;
using System.EnterpriseServices;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace NfseUtil
{
	[ClassInterface(ClassInterfaceType.None)]
	public sealed class Xml : ServicedComponent, IXml
	{
		private XmlTextReader Reader;

		private string xmlValidationErrors = string.Empty;

		public string IdentarXmlString(string xml)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			XmlDocument val = new XmlDocument();
			val.LoadXml(xml);
			return IdentarXmlDocument(val);
		}

		public string IdentarXmlDocument(XmlDocument doc)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Position = 0L;
			XmlTextWriter val = new XmlTextWriter((Stream)memoryStream, Encoding.Unicode);
			val.set_Formatting((Formatting)1);
			((XmlNode)doc).WriteContentTo((XmlWriter)(object)val);
			((XmlWriter)val).Flush();
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream);
			return streamReader.ReadToEnd();
		}

		public string CanonicalizarXmlString(string xml)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			XmlDocument val = new XmlDocument();
			val.LoadXml(xml);
			return CanonicalizarXmlDocument(val);
		}

		public string CanonicalizarXmlDocument(XmlDocument doc)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			XmlDsigC14NTransform val = new XmlDsigC14NTransform();
			XmlDocument val2 = new XmlDocument();
			XmlDeclaration val3 = null;
			string text = null;
			if (((XmlNode)doc).get_FirstChild() is XmlDeclaration)
			{
				val3 = (XmlDeclaration)((XmlNode)doc).get_FirstChild();
			}
			((Transform)val).LoadInput((object)doc);
			using (MemoryStream memoryStream = (MemoryStream)((Transform)val).GetOutput(typeof(MemoryStream)))
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
				text = Encoding.Default.GetString(memoryStream.ToArray());
			}
			val2.LoadXml(text);
			if (val3 != null)
			{
				val3 = val2.CreateXmlDeclaration(val3.get_Version(), val3.get_Encoding(), val3.get_Standalone());
				XmlElement documentElement = val2.get_DocumentElement();
				((XmlNode)val2).InsertBefore((XmlNode)(object)val3, (XmlNode)(object)documentElement);
			}
			return ((XmlNode)val2).get_InnerXml();
		}

		public string AssinarXmlString(string xml, string tagAssinatura, string repositorio, string nomeCertificado)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			XmlDocument val = new XmlDocument();
			val.set_PreserveWhitespace(true);
			val.LoadXml(xml);
			AssinarXmlDocument(val, tagAssinatura, repositorio, nomeCertificado);
			return ((XmlNode)val).get_OuterXml();
		}

		public void AssinarXmlDocument(XmlDocument doc, string TagAssinatura, string LocalRepositorio, string NomeCertificado)
		{
			X509Certificate2 certificadoX = Certificado.ObterCertificado(LocalRepositorio, NomeCertificado);
			AssinarXml(doc, TagAssinatura, certificadoX);
		}

		public void AssinarXmlDocument(XmlDocument doc, string TagAssinatura, string LocalRepositorio, string NomeCertificado, string NomeRepositorio)
		{
			X509Certificate2 certificadoX = Certificado.ObterCertificado(LocalRepositorio, NomeCertificado, NomeRepositorio);
			AssinarXml(doc, TagAssinatura, certificadoX);
		}

		private void AssinarXml(XmlDocument doc, string tagAssinatura, X509Certificate2 certificadoX509)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			KeyInfoClause val = (KeyInfoClause)new RSAKeyValue((RSA)certificadoX509.get_PrivateKey());
			KeyInfo val2 = new KeyInfo();
			KeyInfoX509Data val3 = new KeyInfoX509Data((X509Certificate)(object)certificadoX509);
			val3.AddSubjectName(certificadoX509.get_SubjectName().get_Name().ToString());
			val2.AddClause((KeyInfoClause)(object)val3);
			val2.AddClause(val);
			XmlDsigEnvelopedSignatureTransform val4 = new XmlDsigEnvelopedSignatureTransform();
			XmlNodeList elementsByTagName = doc.GetElementsByTagName(tagAssinatura);
			foreach (XmlNode item in elementsByTagName)
			{
				XmlNode val5 = item;
				XmlNode val6 = val5;
				string value = ((XmlNode)val6.get_FirstChild().get_Attributes().get_ItemOf("id")).get_Value();
				if (value != null && value.Trim().Length > 0)
				{
					SignedXml val7 = new SignedXml(doc);
					val7.set_SigningKey(certificadoX509.get_PrivateKey());
					val7.set_KeyInfo(val2);
					Reference val8 = new Reference("#" + value);
					val8.AddTransform((Transform)(object)val4);
					val7.get_SignedInfo().AddReference(val8);
					val7.ComputeSignature();
					XmlElement xml = val7.GetXml();
					val6.AppendChild((XmlNode)(object)xml);
				}
			}
		}

		public bool ValidarAssinaturaXmlString(string xml)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			XmlDocument val = new XmlDocument();
			val.set_PreserveWhitespace(true);
			val.LoadXml(xml);
			return ValidarAssinaturaXmlDocument(val);
		}

		public bool ValidarAssinaturaXmlDocument(XmlDocument doc)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			XmlNodeList elementsByTagName = doc.GetElementsByTagName("Signature");
			foreach (XmlNode item in elementsByTagName)
			{
				XmlNode val = item;
				SignedXml val2 = new SignedXml(doc);
				val2.LoadXml((XmlElement)val);
				if (!val2.CheckSignature())
				{
					return false;
				}
			}
			return true;
		}

		public bool ValidarEstruturaXmlString(string pXml, string xsl, out string erros)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Expected O, but got Unknown
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			try
			{
				erros = null;
				XmlReaderSettings val = new XmlReaderSettings();
				XmlTextReader val2 = new XmlTextReader(xsl);
				StringReader val3 = new StringReader(pXml);
				Reader = new XmlTextReader((TextReader)(object)val3);
				XmlUrlResolver val4 = new XmlUrlResolver();
				val.set_ProhibitDtd(false);
				((XmlResolver)val4).set_Credentials(CredentialCache.get_DefaultCredentials());
				val.set_XmlResolver((XmlResolver)(object)val4);
				val.set_ValidationFlags((XmlSchemaValidationFlags)2);
				val.set_ValidationFlags((XmlSchemaValidationFlags)(val.get_ValidationFlags() | 4));
				val.get_Schemas().set_XmlResolver((XmlResolver)(object)val4);
				val.get_Schemas().Add((string)null, (XmlReader)(object)val2);
				val.get_Schemas().Compile();
				val.set_ValidationType((ValidationType)4);
				val.add_ValidationEventHandler(new ValidationEventHandler(ReaderSettings_ValidationEventHandler));
				XmlReader val5 = XmlReader.Create((XmlReader)(object)Reader, val);
				while (val5.Read())
				{
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				throw ex;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
			if (!string.IsNullOrEmpty(xmlValidationErrors))
			{
				erros = xmlValidationErrors;
				return false;
			}
			return true;
		}

		private void ReaderSettings_ValidationEventHandler(object sender, ValidationEventArgs args)
		{
			object obj = xmlValidationErrors;
			xmlValidationErrors = string.Concat(obj, "Linha: ", Reader.get_LineNumber(), " - Posição: ", Reader.get_LinePosition(), " - ", args.get_Message(), "\r\n");
			xmlValidationErrors += Environment.NewLine;
		}

		public Xml()
			: this()
		{
		}
	}
}
