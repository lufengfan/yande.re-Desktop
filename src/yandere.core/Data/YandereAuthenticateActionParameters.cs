using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereAuthenticateActionParameters : YandereActionParameters
    {
        public const string ParamName_UserName = "user[name]";
        public const string ParamName_UserPassword = "user[password]";
        
        public string UserName
        {
            get => (string)this[ParamName_UserName];
            set => this[ParamName_UserName] = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string UserPassword
        {
            get => (string)this[ParamName_UserPassword];
            set => this[ParamName_UserPassword] = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected YandereAuthenticateActionParameters() : base(2) { }

        protected YandereAuthenticateActionParameters(string userName, string userPassword)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            if (userPassword == null) throw new ArgumentNullException(nameof(userPassword));

            this.AddParameter(ParamName_UserName, userName);
            this.AddParameter(ParamName_UserPassword, userPassword);
        }
    }
}
