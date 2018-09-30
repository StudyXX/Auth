using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace CookieSample2
{
    public class MyDataProtector : IDataProtector
    {
        private string _prupose;

        public MyDataProtector() : this(null)
        { }
        public MyDataProtector(string purpose)
        {
            _prupose = purpose;
        }


        public IDataProtector CreateProtector(string purpose)
        {
            _prupose = purpose;
            //return new MyDataProtector(purpose);
            return this;
        }

        public byte[] Protect(byte[] plaintext)
        {
            return plaintext;
        }

        public byte[] Unprotect(byte[] protectedData)
        {
            return protectedData;
        }
    }
}
