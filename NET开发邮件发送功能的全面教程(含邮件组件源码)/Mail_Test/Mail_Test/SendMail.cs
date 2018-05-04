using System;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

using Mail_Test.Mail;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;

namespace Mail_Test
{
    public partial class SendMail : Form
    {
        List<string> filePaths = null;
        List<string> FilePaths
        {
            get
            {
                if (filePaths == null)
                    filePaths = new List<string>();
                return filePaths;
            }
        }

        Stopwatch watch = new Stopwatch();

        // 为简便“实验三”跨线程读取数据，所以都先存储在本地变量上
        string m_to = String.Empty;
        string m_cc = String.Empty;
        string m_bcc = String.Empty;
        string m_Subject = String.Empty;
        string m_Body = String.Empty;

        public SendMail()
        {
            InitializeComponent();

            // 默认为实验一
            this.rdoOne.Checked = true;
            this.cbbNumber.SelectedIndex = 0;
            this.cbbNumber.Enabled = false;

            this.txtTo.Text = Config.TestToAddress;
            this.txtCC.Text = Config.TestToAddress;
            this.txtBcc.Text = Config.TestToAddress;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_to = this.txtTo.Text.Trim();
            m_cc = this.txtCC.Text.Trim();
            m_bcc = this.txtBcc.Text.Trim();
            m_Subject = this.txtSubject.Text.Trim();
            m_Body = this.rtbBody.Text;

            bool isAsync = this.chbAsync.Checked;
            bool isReuse = this.cbxReuse.Checked;
            this.rtbReply.AppendText(String.Format("==============={0},{1}{2}"
                , (isAsync ? "异步发送" : "同步发送"), (isReuse ? "重用SmtpClient实例" : "新SmtpClient实例"), Environment.NewLine));

            watch.Reset();
            watch.Start();

            // DateTime.Now.ToLongTimeString()
            if (this.rdoOne.Checked)
            {
                #region 实验一：单条邮件同步和异步发送（可通过添加大附件来观察同步异步效果）
                MailHelper mail = new MailHelper(isAsync);

                #region 发送单封邮件 中 加入图片链接示例。
                // 发送单封邮件 中 加入图片链接示例。
                string picPath = Environment.CurrentDirectory + "\\附件\\PIC_Mail中文.png";

                mail.AddInlineAttachment(picPath, "MyPic");

                // 注意内联图片地址写法  cid:ContentId   
                m_Body = m_Body + "<br/><img src=\"cid:MyPic\" /><a href=\"cid:MyPic\" target=\"_blank\">点击在新窗口打开图片</a>";

                #endregion

                if (isAsync)
                {
                    this.SendMessageAsync(mail, true, "实验一", "单条", true, isReuse);
                }
                else
                {
                    this.SendMessage(mail, true, "实验一", "单条", true, isReuse);

                }

                #endregion
            }
            else if (this.rdoTwo.Checked)
            {
                #region 实验二：批量邮件同步和异步发送（单个线程，单个SmtpClient实例，SendAsync()）

                long count = long.Parse(this.cbbNumber.Text);
                MailHelper mail = new MailHelper(isAsync);

                if (isReuse)
                {
                    if (isAsync)
                    {
                        for (long i = 1; i <= count; i++)
                        {
                            this.SendMessageAsync(mail, false, "实验二", "第" + i + "条", true, true);
                        }
                        mail.SetBatchMailCount(count);
                    }
                    else
                    {
                        for (long i = 1; i <= count; i++)
                        {
                            this.SendMessage(mail, false, "实验二", "第" + i + "条", true, true);
                        }
                        mail.SetBatchMailCount(count);
                    }
                }
                else
                {
                    if (isAsync)
                    {
                        for (long i = 1; i <= count; i++)
                        {
                            this.SendMessageAsync(mail, true, "实验二", "第" + i + "条", true, false);
                        }
                    }
                    else
                    {
                        for (long i = 1; i <= count; i++)
                        {
                            this.SendMessage(mail, true, "实验二", "第" + i + "条", true, false);
                        }
                    }
                }

                #endregion
            }
            else if (this.rdoThree.Checked)
            {
                #region 实验三：批量邮件同步和异步发送 （平行类库Parallel（自动分区），每个分区一个MailHelper、SmtpClient实例，SendAsync()）

                long count = long.Parse(this.cbbNumber.Text);
                if (count != 1)
                {
                    int fenzu = 0;
                    long sendCount = 0;

                    #region 由系统负荷自动分配最大并发度
                    // Environment.ProcessorCount; 并行度设置过大会导致资源争用问题，效率不高
                    // ParallelOptions parallelOptions = new ParallelOptions();
                    // parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;
                    #endregion

                    ParallelOptions parallelOptions = new ParallelOptions();
                    // 用一半的线程，因为内部发邮件需要线程池线程               
                    parallelOptions.MaxDegreeOfParallelism = (int)Math.Ceiling((double)Environment.ProcessorCount / 2d);

                    Parallel.For<ParallelInitObj>(1, count + 1
                        , parallelOptions, () =>
                        {
                            Interlocked.Increment(ref fenzu);
                            Debug.WriteLine("开始一个分组，当前分组数为：" + fenzu.ToString());
                            ParallelInitObj initObj = new ParallelInitObj()
                            {
                                mail = new MailHelper(isAsync),
                                SumCount = 0,
                            };
                            return initObj;
                        }
                        , (i, loop, initObj) =>
                        {
                            ParallelInitObj curInitObj = initObj;
                            MailHelper mail = curInitObj.mail;

                            Interlocked.Increment(ref sendCount);
                            string shiyan = String.Format("({0})实验三", Thread.CurrentThread.ManagedThreadId);

                            if (isReuse)
                            {
                                if (isAsync)
                                {
                                    this.SendMessageAsync(mail, false, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, true);
                                    curInitObj.SumCount++;
                                }
                                else
                                {
                                    this.SendMessage(mail, false, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, true);
                                    curInitObj.SumCount++;
                                }
                            }
                            else
                            {
                                if (isAsync)
                                {
                                    this.SendMessageAsync(mail, true, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, false);
                                }
                                else
                                {
                                    this.SendMessage(mail, true, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, false);
                                }
                            }
                            return curInitObj;
                        }
                        , (initObj) =>
                        {
                            ParallelInitObj curInitObj = initObj;
                            if (isReuse)
                            {
                                curInitObj.mail.SetBatchMailCount(curInitObj.SumCount);
                            }
                            Interlocked.Decrement(ref fenzu);
                            Debug.WriteLine("结束一个分组，当前分组数为：" + fenzu.ToString());
                        });
                }
                else
                {
                    MessageBox.Show("分区发邮件不能为一封");
                }

                #endregion
            }
            else if (this.rdoFour.Checked)
            {
                #region 实验四：批量邮件同步和异步发送 （平行类库Parallel（手动分区），每个分区一个MailHelper、SmtpClient实例）

                long count = long.Parse(this.cbbNumber.Text);

                if (count != 0)
                {
                    int fenzu = 0;
                    long sendCount = 0;

                    #region 由系统负荷自动分配最大并发度
                    // OrderablePartitioner<Tuple<long, long>> orderPartition = Partitioner.Create(1, count + 1, Environment.ProcessorCount);
                    // ParallelOptions parallelOptions = new ParallelOptions();
                    // parallelOptions.MaxDegreeOfParallelism = (int)Math.Ceiling((double)Environment.ProcessorCount);
                    #endregion

                    OrderablePartitioner<Tuple<long, long>> orderPartition = Partitioner.Create(1, count + 1, (count / (int)Math.Ceiling((double)Environment.ProcessorCount / 2d)));

                    ParallelOptions parallelOptions = new ParallelOptions();
                    parallelOptions.MaxDegreeOfParallelism = (int)Math.Ceiling((double)Environment.ProcessorCount / 2d);

                    Parallel.ForEach<Tuple<long, long>, ParallelInitObj>(orderPartition,
                        parallelOptions, () =>
                       {
                           Interlocked.Increment(ref fenzu);
                           Debug.WriteLine("开始一个分组，当前分组数为：" + fenzu.ToString());
                           ParallelInitObj initObj = new ParallelInitObj()
                           {
                               mail = new MailHelper(),
                               SumCount = 0,
                           };
                           return initObj;
                       }
                       , (source, loop, loopIndex, initObj) =>
                       {
                           ParallelInitObj curInitObj = initObj;
                           MailHelper mail = curInitObj.mail;

                           string shiyan = String.Format("({0})实验四", Thread.CurrentThread.ManagedThreadId);

                           for (long i = source.Item1; i < source.Item2; i++)
                           {
                               Interlocked.Increment(ref sendCount);
                               if (isReuse)
                               {
                                   if (isAsync)
                                   {
                                       this.SendMessageAsync(mail, false, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, true);
                                       curInitObj.SumCount++;
                                   }
                                   else
                                   {
                                       this.SendMessage(mail, false, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, true);
                                       curInitObj.SumCount++;
                                   }
                               }
                               else
                               {
                                   if (isAsync)
                                   {
                                       this.SendMessageAsync(mail, true, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, false);
                                   }
                                   else
                                   {
                                       this.SendMessage(mail, true, shiyan, "第" + Thread.VolatileRead(ref sendCount) + "条", true, false);
                                   }
                               }
                           }
                           return curInitObj;
                       }
                       , (initObj) =>
                       {
                           ParallelInitObj curInitObj = initObj;
                           if (isReuse)
                           {
                               curInitObj.mail.SetBatchMailCount(curInitObj.SumCount);
                           }
                           Interlocked.Decrement(ref fenzu);
                           Debug.WriteLine("结束一个分组，当前分组数为：" + fenzu.ToString());
                       });
                }
                else
                {
                    MessageBox.Show("分区发邮件不能为一封");
                }

                #endregion
            }
        }

        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <param name="isSimple">是否只发送一条</param>
        /// <param name="autoReleaseSmtp">是否自动释放SmtpClient</param>
        /// <param name="isReuse">是否重用SmtpClient</param>
        private void SendMessage(MailHelper mail, bool isSimple, string shiyan, string msgCount, bool autoReleaseSmtp, bool isReuse)
        {
            AppendReplyMsg(String.Format("{0}：{1}\"同步\"邮件开始。{2}{3}", shiyan, msgCount, watch.ElapsedMilliseconds, Environment.NewLine));

            if (!isReuse || !mail.ExistsSmtpClient())
            {
                mail.SetSmtpClient(
                       new SmtpHelper(Config.TestEmailType, false, Config.TestUserName, Config.TestPassword).SmtpClient
                       , autoReleaseSmtp
                       );
            }

            mail.From = Config.TestFromAddress;
            mail.FromDisplayName = Config.GetAddressName(Config.TestFromAddress);

            string to = m_to;
            string cc = m_cc;
            string bcc = m_bcc;
            if (to.Length > 0)
                mail.AddReceive(EmailAddrType.To, to, Config.GetAddressName(to));
            if (cc.Length > 0)
                mail.AddReceive(EmailAddrType.CC, cc, Config.GetAddressName(cc));
            if (bcc.Length > 0)
                mail.AddReceive(EmailAddrType.Bcc, bcc, Config.GetAddressName(bcc));

            mail.Subject = m_Subject;
            // Guid.NewGuid() 防止重复内容，被SMTP服务器拒绝接收邮件
            mail.Body = m_Body + Guid.NewGuid();
            mail.IsBodyHtml = true;

            if (filePaths != null && filePaths.Count > 0)
            {
                foreach (string filePath in FilePaths)
                {
                    mail.AddAttachment(filePath);
                }
            }

            Dictionary<MailInfoType, string> dic = mail.CheckSendMail();
            if (dic.Count > 0 && MailInfoHelper.ExistsError(dic))
            {
                // 反馈“错误+提示”信息
                AppendReplyMsg(MailInfoHelper.GetMailInfoStr(dic));
            }
            else
            {
                string msg = String.Empty;
                if (dic.Count > 0)
                {
                    // 反馈“提示”信息
                    msg = MailInfoHelper.GetMailInfoStr(dic);
                }

                try
                {
                    if (isSimple)
                    {
                        mail.SendOneMail();
                    }
                    else
                    {
                        // 发送
                        mail.SendBatchMail();
                    }
                    AppendReplyMsg(String.Format("{0}：{1}\"同步\"邮件已发送完成。{2}{3}", shiyan, msgCount, watch.ElapsedMilliseconds, Environment.NewLine));
                }
                catch (Exception ex)
                {
                    // 反馈异常信息
                    msg = msg + (ex.InnerException == null ? ex.Message : ex.Message + ex.InnerException.Message) + Environment.NewLine;
                }
                finally
                {
                    // 输出到界面
                    if (msg.Length > 0)
                        AppendReplyMsg(msg + Environment.NewLine);
                }
            }

            mail.Reset();
        }

        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="isSimple">是否只发送一条</param>
        /// <param name="autoReleaseSmtp">是否自动释放SmtpClient</param>
        /// <param name="isReuse">是否重用SmtpClient</param>
        private void SendMessageAsync(MailHelper mail, bool isSimple, string shiyan, string msgCount, bool autoReleaseSmtp, bool isReuse)
        {
            AppendReplyMsg(String.Format("{0}：{1}\"异步\"邮件开始。{2}{3}", shiyan, msgCount, watch.ElapsedMilliseconds, Environment.NewLine));

            if (!isReuse || !mail.ExistsSmtpClient())
            {
                SmtpClient client = new SmtpHelper(Config.TestEmailType, false, Config.TestUserName, Config.TestPassword).SmtpClient;
                mail.AsycUserState = String.Format("{0}：{1}\"异步\"邮件", shiyan, msgCount);
                client.SendCompleted += (send, args) =>
                {
                    AsyncCompletedEventArgs arg = args;

                    if (arg.Error == null)
                    {
                        // 需要注意的事使用 MailHelper 发送异步邮件，其UserState是 MailUserState 类型
                        AppendReplyMsg(((MailUserState)args.UserState).UserState.ToString() + "已发送完成." + watch.ElapsedMilliseconds + Environment.NewLine);
                    }
                    else
                    {
                        AppendReplyMsg(String.Format("{0} 异常：{1}{2}{3}"
                            , ((MailUserState)args.UserState).UserState.ToString() + "发送失败."
                            , (arg.Error.InnerException == null ? arg.Error.Message : arg.Error.Message + arg.Error.InnerException.Message)
                            , watch.ElapsedMilliseconds, Environment.NewLine));
                        // 标识异常已处理，否则若有异常，会抛出异常
                        ((MailUserState)args.UserState).IsErrorHandle = true;
                    }
                };
                mail.SetSmtpClient(client, autoReleaseSmtp);
            }
            else
            {
                mail.AsycUserState = String.Format("{0}：{1}\"异步\"邮件已发送完成。", shiyan, msgCount);
            }

            mail.From = Config.TestFromAddress;
            mail.FromDisplayName = Config.GetAddressName(Config.TestFromAddress);

            string to = m_to;
            string cc = m_cc;
            string bcc = m_bcc;
            if (to.Length > 0)
                mail.AddReceive(EmailAddrType.To, to, Config.GetAddressName(to));
            if (cc.Length > 0)
                mail.AddReceive(EmailAddrType.CC, cc, Config.GetAddressName(cc));
            if (bcc.Length > 0)
                mail.AddReceive(EmailAddrType.Bcc, bcc, Config.GetAddressName(bcc));

            mail.Subject = m_Subject;
            // Guid.NewGuid() 防止重复内容，被SMTP服务器拒绝接收邮件
            mail.Body = m_Body + Guid.NewGuid();
            mail.IsBodyHtml = true;

            if (filePaths != null && filePaths.Count > 0)
            {
                foreach (string filePath in FilePaths)
                {
                    mail.AddAttachment(filePath);
                }
            }

            Dictionary<MailInfoType, string> dic = mail.CheckSendMail();
            if (dic.Count > 0 && MailInfoHelper.ExistsError(dic))
            {
                // 反馈“错误+提示”信息
                AppendReplyMsg(MailInfoHelper.GetMailInfoStr(dic));
            }
            else
            {
                string msg = String.Empty;
                if (dic.Count > 0)
                {
                    // 反馈“提示”信息
                    msg = MailInfoHelper.GetMailInfoStr(dic);
                }

                try
                {
                    // 发送
                    if (isSimple)
                    {
                        mail.SendOneMail();
                    }
                    else
                    {
                        mail.SendBatchMail();
                    }
                }
                catch (Exception ex)
                {
                    // 反馈异常信息
                    AppendReplyMsg(String.Format("{0}\"异步\"异常：（{1}）{2}{3}", msgCount, watch.ElapsedMilliseconds, ex.Message, Environment.NewLine));

                }
                finally
                {
                    // 输出到界面
                    if (msg.Length > 0)
                        AppendReplyMsg(msg + Environment.NewLine);
                }
            }

            mail.Reset();
        }

