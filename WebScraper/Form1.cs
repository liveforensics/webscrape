using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WebScraper
{
    public partial class Form1 : Form
    {
        public string targetUrl = @"https://www.spectator.co.uk/";
        public Form1()
        {
            InitializeComponent();
            ScrapeMe();
        }

        private void ScrapeBtn_Click(object sender, EventArgs e)
        {
            ScrapeMe();
        }
        private void ScrapeMe()
        {
            var response = CallUrl(targetUrl).Result;
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(response);

            var programmerLinks = htmlDoc.DocumentNode.Descendants("li")
                .Where(node => !node.GetAttributeValue("class", "").Contains("tocsection"))
                .ToList();


        }
        private Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(fullUrl);
            return response;
        }
    }
}
