using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Site
{
    using Blog.Common;
    using System.Drawing;

    /// <summary>
    /// 负责生产验证码图片响应回浏览器
    /// </summary>
    public class vcode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //IIS中的MIME类型中的.jpg对应的类型
            context.Response.ContentType = "image/jpeg";

            //1.0 实例一个图片对象
            using (Image img = new Bitmap(60, 25))
            {
                //2.0 在img对象上定义画家
                using (Graphics g = Graphics.FromImage(img))
                {
                    //以白色来填充图片的背景色
                    g.Clear(Color.White);

                    //给图片画边框,矩形
                    g.DrawRectangle(Pens.Blue, 0, 0, img.Width - 1, img.Height - 1);

                    //增加干扰点(噪点) 来防止人们通过程序自动识别验证码
                    DrawLine(20, g, img);

                    string vcode = GetVcode(4); //获取四个长度的验证码文本
                    //将验证码存入session中
                    context.Session[Keys.vcode] = vcode;

                    //3.0 开始利用画家将验证码画到图片上  ||:逻辑运算符或  |:位运算符或 
                    g.DrawString(
                        vcode
                        , new Font("黑体", 16, FontStyle.Italic | FontStyle.Bold | FontStyle.Strikeout)  //当前字体为黑体加粗倾斜并且加上中横线
                        , new SolidBrush(Color.Red)  //验证码文字颜色为红色
                        , 0
                        , 0
                        );
                    //增加干扰点(噪点) 来防止人们通过程序自动识别验证码
                    DrawLine(20, g, img);
                }

                //4.0 将图片响应回浏览器
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// 画干扰点
        /// </summary>
        /// <param name="p"></param>
        /// <param name="g"></param>
        /// <param name="img"></param>
        private void DrawLine(int p, Graphics g, Image img)
        {
            Point p1;
            Point p2;
            int x;
            int y;

            for (int i = 0; i < p; i++)
            {
                x = r.Next(img.Width);
                y = r.Next(img.Height);
                p1 = new Point(x, y);
                p2 = new Point(x + 1, y + 1);
                g.DrawLine(Pens.Blue, p1, p2);
            }
        }

        Random r = new Random();
        string GetVcode(int count)
        {
            string res = "";
            string[] codeArr = { "A", "B", "C", "D", "2", "3", "4" };
            for (int i = 0; i < count; i++)
            {
                res += codeArr[r.Next(codeArr.Length - 1)];
            }

            return res;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}