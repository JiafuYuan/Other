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
    /// ���丽����
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.26 16:56</date>
    /// </author>
    /// </summary>
    [Description("���丽����")]
    [PrimaryKey("EmailAccessoryId")]
    public class Base_EmailAccessory : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ���丽������
        /// </summary>
        /// <returns></returns>
        [DisplayName("���丽������")]
        public string EmailAccessoryId { get; set; }
        /// <summary>
        /// �ʼ���Ϣ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ʼ���Ϣ����")]
        public string EmailId { get; set; }
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
        /// �ļ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ļ�����")]
        public string FileType { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? CreateDate { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.EmailAccessoryId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.EmailAccessoryId = KeyValue;
        }
        #endregion
    }
}