using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
namespace LitzWireAdmin
{
    public partial class Form1 : Form
    {


        Random rnd;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
        }
        

        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private void cmdGetQR_Click(object sender, EventArgs e)
        {
            string rand = RandomString(12);
            Console.WriteLine(rand);
            string authAPI = "https://www.authenticatorapi.com/pair.aspx?AppName=LitzPCB&AppInfo=JTAB&SecretCode="+RandomString(11);
            
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument html = web.Load(authAPI);
            Console.WriteLine(html.ParsedText);
            HtmlNodeCollection collection = html.DocumentNode.SelectNodes("//img");
            pictureBox1.ImageLocation = collection[0].Attributes["src"].Value;
        }
    
    }
}
