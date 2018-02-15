using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    public class JsonYandereChangeStateActionResponse : YandereChangeStateActionResponse
    {
        private response_json responseJObject;

        public override bool IsSuccess => this.responseJObject.success;
        public override string ReasonPhrase => this.responseJObject.reason;

        public JsonYandereChangeStateActionResponse(HttpResponseMessage httpResponse) : base(httpResponse) =>
            this.responseJObject = JsonConvert.DeserializeObject<response_json>(httpResponse.Content.ReadAsStringAsync().Result);
    }
}
