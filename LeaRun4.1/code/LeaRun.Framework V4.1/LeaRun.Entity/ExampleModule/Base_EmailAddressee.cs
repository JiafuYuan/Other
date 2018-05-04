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
    /// �����ռ��˱�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.26 16:56</date>
    /// </author>
    /// </summary>
    [Description("�����ռ��˱�")]
    [PrimaryKey("EmailAddresseeId")]
    public class Base_EmailAddressee : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// �����ռ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����ռ�������")]
        public string EmailAddresseeId { get; set; }
        /// <summary>
        /// �ʼ���Ϣ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ʼ���Ϣ����")]
        public string EmailId { get; set; }
        /// <summary>
        /// �ռ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ռ�������")]
        public string AddresseeId { get; set; }
        /// <summary>
        /// �ռ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ռ���")]
        public string AddresseeName { get; set; }
        /// <summary>
        /// ״̬: 0-�ռ�;1-����;2-����
        /// </summary>
        /// <returns></returns>
        [DisplayName("״̬: 0-�ռ�;1-����;2-����")]
        public int? AddresseeIdState { get; set; }
        /// <summary>
        /// �Ƿ��Ķ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ��Ķ�")]
        public int? IsRead { get; set; }
        /// <summary>
        /// �Ķ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ķ�����")]
        public int? ReadCount { get; set; }
        /// <summary>
        /// �Ķ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ķ�����")]
        public DateTime? ReadDate { get; set; }
        /// <summary>
        /// ����Ķ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����Ķ�����")]
        public DateTime? EndReadDate { get; set; }
        /// <summary>
        /// ���ú���
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ú���")]
        public int? Highlight { get; set; }
        /// <summary>
        /// ���ô���
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ô���")]
        public int? Backlog { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ɾ�����")]
        public int? DeleteMark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.EmailAddresseeId = CommonHelper.GetGuid;
            this.IsRead = 0;
            this.DeleteMark = 0;
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.EmailAddresseeId = KeyValue;
        }
        #endregion
    }
}