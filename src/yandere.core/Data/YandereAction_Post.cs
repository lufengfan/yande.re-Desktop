using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereAction_Post : YandereAction
    {
        protected override HttpClient HttpClient { get; } = new HttpClient();

        protected YandereAction_Post() : base() { }
        
        public override Task<YandereActionResponse> DoActionAsync()
        {
            return this.HttpClient.PostAsync(this.GetBaseUri(), this.GetHttpContent())
                .ContinueWith(task => this.ParseRawResponse(task.Result));
        }

        public override Task<YandereActionResponse> DoActionAsync(CancellationToken token)
        {
            return this.HttpClient.PostAsync(this.GetBaseUri(), this.GetHttpContent(), token)
                .ContinueWith(task => this.ParseRawResponse(task.Result));
        }

        protected override void ParameterProcessTrunk(object sender, YandereActionParameterProcessArgs<object> e)
        {
            ((IDictionary<string, string>)e.BaseValue).Add(e.ParameterName, e.ParameterValue?.ToString() ?? string.Empty);

            base.ParameterProcessTrunk(sender, e);
        }

        protected virtual HttpContent GetHttpContent()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var parameter in this.Parameters)
                this.OnParameterProcess(new YandereActionParameterProcessArgs<object>(parameter.Key, parameter.Value, dictionary));

            return new FormUrlEncodedContent(dictionary);
        }
    }
}
