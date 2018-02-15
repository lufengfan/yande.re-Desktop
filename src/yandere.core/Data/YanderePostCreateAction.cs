using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public abstract class YanderePostCreateAction : YandereAction_Post
    {
        protected YanderePostCreateAction(YanderePostCreateActionParameters parameters) : base() =>
            this.Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));

        protected override void ParameterProcessTrunk(object sender, YandereActionParameterProcessArgs<object> e)
        {
            MultipartFormDataContent content = (MultipartFormDataContent)e.BaseValue;

            if (e.ParameterName == YanderePostCreateActionParameters.ParamName_File)
                using (FileStream fs = File.OpenRead(((Uri)e.ParameterValue).AbsolutePath))
                {
                    MemoryStream ms = new MemoryStream();
                    const int length = 1048576; // 1MB
                    byte[] buffer = new byte[length];
                    int count = 0;
                    do
                    {
                        count = ms.Read(buffer, 0, length);
                        ms.Write(buffer, 0, count);
                    }
                    while (count > 0);

                    content.Add(new StreamContent(ms), e.ParameterName);
                }
            else
                content.Add(new StringContent(e.ParameterValue?.ToString() ?? string.Empty), e.ParameterName);

            base.ParameterProcessTrunk(sender, e);
        }
        
        protected override HttpContent GetHttpContent()
        {
            HttpContent content = this.GetBaseHttpContent();
            foreach (var parameter in this.Parameters)
                this.OnParameterProcess(new YandereActionParameterProcessArgs<object>(parameter.Key, parameter.Value, content));

            return content;
        }

        protected virtual HttpContent GetBaseHttpContent()
        {
            return new MultipartFormDataContent();
        }
    }
}
