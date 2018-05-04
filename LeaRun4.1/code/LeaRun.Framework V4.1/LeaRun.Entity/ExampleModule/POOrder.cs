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
    /// ��������
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.10.27 12:04</date>
    /// </author>
    /// </summary>
    [Description("��������")]
    [PrimaryKey("POOrderId")]
    public class POOrder : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string POOrderId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ParentId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string BillNo { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public DateTime? BillDate { get; set; }
        /// <summary>
        /// ������ʽ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������ʽ")]
        public string Method { get; set; }
        /// <summary>
        /// ���㷽ʽ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���㷽ʽ")]
        public string Clearing { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public DateTime? ClearingTime { get; set; }
        /// <summary>
        /// �ұ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ұ�")]
        public string Currency { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string ExchangeRate { get; set; }
        /// <summary>
        /// ��Ӧ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӧ��")]
        public string SupplierId { get; set; }
        /// <summary>
        /// �����ص�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����ص�")]
        public string FetchAdd { get; set; }
        /// <summary>
        /// �ɹ�Ա����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ɹ�Ա����")]
        public string SalesmanId { get; set; }
        /// <summary>
        /// �ɹ�Ա
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ɹ�Ա")]
        public string Salesman { get; set; }
        /// <summary>
        /// ¼�����ͣ�0-PC�ֹ�¼��,1-�ⲿ����,2-PDA¼��,3-�ֻ���¼��,4-����¼��
        /// </summary>
        /// <returns></returns>
        [DisplayName("¼�����ͣ�0-PC�ֹ�¼��,1-�ⲿ����,2-PDA¼��,3-�ֻ���¼��,4-����¼��")]
        public int? POOrderType { get; set; }
        /// <summary>
        /// �رգ�0-������1-����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�رգ�0-������1-����")]
        public int? Cancellation { get; set; }
        /// <summary>
        /// �Ƶ���������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƶ���������")]
        public string CreateDepartmentId { get; set; }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƶ�����")]
        public string CreateDepartmentName { get; set; }
        /// <summary>
        /// �Ƶ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƶ�������")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// �Ƶ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƶ���")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// �Ƶ�ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƶ�ʱ��")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �ύ������0-δ�ύ,1-���ύ
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ύ������0-δ�ύ,1-���ύ")]
        public int? IsSubmit { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ɾ�����")]
        public int? DeleteMark { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����������")]
        public string ModifyDepartmentId { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������")]
        public string ModifyDepartmentName { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [DisplayName("���������")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����")]
        public string ModifyUserName { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ʱ��")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// ���״̬��
        /// </summary>
        /// <returns></returns>
        [DisplayName("���״̬��")]
        public string AuditStatus { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        /// <returns></returns>
        [DisplayName("���״̬")]
        public string AuditStatusName { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ע")]
        public string Remark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.POOrderId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateUserName = ManageProvider.Provider.Current().UserName;
            this.CreateDepartmentId = ManageProvider.Provider.Current().DepartmentId;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.POOrderId = KeyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = ManageProvider.Provider.Current().UserId;
            this.ModifyUserName = ManageProvider.Provider.Current().UserName;
            this.ModifyDepartmentId = ManageProvider.Provider.Current().DepartmentId;
        }
        #endregion
    }
}