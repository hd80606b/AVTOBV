using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using com.hd80606b.cq.Code.ExtClass;
using Native.Sdk.Cqp;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;
using System.Web.Script.Serialization;

namespace com.hd80606b.acb.Code
{
    public class Event_GroupMessage : IGroupMessage
    {
        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender">事件来源</param>
        /// <param name="e">事件参数</param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            #region---AV号与BV号的转换---
            if (e.Message.Text.Contains("bilibili.com/video/BV"))
            {
                {
                    try
                    {
                        string bv_replace = "/BV(.){9,10}";
                        string bv = System.Text.RegularExpressions.Regex.Match(e.Message.Text, bv_replace).ToString();
                        bv = bv.Replace("/", "");
                        WebClient wb = new WebClient();
                        byte[] DownloadData = wb.DownloadData("http://api.bilibili.com/x/web-interface/archive/stat?bvid=" + bv);
                        string EncodeStr = System.Text.Encoding.UTF8.GetString(DownloadData);
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        bilibiliClass.Rootobject root = js.Deserialize<bilibiliClass.Rootobject>(EncodeStr);
                        e.CQApi.SendGroupMessage(e.FromGroup, CQApi.CQCode_At(e.FromQQ), "AV号：av" + root.data.aid + "\nBV号：" + root.data.bvid + "\n播放量：" + root.data.view + "\n收藏量：" + root.data.favorite);
                    }
                    catch
                    {
                        e.CQApi.SendGroupMessage(e.FromGroup, CQApi.CQCode_At(e.FromQQ) + "哦豁，出错了。");
                        e.Handler = false;
                        return;
                    }
                }
            }

            if (e.Message.Text.Contains("bilibili.com/video/av"))
            {
                {
                    try
                    {
                        string av_replace = "/av(.){1,10}";
                        string av = System.Text.RegularExpressions.Regex.Match(e.Message.Text, av_replace).ToString();
                        av = av.Replace("/av", "");
                        WebClient wb = new WebClient();
                        byte[] DownloadData = wb.DownloadData("http://api.bilibili.com/x/web-interface/archive/stat?aid=" + av);
                        string EncodeStr = System.Text.Encoding.UTF8.GetString(DownloadData);
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        bilibiliClass.Rootobject root1 = js.Deserialize<bilibiliClass.Rootobject>(EncodeStr);
                        e.CQApi.SendGroupMessage(e.FromGroup, CQApi.CQCode_At(e.FromQQ), "AV号：av" + root1.data.aid + "\nBV号：" + root1.data.bvid + "\n播放量：" + root1.data.view + "\n收藏量：" + root1.data.favorite);
                    }
                    catch
                    {
                        e.CQApi.SendGroupMessage(e.FromGroup, CQApi.CQCode_At(e.FromQQ) + "哦豁，出错了。");
                        e.Handler = false;
                        return;
                    }
                }
            }
            #endregion
        }
    }
}
