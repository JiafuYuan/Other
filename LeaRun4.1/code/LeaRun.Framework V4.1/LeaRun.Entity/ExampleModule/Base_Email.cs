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
    /// �ʼ���Ϣ��
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.26 16:55</date>
    /// </author>
    /// </summary>
    [Description("�ʼ���Ϣ��")]
    [PrimaryKey("EmailId")]
    public class Base_Email : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// �ʼ���Ϣ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ʼ���Ϣ����")]
        public string EmailId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ParentId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Category { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Theme { get; set; }
        /// <summary>
        /// ɫ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ɫ������")]
        public string ThemeColour { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Content { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string Addresser { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public DateTime? SendDate { get; set; }
        /// <summary>
        /// �Ƿ��и���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ��и���")]
        public int? IsAccessory { get; set; }
        /// <summary>
        /// ���ȼ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ȼ�")]
        public int? Priority { get; set; }
        /// <summary>
        /// ��Ҫ��ִ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ҫ��ִ")]
        public int? Receipt { get; set; }
        /// <summary>
        /// �Ƿ�ʱ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ�ʱ����")]
        public int? IsDelayed { get; set; }
        /// <summary>
        /// ��ʱʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʱʱ��")]
        public DateTime? DelayedTime { get; set; }
        /// <summary>
        /// ״̬;1-�ѷ���;0-�ݸ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("״̬;1-�ѷ���;0-�ݸ�")]
        public int? State { get; set; }
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
            this.EmailId = CommonHelper.GetGuid;
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
            this.EmailId = KeyValue;
                                            }
        #endregion
    }
}