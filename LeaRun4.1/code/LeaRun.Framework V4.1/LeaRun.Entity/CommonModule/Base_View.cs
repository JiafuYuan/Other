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
    /// ��ͼ���ñ�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.04 10:09</date>
    /// </author>
    /// </summary>
    [Description("��ͼ���ñ�")]
    [PrimaryKey("ViewId")]
    public class Base_View : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��ͼ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ͼ����")]
        public string ViewId { get; set; }
        /// <summary>
        /// ģ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ģ������")]
        public string ModuleId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ParentId { get; set; }
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
        /// ��ʾ�п�
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʾ�п�")]
        public int? ColumnWidth { get; set; }
        /// <summary>
        /// ���뷽ʽ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���뷽ʽ")]
        public string TextAlign { get; set; }
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Ƿ���ʾ")]
        public int? AllowShow { get; set; }
        /// <summary>
        /// ����/��ӡ
        /// </summary>
        /// <returns></returns>
        [DisplayName("����/��ӡ")]
        public int? AllowDerive { get; set; }
        /// <summary>
        /// �Զ���ת��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Զ���ת��")]
        public string CustomSwitch { get; set; }
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
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ViewId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
                                }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.ViewId = KeyValue;
                                            }
        #endregion
    }
}