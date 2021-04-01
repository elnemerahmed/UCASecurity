using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASecurity.Encryption.Base
{
    public abstract class Algorithm<T, E>
    {
        public abstract Result<E> Encrypt(T text, string key);
        public abstract Result<E> Decrypt(T cipher, string key);
        public abstract bool Health();
    }
}
