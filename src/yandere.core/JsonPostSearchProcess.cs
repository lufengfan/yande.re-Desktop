using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Yandere.Data;

namespace Yandere
{
    public class JsonPostSearchProcess : PostSearchProcess
    {
        protected internal override IEnumerable<YanderePostPreview> SearchInternal(params string[] tags)
        {
            string tagStr;
            if (tags == null) tagStr = string.Empty;
            else tagStr = string.Join("+", tags);

            HttpClient client = new HttpClient();


            string url = @"https://yande.re/post.json";
            var queryDictionary = new Dictionary<string, object>();
            queryDictionary.Add("page", 0);
            if (tagStr != string.Empty)
                queryDictionary.Add("tag", HttpUtility.UrlEncode(tagStr));

            for (int page = 1; true; page++)
            {
                queryDictionary["page"] = page;
                string queryString = string.Join("&", queryDictionary.Select(pair => $"{HttpUtility.UrlEncode(pair.Key)}={pair.Value}"));


            }
        }
    }
}
