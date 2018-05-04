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
    /// ����Ӳ���ļ���
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.10.16 10:54</date>
    /// </author>
    /// </summary>
    [Description("����Ӳ���ļ���")]
    [PrimaryKey("NetworkFileId")]
    public class Base_NetworkFile : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ����Ӳ���ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����Ӳ���ļ�����")]
        public string NetworkFileId { get; set; }
        /// <summary>
        /// �ļ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�������")]
        public string FolderId { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�����")]
        public string FileName { get; set; }
        /// <summary>
        /// �ļ�·��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�·��")]
        public string FilePath { get; set; }
        /// <summary>
        /// �ļ���С
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ���С")]
        public string FileSize { get; set; }
        /// <summary>
        /// �ļ���׺��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ���׺��")]
        public string FileExtensions { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�����")]
        public string FileType { get; set; }
        /// <summary>
        /// ͼ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("ͼ��")]
        public string Icon { get; set; }
        /// <summary>
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�����")]
        public int? Sharing { get; set; }
        /// <summary>
        /// �������ļ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ļ�������")]
        public string SharingFolderId { get; set; }
        /// <summary>
        /// ����ʼʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʼʱ��")]
        public DateTime? SharingCreateDate { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������ʱ��")]
        public DateTime? SharingEndDate { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ч")]
        public int? Enabled { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public int? SortCode { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ɾ�����")]
        public int? DeleteMark { get; set; }
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
            this.NetworkFileId = CommonHelper.GetGuid;
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
            this.NetworkFileId = KeyValue;
                                            }
        #endregion
    }
}