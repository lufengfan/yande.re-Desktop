using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public sealed class YandereQualifierTag : YandereTag
    {
        private string introducerName;
        private string introducerValue;

        public string IntroducerName => this.introducerName;
        public string IntroducerValue => this.introducerValue;

        public override string Value => $"{this.IntroducerName}:{this.IntroducerValue}";
    }
}
