using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereLoggingInParameters : YandereActionParameters
    {
        public const string ParamName_UserName = "login";
        public const string ParamName_UserPasswordHash = "password_hash";

        public const string UserPasswordWrapFormat = "choujin-steiner--{0}--";

        public string UserName
        {
            get => (string)this[ParamName_UserName];
            set => this[ParamName_UserName] = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        public string UserPasswordHash
        {
            get => (string)this[ParamName_UserPasswordHash];
            set => this[ParamName_UserPasswordHash] = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        protected YandereLoggingInParameters() : base(2) { }

        protected YandereLoggingInParameters(string userName, string userPassword)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            if (userPassword == null) throw new ArgumentNullException(nameof(userPassword));

            this.AddParameter(ParamName_UserName, userName);
            this.AddParameter(ParamName_UserPasswordHash, YandereLoggingInParameters.ComputeUserPasswordHash(userPassword));
        }

        public static string ComputeUserPasswordHash(string userPassword)
        {
            if (userPassword == null) throw new ArgumentNullException(nameof(userPassword));

            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                Encoding encoding = Encoding.UTF8;
                string pwd_wrap = string.Format(UserPasswordWrapFormat, userPassword);
                byte[] buffer = encoding.GetBytes(pwd_wrap);
                byte[] hash = sha1.ComputeHash(buffer);
                sha1.Clear();
                string pwd_hash = BitConverter.ToString(hash).Replace("-", string.Empty);

                return pwd_hash;
            }
        }
    }
}
