using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public delegate void YandereActionParameterProcessHandler<T>(object sender, YandereActionParameterProcessArgs<T> e);

    public class YandereActionParameterProcessArgs<T>
    {
        private string parameterName;
        public string ParameterName => this.parameterName;

        private object parameterValue;
        public object ParameterValue => this.parameterValue;

        private T baseValue;
        public T BaseValue => this.baseValue;

        public YandereActionParameterProcessArgs(string parameterName, object parameterValue, T baseValue)
        {
            this.parameterName = parameterName ?? throw new ArgumentNullException(nameof(parameterName));
            this.parameterValue = parameterValue;
            this.baseValue = baseValue;
        }
    }
}
