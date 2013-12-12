using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
namespace XidongCaiService
{
    class CaiCore
    {
        string baseUrl = "http://xidong.net";
        Helper.IO.FileHelper fh = new Helper.IO.FileHelper();
        public void DoList()
        {
            string url = "http://xidong.net/List000/Catalog_67_T78.html";

            string content = fh.GetWebContents(url, Encoding.UTF8);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);
            HtmlNode root = doc.DocumentNode;
            HtmlNode node;
            for (int i = 1; i <= 50; i++)
            {
                node = doc.GetElementbyId("xdintrobg");
                node = node.SelectSingleNode("table/tr[" + i + "]");
                if (node == null) continue;
                node = node.SelectSingleNode("td[2]/a[1]");
                if (node != null)
                    Console.WriteLine(baseUrl + node.Attributes["href"].Value);
            }

         //   Console.WriteLine(content);

           // DoSingleContent("http://xidong.net/File001/File_8766.html");
        }

        private void DoSingleContent(string url)
        {
          //  url = "http://xidong.net/File001/File_8766.html";
            string content = fh.GetWebContents(url, Encoding.UTF8);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);
            HtmlNode root = doc.DocumentNode;
            string title = doc.GetElementbyId("xdintrobg").SelectSingleNode("h1").InnerText;
            Console.WriteLine(title);
            string contMain = Helper.String.StringHelper.SubStr(content, "<script type=\"text/javascript\" src=\"http://src.xidong.net/js/select.js\"></script>",
                "<div id=\"ggad-content-bottom\">"
                );
            contMain = contMain.Replace("<!-- google_ad_section_start -->", "");
            contMain = contMain.Replace("<!-- google_ad_section_end -->", "");
            Regex reg = new Regex("(?i)(?s)<script.*?</script>");
            contMain = reg.Replace(contMain, "");
             Console.WriteLine(contMain);

            string links = "";
            Dictionary<string, string> linkList = new Dictionary<string, string>();
            HtmlNode node = doc.GetElementbyId("emulelink");
            for (int i = 1; i <= 50; i++)
            {
                node = doc.GetElementbyId("emulelink");
                node = node.SelectSingleNode("table[1]/tr[" + i + "]");
                if (node != null)
                {
                    if (node.InnerText.IndexOf("用迅雷、eMule等软件下载") > -1) continue;
                    HtmlNode hn1 = node.SelectSingleNode("td[1]/a[1]");
                    if (hn1 != null)
                    {
                        string rs = "";
                        string href = hn1.Attributes["href"].Value;
                        string text = hn1.InnerText;
                        string size = "0";
                        rs += text + "$$";
                        HtmlNode hn2 = node.SelectSingleNode("td[2]");
                        if (hn2 != null)
                        {
                            size = hn2.InnerText;
                        }
                        rs += size + "$$";
                        rs += href;

                        Console.WriteLine(rs);
                    }
                }
            }






            //  Console.WriteLine(content);
        }

    }
}
