using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YandereAction
    {
        protected abstract HttpClient HttpClient { get; }
        
        public YandereActionParameters Parameters { get; protected set; }

        protected abstract Uri GetBaseUri();

        protected YandereAction()
        {
            this.ParameterProcess += this.ParameterProcessTrunk;
        }

        public event YandereActionParameterProcessHandler<object> ParameterProcess;

        /// <summary>
        /// 引发 <see cref="ParameterProcess"/> 事件。
        /// </summary>
        /// <param name="e"><see cref="ParameterProcess"/> 事件参数。</param>
        protected virtual void OnParameterProcess(YandereActionParameterProcessArgs<object> e) =>
            this.ParameterProcess?.Invoke(this, e);

        protected virtual void ParameterProcessTrunk(object sender, YandereActionParameterProcessArgs<object> e) { }

        public virtual YandereActionResponse DoAction() => this.DoActionAsync().Result;

        public abstract Task<YandereActionResponse> DoActionAsync();

        public virtual YandereActionResponse DoAction(CancellationToken token) => this.DoActionAsync(token).Result;

        public abstract Task<YandereActionResponse> DoActionAsync(CancellationToken token);

        protected abstract YandereActionResponse ParseRawResponse(HttpResponseMessage httpResponse);
    }
}
