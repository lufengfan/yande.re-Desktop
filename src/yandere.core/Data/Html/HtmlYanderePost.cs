using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Yandere.Data.Html
{
    public class HtmlYanderePost : YanderePost
    {
        public static readonly Uri PostHostUri = new Uri("https://yande.re/post/");

        public HtmlYanderePost(uint id)
        {
            this.ID = id;

            this.Load(id);
        }

        public async void Load(uint id)
        {
            HtmlDocument document = await Task.Run(() =>
            {
                HtmlDocument _document = null;
                int i = 0; // 重试次数。
                const int max_i = int.MaxValue; // 最大充实次数
                while (_document == null && i < max_i)
                {
                    try
                    {
                        new HtmlWeb().Load(
                            new Uri(HtmlYanderePost.PostHostUri, new Uri($"show/{id}", UriKind.Relative))
                        );
                        i++;
                    }
                    catch (Exception)
                    {
                        _document = null;
                        System.Threading.Thread.Sleep(5000);
                    }
                }

                return _document;
            });
            //if (document == null) return;
            HtmlNode tagListNode = document.GetElementbyId("tag-sidebar");
            Regex tagTypeRegex = new Regex(@"(?<=^tag-type-)(?<tag_type>\w+)(?=\s|$)", RegexOptions.Compiled);
            foreach (HtmlNode li in tagListNode.Elements("li"))
            {
                Match match = li.GetClasses()
                    .Select(classStr => tagTypeRegex.Match(classStr))
                    .Where(m => m.Success)
                    .DefaultIfEmpty(Match.Empty)
                    .First();
                if (match.Success)
                {
                    YandereTagType tagType = (YandereTagType)Enum.Parse(typeof(YandereTagType), match.Groups["tag_type"].Value, true);

                    string tag = li.Elements("a")
                        .Select(a => a.InnerText.Trim())
                        .FirstOrDefault(text =>
                            !(text == "?" || text == "+" || text == "-")
                        );
                    if (!string.IsNullOrEmpty(tag))
                        this.Tags.Add(new YandereTag(tag, tagType));
                }
            }

            HtmlNode post_viewNode = document.GetElementbyId("post-view");
            if (post_viewNode != null)
            {
                HtmlNode hierarchyNode = post_viewNode.Elements("div[not(@id)]")
                    .Where(div => div.HasClass("status-notice"))
                    .FirstOrDefault();
                if (hierarchyNode != null)
                {
                    var hierarchyPosts = hierarchyNode.Elements("a");
                    Regex postIDRegex = new Regex(@"^/post/show/(?<post_id>\d+)$", RegexOptions.Compiled);
                    YanderePost parsePost(string url)
                    {
                        Match match = postIDRegex.Match(url);
                        if (match.Success)
                            return HtmlYanderePost.GetPost(uint.Parse(match.Groups["post_id"].Value));
                        else
                            return null;
                    }

                    HtmlNode firstNode = hierarchyPosts.First();
                    if (firstNode.InnerText.Trim() == "parent post")
                    {
                        YanderePost post = parsePost(firstNode.GetAttributeValue("href", string.Empty));
                        if (post != null)
                            this.ParentPost = post;
                    }
                    else
                    {
                        this.HasChildren = true;
                        foreach (HtmlNode node in hierarchyPosts.Skip(1)) // 跳过第一个超链接。
                        {
                            YanderePost post = parsePost(node.GetAttributeValue("href", string.Empty));
                            if (post != null)
                                this.ChildPosts.Add(post);
                        }
                    }
                }
            }

            HtmlNode statsNode = document.GetElementbyId("stats");
            var statNodes = statsNode.Element("ul").Elements("li");
            Regex sizeRegex = new Regex(@"(?<x>\d+)x(?<y>\d+)", RegexOptions.Compiled);
            Regex postTimeRegex = new Regex(@"^(?<AbbreviatedWeekDayName>[A-Za-z]+)\s+(?<AbbreviatedMonthName>[A-Za-z]+)\s+(?<Day>\d+)\s+(?<Hour>\d+)\:(?<Minute>\d+)\:(?<Second>\d+)\s+(?<Year>\d+)$", RegexOptions.Compiled);
            foreach (HtmlNode statNode in statNodes)
            {
                string innerText = statNode.InnerText.Trim();
                string statName = innerText.Substring(0, innerText.IndexOf(":"));
                Match match;
                switch (statName)
                {
                    case "Id": break;
                    case "Posted":
                        string dateStr = statNode.Element("a").GetAttributeValue("title", string.Empty).Trim();
                        match = postTimeRegex.Match(dateStr);
                        this.PostTime = DateTime.Parse(
                            $"{match.Groups["AbbreviatedWeekDayName"]}, {match.Groups["Day"]} {match.Groups["AbbreviatedMonthName"]} {match.Groups["Year"]} {match.Groups["Hour"]}:{match.Groups["Minute"]}:{match.Groups["Second"]}"
                        );
                        break;
                    case "Size":
                        match = sizeRegex.Match(innerText);
                        this.Size = new Size(
                            int.Parse(match.Groups["x"].Value),
                            int.Parse(match.Groups["y"].Value)
                        );
                        break;
                    case "Source":

                        break;
                    case "Rating":

                        break;
                    case "Score":

                        break;
                    case "Favorited by":

                        break;
                    default: break;
                }
            }
        }
        
        public static YanderePost GetPost(uint id)
        {
            if (YanderePost.PostsCache.TryGetValue(id, out YanderePost post))
                return post;
            else
                return new HtmlYanderePost(id);
        }
    }
}
