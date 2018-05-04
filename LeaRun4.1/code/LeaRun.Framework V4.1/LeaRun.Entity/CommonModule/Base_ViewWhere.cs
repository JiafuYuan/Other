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
    /// ��ͼ��ѯ������
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.04 10:10</date>
    /// </author>
    /// </summary>
    [Description("��ͼ��ѯ������")]
    [PrimaryKey("ViewWhereId")]
    public class Base_ViewWhere : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ͼ��ѯ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ͼ��ѯ��������")]
        public string ViewWhereId { get; set; }
        /// <summary>
        /// ģ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ģ������")]
        public string ModuleId { get; set; }
        /// <summary>
        /// �ؼ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ؼ�����")]
        public string ControlType { get; set; }
        /// <summary>
        /// �ؼ�Ĭ��ֵ
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ؼ�Ĭ��ֵ")]
        public string ControlDefault { get; set; }
        /// <summary>
        /// ������Դ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������Դ")]
        public string ControlSource { get; set; }
        /// <summary>
        /// �ֶ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ֶ�����")]
        public string FieldName { get; set; }
        /// <summary>
        /// �ڲ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ڲ�����")]
        public string FullName { get; set; }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʾ����")]
        public string ShowName { get; set; }
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ���ʾ")]
        public int? AllowShow { get; set; }
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
        /// �Զ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Զ���")]
        public string ControlCustom { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ViewWhereId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.ViewWhereId = KeyValue;
        }
        #endregion
    }
}