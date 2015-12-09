﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwb.Crawler.Contract.Model
{
    public class LwbInput
    {
        public int Type { get; set; }
        public object Data { get; set; }
    }

    public class Input获取生产线任务列表
    {
        public int TaskMax { get; set; }
        public List<string> RuningTaskHost { get; set; }
    }
}
