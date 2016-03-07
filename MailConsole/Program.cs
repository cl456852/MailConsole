using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MasterSoft.WinUI;
using System.Threading;

namespace MailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           // DoGetHostAddresses("PC-201210302211");
            //GetIP();
         //   ThunderMonitor tm=new ThunderMonitor();
            Program p = new Program();
           // ProcessMoitor processMonitor = new ProcessMoitor();
           // Thread thread = new Thread(processMonitor.start);
           // thread.Start();
           // Thread thread1 = new Thread(tm.start);
           // thread1.Start();
            while (true)
            {
                p.sendMail();
                Thread.Sleep(60* 1000*15);
            }
        }

        void sendMail()
        {
            Mail mail = new Mail();
            mail.ReceiverAddess = "330998190@qq.com";
            mail.Subject = "MyIP";
            mail.Body = (GetIP());
            try
            {
                mail.Send();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DoGetHostAddresses(string hostname)
        {
            IPAddress[] ips;

            ips = Dns.GetHostAddresses(hostname);

            Console.WriteLine("GetHostAddresses({0}) returns:", hostname);

            foreach (IPAddress ip in ips)
            {
                Console.WriteLine("    {0}", ip);
            }
        }

        //获取本机的公网IP
        private static string GetIP()
        {
            string tempip = "";
            try
            {
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.ip.cn");
                wr.Host = "www.ip.cn";
                wr.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("?code>") + 1;
                int end = all.IndexOf("</code>", start);
                tempip = DateTime.Now + "   " + all.Substring(start, end - start) + "      rocessMoitor processMonitor = new ProcessMoitor();";
                Console.WriteLine(tempip);
                sr.Close();
                s.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return  tempip;
        }
    }
}
