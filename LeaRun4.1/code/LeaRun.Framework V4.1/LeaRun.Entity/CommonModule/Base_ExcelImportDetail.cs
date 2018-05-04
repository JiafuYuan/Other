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
    /// Excel�����ϵ��ϸ��
    /// <author>
    ///		<name>Liu</name>
    ///		<date>2014.08.25 22:41</date>
    /// </author>
    /// </summary>
    [Description("Excel�����ϵ��ϸ��")]
    [PrimaryKey("ImportDetailId")]
    public class Base_ExcelImportDetail : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// �����ϵ��ϸ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ImportDetailId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ImportId { get; set; }
        /// <summary>
        /// �ֶ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ֶ���")]
        public string FieldName { get; set; }
        /// <summary>
        /// Excel����
        /// </summary>
        /// <returns></returns>
        [DisplayName("Excel����")]
        public string ColumnName { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string DataType { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        /// <returns></returns>
        [DisplayName("���������")]
        public string ForeignTable { get; set; }
        /// <summary>
        /// ���ص����ֵ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ص����ֵ")]
        public string BackField { get; set; }
        /// <summary>
        /// �Ա��ֶ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ա��ֶ�")]
        public string CompareField { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string AttachCondition { get; set; }
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
        /// <summary>
        /// �ֶα�ע
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ֶα�ע")]
        public string FieldRemark { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ImportDetailId = CommonHelper.GetGuid;
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
            this.ImportDetailId = KeyValue;
                                            }
        #endregion
    }
}