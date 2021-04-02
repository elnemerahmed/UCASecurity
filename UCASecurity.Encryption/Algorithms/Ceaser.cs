using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCASecurity.Encryption.Base;

namespace UCASecurity.Encryption.Algorithms
{
    public class Ceaser : Algorithm<string, int, string>
    {
        public override Result<string> Decrypt(string cipher, int key)
        {
            throw new NotImplementedException();
        }

        public override Result<string> Encrypt(string text, int key)
        {
            throw new NotImplementedException();
        }

        public override bool Health()
        {
            throw new NotImplementedException();
        }
    }
}
