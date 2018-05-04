﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;

namespace WorkSend
{
   
        public class SendEmail
    {
        private MailMessage mailMessage;
        private SmtpClient smtpClient;
        private string password;//发件人密码  
        /**/
        /// <summary>  
        /// 处审核后类的实例  
        /// </summary>  
        /// <param name="To">收件人地址</param>  
        /// <param name="From">发件人地址</param>  
        /// <param name="Body">邮件正文</param>  
        /// <param name="Title">邮件的主题</param>  
        /// <param name="Password">发件人密码</param>  
        public void SendMail(string[] To, string From, string Body, string Title, string Password)
        {
            try
            {
                mailMessage = new MailMessage();
                foreach (var s in To)
                {
                    mailMessage.To.Add(s);
                }
               
                mailMessage.From = new System.Net.Mail.MailAddress(From);
                mailMessage.Subject = Title;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.Body = Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.Priority = System.Net.Mail.MailPriority.Normal;

                this.password = Password;
            }
            catch (Exception ex)
            {
                throw new Exception("初始化邮件错误！" + ex.Message);
            }
        }

        /**/
        /// <summary>  
        /// 添加附件  
        /// </summary>  
        public void Attachments(string Path)
        {
            try
            {
                string[] path = Path.Split(',');
                Attachment data;
                ContentDisposition disposition;
                for (int i = 0; i < path.Length; i++)
                {
                    data = new Attachment(path[i], MediaTypeNames.Application.Octet);//实例化附件  
                    disposition = data.ContentDisposition;
                    mailMessage.Attachments.Add(data);//添加到附件中  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("添加附件错误！" + ex.Message);
            }
        }

        /**/
        /// <summary>  
        /// 异步发送邮件  
        /// </summary>  
        /// <param name="CompletedMethod"></param>  
        public void SendAsync(SendCompletedEventHandler CompletedMethod)
        {
            if (mailMessage != null)
            {
                smtpClient = new SmtpClient();
                smtpClient.Credentials = new System.Net.NetworkCredential(mailMessage.From.Address, password);//设置发件人身份的票据  
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.Host = "smtp." + mailMessage.From.Host;
                smtpClient.SendCompleted += new SendCompletedEventHandler(CompletedMethod);//注册异步发送邮件完成时的事件  
                smtpClient.SendAsync(mailMessage, mailMessage.Body);
            }
        }

        /**/
        /// <summary>  
        /// 发送邮件  
        /// </summary>  
        public void Send()
        {
            try
            {
                if (mailMessage != null)
                {
                    smtpClient = new SmtpClient();
                    smtpClient.Credentials = new System.Net.NetworkCredential(mailMessage.From.Address, password);//设置发件人身份的票据  
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp." + mailMessage.From.Host;
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("发送错误！" + ex.ToString());
            }
        }
    }
}