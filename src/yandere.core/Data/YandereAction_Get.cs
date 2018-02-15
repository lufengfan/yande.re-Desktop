using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereAction_Get : YandereAction
    {
        protected override HttpClient HttpClient { get; } = new HttpClient();

        protected YandereAction_Get() : base() { }

        public override Task<YandereActionResponse> DoActionAsync()
        {
            return this.HttpClient.GetAsync(this.GetBaseUri(), HttpCompletionOption.ResponseHeadersRead)
                .ContinueWith(task=>this.ParseRawResponse(task.Result));
        }

        public override Task<YandereActionResponse> DoActionAsync(CancellationToken token)
        {
            return this.HttpClient.GetAsync(this.GetBaseUri(), HttpCompletionOption.ResponseHeadersRead, token)
                .ContinueWith(task=>this.ParseRawResponse(task.Result));
        }

        protected override Uri GetBaseUri()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var parameter in this.Parameters)
                this.OnParameterProcess(new YandereActionParameterProcessArgs<object>(parameter.Key, parameter.Value, dictionary));

            return new Uri(string.Format("{0}?{1}",
                this.GetBaseUriWithoutQuery().GetLeftPart(UriPartial.Path),
                string.Join("&", dictionary.Select(pair => $"{Uri.EscapeDataString(pair.Key)}{Uri.EscapeDataString(pair.Value)}"))
            ), UriKind.RelativeOrAbsolute);
        }

        protected abstract Uri GetBaseUriWithoutQuery();
    }
}
