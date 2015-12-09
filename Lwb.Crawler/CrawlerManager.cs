﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet4.Utilities;
using Lwb.Crawler;
using Lwb.Crawler.Contract.Crawl.Model;
using Lwb.Crawler.Contract.Model;
namespace Lwb.Crawler
{
    public class CrawlerManager
    {
        private static HttpHelper httpHelper;
        private static HttpItem item;
        private static HttpResult result;
        static CrawlerManager()
        {
            httpHelper = new HttpHelper();
            item = new HttpItem();
        }

        public static LwbResult DbAdapter()
        {
            LwbResult sLwbResult = WCFServer.GetCrawlTask(null);

            List<CrawlTask> sCrawlTaskList = sLwbResult.Data as List<CrawlTask>;
            if (sCrawlTaskList == null)
                return new LwbResult(LwbResultType.Error,"爬虫抓取返回数据格式错误");

            if (sCrawlTaskList.Count != 0)
            {
                Console.WriteLine("还没有任务哦");
            }

            return null;
        }

        public static void Adapter()
        {
            HainaResultInfo<List<CrawlTask>> sTaskList = WCFServer.HanaiProcess();
            if (sTaskList != null && sTaskList.Content.Count != 0)
            {
                foreach (var index in sTaskList.Content)
                {
                    ExecuteTask(index);
                }
            }
            else
            {
                Console.WriteLine("还没有任务哦");
            }
        }

        public static void ExecuteTask(object obj)
        {
            CrawlTask sCrawlTask = (CrawlTask)obj;

            CrawlResult sCrawlResult = new CrawlResult();

            foreach (var index in sCrawlTask.List)
            {
                item.URL = index.Url;
                item.Method = "get";

                result = httpHelper.GetHtml(item);

                sCrawlResult.PlotKey = sCrawlTask.PlotKey;
                sCrawlResult.LineID = sCrawlTask.LineID;

                sCrawlResult.List.Add(new CrawlResultDetail { ID = index.ID, Content = result.Html });
                //Console.WriteLine(result.Html);
            }

            WCFServer.SendCrawlResult(sCrawlResult);
        }
    }
}
