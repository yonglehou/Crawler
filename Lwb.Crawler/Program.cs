﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lwb.Crawler.Contract.Model;
using Lwb.Crawler.Server;

namespace Lwb.Crawler
{
    static class Program
    {
        /// <summary>
        /// 爬虫的心跳                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        /// </summary>
        private static System.Timers.Timer mTimer;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //爬虫每隔5秒钟执行一次
            mTimer = new System.Timers.Timer(5000);
            mTimer.Elapsed += new System.Timers.ElapsedEventHandler(mTimer_Elapsed);
            mTimer.Start();
            //CrawlerManager.DbAdapter();

            Application.Run(new FrmCrawler());
        }

        /// <summary>
        /// 爬虫的执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void mTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LwbResult sLwbResult = CrawlerManager.DbAdapter();

            Console.WriteLine(sLwbResult.ToString());
        }
    }
}
