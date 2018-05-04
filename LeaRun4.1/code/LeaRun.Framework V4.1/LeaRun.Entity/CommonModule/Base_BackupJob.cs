//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2014
// Software Developers @ Learun 2014
//=====================================================================================

using LeaRun.DataAccess.Attributes;
using LeaRun.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeaRun.Entity
{
    /// <summary>
    /// ���ݿⱸ�ݼƻ���
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.23 17:30</date>
    /// </author>
    /// </summary>
    [Description("���ݿⱸ�ݼƻ���")]
    [PrimaryKey("BackupId")]
    public class Base_BackupJob : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string BackupId { get; set; }
        /// <summary>
        /// ��������ַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������ַ")]
        public string ServerName { get; set; }
        /// <summary>
        /// ���ݿ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ݿ�")]
        public string DbName { get; set; }
        /// <summary>
        /// �ƻ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ƻ�����")]
        public string JobName { get; set; }
        /// <summary>
        /// ִ�з�ʽ
        /// </summary>
        /// <returns></returns>
        [DisplayName("ִ�з�ʽ")]
        public string Mode { get; set; }
        /// <summary>
        /// ִ��ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("ִ��ʱ��")]
        public string StartTime { get; set; }
        /// <summary>
        /// ����·��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����·��")]
        public string FilePath { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ע")]
        public string Remark { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ч")]
        public string Enabled { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����û�����")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����û�")]
        public string CreateUserName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.BackupId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateUserName = ManageProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.BackupId = KeyValue;
        }
        #endregion
    }
}