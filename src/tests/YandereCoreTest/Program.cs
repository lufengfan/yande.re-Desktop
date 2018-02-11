using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Yandere.Data.Json;

namespace YandereCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            
            client.GetAsync(new Uri("https://yande.re/post.json?page=50&tags=cum"))
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    response.Content.ReadAsStringAsync()
                        .ContinueWith(_task =>
                        {
                            var posts = JsonConvert.DeserializeObject<post_json[]>(_task.Result);
                            ;
                        });

                });

#if false
            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri("https://yande.re/"));
            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            CookieCollection cookies = cookieContainer.GetCookies(request.RequestUri);
            response.Close();

            cookieContainer.Add(request.RequestUri, new Cookie("login", ""));
            cookieContainer.Add(request.RequestUri, new Cookie("pass_hash", ""));

            request = HttpWebRequest.CreateHttp(new Uri("https://yande.re/user/home"));
            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string source = reader.ReadToEnd();
                ;
            }

            string source = client.GetAsync(new Uri("https://yande.re/user/home")).Result.Content.ReadAsStringAsync().Result;
            ;
            
            client.GetAsync(new Uri("https://yande.re/user/login"))
                .ContinueWith(
                    task =>
                    {
                        var response = task.Result;
                        var statusCode = response.StatusCode;
                        var content = response.Content;
                        return content.ReadAsStringAsync().ContinueWith(
                            _task =>
                            {
                                string html = _task.Result;
                                HtmlDocument document = new HtmlDocument();
                                document.LoadHtml(html);
                                HtmlNode meta = document.DocumentNode.SelectSingleNode("html/head/meta[@name='csrf-token']");
                                return new
                                {
                                    document,
                                    authenticity_token = meta.GetAttributeValue("content", string.Empty)
                                };
                            }
                        ).Result;
                    }
                )
                .ContinueWith(
                    task =>
                    {
                        const string userName = "";
                        const string userPwd = "";

                        HttpContent _content = new FormUrlEncodedContent(
                            new Dictionary<string, string>()
                            {
                                { "authenticity_token", task.Result.authenticity_token },
                                { "url", task.Result.document.GetElementbyId("url").GetAttributeValue("value", string.Empty) },
                                { "user[name]", userName },
                                { "user[password]", userPwd }
                            }
                        );
                        client.PostAsync("https://yande.re/user/authenticate", _content)
                            .ContinueWith(
                                _task =>
                                {
                                    var response = _task.Result;
                                    var statusCode = response.StatusCode;
                                    var content = response.Content;
                                    content.ReadAsStringAsync().ContinueWith(
                                        __task =>
                                        {
                                            string html = __task.Result;
                                            HtmlDocument document = new HtmlDocument();
                                            document.LoadHtml(html);
                                        }
                                    );
                                }
                            );
                    }
                );
#endif

            Console.WriteLine("按任意键退出");
            Console.ReadKey(false);
        }
    }
}
