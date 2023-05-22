using System;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace NfseUtil
{
	internal class Certificado
	{
		public static X509Certificate2 ObterCertificadoPorSerial(string LocalRepositorio, string SerialCertificado, string NomeRepositorio)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			X509Store val = ((!(NomeRepositorio.ToUpper() == "USUARIO ATUAL")) ? new X509Store(LocalRepositorio, (StoreLocation)2) : new X509Store(LocalRepositorio, (StoreLocation)1));
			val.Open((OpenFlags)4);
			X509Certificate2Collection val2 = val.get_Certificates().Find((X509FindType)5, (object)SerialCertificado, false);
			if (((CollectionBase)val2).get_Count().CompareTo(1).Equals(0))
			{
				return val2.get_Item(0);
			}
			throw new Exception($"O certificado com serial '{SerialCertificado}' não foi encontrado no repositório '{NomeRepositorio}'-'{LocalRepositorio}' do sistema.");
		}

		public static X509Certificate2 ObterCertificado(string LocalRepositorio, string NomeCertificado)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			X509Store val = new X509Store(LocalRepositorio, (StoreLocation)2);
			val.Open((OpenFlags)4);
			X509Certificate2Collection val2 = val.get_Certificates().Find((X509FindType)1, (object)NomeCertificado, false);
			if (((CollectionBase)val2).get_Count().CompareTo(1).Equals(0))
			{
				return val2.get_Item(0);
			}
			throw new Exception($"O certificado o nome '{NomeCertificado}' não foi encontrado no repositório '{LocalRepositorio}' do sistema.");
		}

		public static X509Certificate2 ObterCertificado(string LocalRepositorio, string NomeCertificado, string NomeRepositorio)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			X509Store val = ((!(NomeRepositorio.ToUpper() == "USUARIO ATUAL")) ? new X509Store(LocalRepositorio, (StoreLocation)2) : new X509Store(LocalRepositorio, (StoreLocation)1));
			val.Open((OpenFlags)4);
			X509Certificate2Collection val2 = val.get_Certificates().Find((X509FindType)1, (object)NomeCertificado, false);
			if (((CollectionBase)val2).get_Count().CompareTo(1).Equals(0))
			{
				return val2.get_Item(0);
			}
			throw new Exception($"O certificado com o nome '{NomeCertificado}' não foi encontrado no repositório '{NomeRepositorio}'-'{LocalRepositorio}' do sistema.");
		}

		public static RSACryptoServiceProvider ObterChavePrivada()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			CspParameters val = new CspParameters();
			val.KeyContainerName = "Root";
			val.ProviderName = "SafeSign Standard Cryptographic Service Provider";
			SecureString keyPassword = new SecureString();
			val.set_KeyPassword(keyPassword);
			val.KeyNumber = 2;
			val.ProviderType = 1;
			val.set_Flags((CspProviderFlags)65);
			return new RSACryptoServiceProvider(val);
		}
	}
}
