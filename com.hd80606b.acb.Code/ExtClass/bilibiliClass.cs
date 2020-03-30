using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.hd80606b.cq.Code.ExtClass
{
    class bilibiliClass
    {

        public class Rootobject
        {
            public int code { get; set; }
            public string message { get; set; }
            public int ttl { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public int aid { get; set; }
            public string bvid { get; set; }
            public int view { get; set; }
            public int danmaku { get; set; }
            public int reply { get; set; }
            public int favorite { get; set; }
            public int coin { get; set; }
            public int share { get; set; }
            public int like { get; set; }
            public int now_rank { get; set; }
            public int his_rank { get; set; }
            public int no_reprint { get; set; }
            public int copyright { get; set; }
            public string argue_msg { get; set; }
            public string evaluation { get; set; }
        }

    }
}