        private void AppendReplyMsg(string msg)
        {
            if (this.rtbReply.InvokeRequired)
            {
                this.rtbReply.BeginInvoke(new Action<string>(innerAppendMsg), msg);
            }
            else
            {
                this.rtbReply.AppendText(msg);
            }
        }

        private void innerAppendMsg(string msg)
        {
            this.rtbReply.AppendText(msg);
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = Application.StartupPath + "\\附件";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileNames.Length > 0)
                {
                    StringBuilder sBuilder = new StringBuilder(this.rtbAttachText.Text);
                    foreach (string filePath in fileDialog.FileNames)
                    {

                        if (sBuilder.Length == 0)
                            sBuilder.Append("当前已选附件有：");

                        sBuilder.AppendLine().Append(filePath.Substring(filePath.LastIndexOf('\\') + 1));
                    }
                    FilePaths.AddRange(fileDialog.FileNames);
                    this.rtbAttachText.Text = sBuilder.ToString();
                }
            }
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton curBtn = sender as RadioButton;
            if (curBtn.Name == "rdoOne")
            {
                // 实验一
                this.cbbNumber.SelectedIndex = 0;
                this.cbbNumber.Enabled = false;
            }
            else if (curBtn.Name == "rdoTwo")
            {
                // 实验二
                this.cbbNumber.Enabled = true;

            }
            else if (curBtn.Name == "rdoThree")
            {
                // 实验三
                this.cbbNumber.Enabled = true;

            }
            else if (curBtn.Name == "rdoFour")
            {
                // 实验四
                this.cbbNumber.Enabled = true;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 清空反馈信息
            this.rtbReply.Text = String.Empty;
        }
    }

    public class ParallelInitObj
    {
        public MailHelper mail { get; set; }
        public long SumCount { get; set; }
    }
}
