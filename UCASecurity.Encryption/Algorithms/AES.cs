using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCASecurity.Encryption.Base;

namespace UCASecurity.Encryption.Algorithms
{
    public class AES : Algorithm<string, string, string>
    {
        public string AlgorithmName { get; set; }
        public AES(string AlgorithmName)
        {
			this.AlgorithmName = AlgorithmName;
		}
		private  Result<ParametersWithIV> SetUpKey(string key)
		{
			try
			{

				byte[] inputKey = Convert.FromBase64String(key);
				byte[] iv = Hex.Decode(Constants.IV);
				KeyParameter keyParam = ParameterUtilities.CreateKeyParameter("AES", inputKey);

				ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, iv);

				return new Result<ParametersWithIV>() { status = StatusCode.OK, payload = keyParamWithIV };
			}
			catch (Exception)
			{
				return new Result<ParametersWithIV>() { status = StatusCode.Error, payload = null };
			}
		}
		public override Result<string> Decrypt(string cipher, string key)
		{
			try
			{
				var keyParamWithIv = SetUpKey(key);

				byte[] C = Convert.FromBase64String(cipher);
				IBufferedCipher outCipher = CipherUtilities.GetCipher(AlgorithmName);

				outCipher.Init(false, keyParamWithIv.payload);

				byte[] dec = outCipher.DoFinal(C);

				string decryptedInput = Convert.ToBase64String(dec);

				return new Result<string>() { status = StatusCode.OK, payload = decryptedInput };
			}
			catch (Exception e)
			{
				return new Result<string>()
				{
					status = StatusCode.Error,
					payload = string.Empty
				};
			}
		}
		public override Result<string> Encrypt(string text, string key)
		{
			try
			{
				var keyParamWithIv = SetUpKey(key);

				byte[] P = Convert.FromBase64String(text);
				IBufferedCipher inCipher = CipherUtilities.GetCipher(AlgorithmName);

				inCipher.Init(true, keyParamWithIv.payload);

				byte[] enc = inCipher.DoFinal(P);

				string encryptedInput = Convert.ToBase64String(enc);
				return new Result<string>() { status = StatusCode.OK, payload = encryptedInput };

			}
			catch (Exception e)
			{
				return new Result<string>() { status = StatusCode.Error, payload = string.Empty };
			}
		}
		public override bool Health()
		{
			try
			{
				var cipherResult = Encrypt(Constants.Input, Constants.Input);
				if (cipherResult.status == StatusCode.Error)
				{
					throw new Exception();
				}

				var textResult = Decrypt(cipherResult.payload, Constants.Input);
				if (textResult.status == StatusCode.Error)
				{
					throw new Exception();
				}
				return textResult.payload.Equals(Constants.Input);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}












/*
This Code is vaild for :: 

"AES/OFB/NoPadding",
"AES/CFB/NoPadding",
"AES/EAX/NoPadding"
"AES/GCM/NoPadding"
"AES/CCM/NoPadding"
*/