using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASecurity.Encryption.Base
{
    public abstract class Algorithm
    {
        public abstract Result Encrypt(string text, string key);
        public abstract Result Decrypt(string cipher, string key);
        public abstract bool Health();
    }
}
