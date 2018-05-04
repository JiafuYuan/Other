//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2014
// Software Developers @ Learun 2014
//=====================================================================================

using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
namespace LeaRun.Business
{
    /// <summary>
    /// ����demo
    /// <author>
    ///		<name>liu</name>
    ///		<date>2014.11.27 16:55</date>
    /// </author>
    /// </summary>
    public class ReportBll
    {
        /// <summary>
        /// ���۵��������б�JSON��
        /// </summary>
        /// <param name="keywords">�ؼ���</param>
        /// <returns></returns>
        public List<Quotation> GetQuotationList(string filepath, string keywords)
        {
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));//ȡ����txt�ļ��ı���
            int PageSize = 20;
            List<Quotation> ListData = new List<Quotation>();
            if (!string.IsNullOrEmpty(keywords))
            {
                //Linqģ����ѯ
                ListData = (from itementity in JsonHelper.JonsToList<Quotation>(sr.ReadToEnd().ToString())
                            where itementity.number.Contains(keywords)
                            || itementity.name.Contains(keywords)
                            || itementity.code.Contains(keywords.ToUpper())
                            select itementity).Take(PageSize).ToList<Quotation>();
            }
            else
            {
                ListData = JsonHelper.JonsToList<Quotation>(sr.ReadToEnd().ToString()).Take(PageSize).ToList<Quotation>();
            }
            var JsonData = new
            {
                rows = ListData,
            };
            return ListData;
        }
        /// <summary>
        /// ���ж��˱������б�JSON��
        /// </summary>
        /// <param name="keywords">�ؼ���</param>
        /// <returns></returns>
        public List<BankAnalyze> GetBankAnalyzeList(string filepath, string keywords)
        {
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));//ȡ����txt�ļ��ı���
            int PageSize = 40;
            List<BankAnalyze> ListData = new List<BankAnalyze>();
            if (!string.IsNullOrEmpty(keywords))
            {
                //Linqģ����ѯ
                ListData = (from itementity in JsonHelper.JonsToList<BankAnalyze>(sr.ReadToEnd().ToString())
                            where itementity.Month.Contains(keywords)
                            || itementity.Remark.Contains(keywords)
                            || itementity.CreateDate.Contains(keywords.ToUpper())
                            select itementity).Take(PageSize).ToList<BankAnalyze>();
            }
            else
            {
                ListData = JsonHelper.JonsToList<BankAnalyze>(sr.ReadToEnd().ToString()).Take(PageSize).ToList<BankAnalyze>();
            }
            var JsonData = new
            {
                rows = ListData,
            };
            return ListData;
        }
        /// <summary>
        /// �ʽ��������б�JSON��
        /// </summary>
        /// <param name="keywords">�ؼ���</param>
        /// <returns></returns>
        public List<MoneyBal> GetMoneyBalList(string filepath, string keywords)
        {
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));//ȡ����txt�ļ��ı���
            List<MoneyBal> ListData = new List<MoneyBal>();
            if (!string.IsNullOrEmpty(keywords))
            {
                //Linqģ����ѯ
                ListData = (from itementity in JsonHelper.JonsToList<MoneyBal>(sr.ReadToEnd().ToString())
                            where itementity.Year.Contains(keywords)
                            select itementity).ToList<MoneyBal>();
            }
            else
            {
                ListData = JsonHelper.JonsToList<MoneyBal>(sr.ReadToEnd().ToString()).ToList<MoneyBal>();
            }
            var JsonData = new
            {
                rows = ListData,
            };
            return ListData;
        }

    }
    #region ���۵�
    /// <summary>
    /// ���۵�
    /// </summary>
    public class Quotation
    {
        public string number { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string model { get; set; }
        public string qty { get; set; }
        public string price { get; set; }
        public string amount { get; set; }
        public string decription { get; set; }
    }

    #endregion

    #region ���ж��ʵ�
    /// <summary>
    /// ���ж��ʵ�
    /// </summary>
    public class BankAnalyze
    {
        public string Month { get; set; }
        public string Remark { get; set; }
        public string Income { get; set; }
        public string Pay { get; set; }
        public string Balance { get; set; }
        public string CreateDate { get; set; }
        public string Type { get; set; }
    }
    #endregion

    #region �ʽ����
    /// <summary>
    /// �ʽ����
    /// </summary>
    public class MoneyBal
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
    #endregion
}