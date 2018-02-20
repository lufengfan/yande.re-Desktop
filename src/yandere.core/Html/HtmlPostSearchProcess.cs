using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Yandere.Data;
using Yandere.Data.Html;

namespace Yandere.Html
{
    [Obsolete]
    public class HtmlPostSearchProcess : PostSearchProcess
    {
        protected internal override IEnumerable<YanderePostPreview> SearchInternal(YandereTagCollection tags)
        {
            string tagStr = tags.ToString();
            
            string url = @"https://yande.re/post";
            var queryDictionary = new Dictionary<string, object>();
            queryDictionary.Add("page", 0);
            if (tagStr != string.Empty)
                queryDictionary.Add("tag", HttpUtility.UrlEncode(tagStr));

            for (int page = 1; true; page++)
            {
                queryDictionary["page"] = page;
                string queryString = string.Join("&", queryDictionary.Select(pair => $"{HttpUtility.UrlEncode(pair.Key)}={pair.Value}"));
#if false
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(System.IO.File.ReadAllText("[]_1.html"));
#else
                HtmlDocument document = new HtmlWeb().Load($@"{url}?{queryString}");
#endif
                HtmlNode postListNode = document.GetElementbyId("post-list-posts");
                if (postListNode == null)
                    // 此页无搜索结果。
                    yield break;
                else
                {
                    Regex postIDRegex = new Regex(@"^p(?<post_id>\d+?)$", RegexOptions.Compiled);
                    Regex sizeRegex = new Regex(@"^(?<x>\d+)\s+x\s+(?<y>\d+)$");
                    Regex tagsRegex = new Regex(@"^yande.re\s+\d+\s*(?<Tags>(\s*\S+)*?)$");
                    foreach (HtmlNode listItem in postListNode.Elements("li"))
                    {
                        Match postIDMatch = postIDRegex.Match(listItem.Id);
                        Uri previewImageUri = new Uri(
                            listItem.Element("div").Element("a").Element("img").GetAttributeValue("src", null)
                        );
                        Match sizeMatch = sizeRegex.Match(
                            listItem.Elements("a")
                                .First(a =>
                                    a.HasClass("directlink")// && a.HasClass("largeimg")
                                )
                                .Elements("span")
                                .First(span => span.HasClass("directlink-res"))
                                .InnerText
                                .Trim()
                        );
                        string img_url = listItem.Elements("a")
                            .First(a =>
                                a.HasClass("directlink")// && a.HasClass("largeimg")
                            )
                            .GetAttributeValue("href", string.Empty)
                            .Trim();
                        Match tagsMatch = tagsRegex.Match(HttpUtility.UrlDecode(System.IO.Path.GetFileNameWithoutExtension(img_url)));

                        if (postIDMatch.Success && sizeMatch.Success && tagsMatch.Success)
                        {
                            uint id = uint.Parse(postIDMatch.Groups["post_id"].Value);
                            yield return new YanderePostPreview(id, previewImageUri,
                                new Size(
                                    int.Parse(sizeMatch.Groups["x"].Value),
                                    int.Parse(sizeMatch.Groups["y"].Value)
                                ),
                                YandereTagCollection.Parse(tagsMatch.Groups["Tags"].Value),
                                new Lazy<YanderePost>(() => HtmlYanderePost.GetPost(id))
                            );
                        }
                    }
                }
            }
        }
    }
}
