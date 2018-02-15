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
using Yandere;
using Yandere.Data;
using Yandere.Data.Json;
using Yandere.Json;

namespace YandereCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
#if false
            const string user = "";
            const string pwd = "";
            const string pass_hash = "";

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            Func<string, byte[]> getBytes;
            Func<byte[], string> getString;

            string pwd_wrap = $"choujin-steiner--{pwd}--";
            Encoding encoding = Encoding.UTF8;

#if true
            getBytes = encoding.GetBytes;
            getString = bytes => BitConverter.ToString(bytes).Replace("-", string.Empty);
#else
            getBytes = encoding.GetBytes;
            getString = encoding.GetString;
#endif

            string pwd_hash = getString(sha1.ComputeHash(getBytes(pwd_wrap)));

            Console.WriteLine(pwd_hash);
            Console.WriteLine(string.Equals(pwd_hash, pass_hash, StringComparison.InvariantCultureIgnoreCase));
            ;
            sha1.Clear();
            ((IDisposable)sha1).Dispose();

            HttpClient client = new HttpClient();

            client.GetAsync(new Uri($"https://yande.re/post.json?page=50&tags=cum&login={user}&password_hash={pwd_hash}"))
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    var statusCode = task.Result.StatusCode;
                    response.Content.ReadAsStringAsync()
                        .ContinueWith(_task =>
                        {
                            var posts = JsonConvert.DeserializeObject<post_json[]>(_task.Result);
                            ;
                        });

                });

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
                        HttpContent _content = new FormUrlEncodedContent(
                            new Dictionary<string, string>()
                            {
                                //{ "authenticity_token", task.Result.authenticity_token },
                                //{ "url", task.Result.document.GetElementbyId("url").GetAttributeValue("value", string.Empty) },
                                { "user[name]", user },
#if true
                                { "user[password]", pwd }
#endif
                            }
                        );
                        client.PostAsync("https://yande.re/user/authenticate.json", _content)
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
            PostSearchProcess process = new JsonPostSearchProcess();
            var posts = process.SearchInternal(new YandereTagCollection());
            foreach (var post in posts)
                ;

            Console.WriteLine("按任意键退出");
            Console.ReadKey(false);
        }
    }
}
