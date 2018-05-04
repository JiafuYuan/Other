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
    /// �ӿڲ���
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.11.05 10:37</date>
    /// </author>
    /// </summary>
    [Description("�ӿڲ���")]
    [PrimaryKey("InterfaceParameterId")]
    public class Base_InterfaceManageParameter : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// �ӿڲ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ӿڲ�������")]
        public string InterfaceParameterId { get; set; }
        /// <summary>
        /// �ӿ�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ӿ�����")]
        public string InterfaceId { get; set; }
        /// <summary>
        /// �����ֶ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����ֶ�")]
        public string Field { get; set; }
        /// <summary>
        /// ����˵��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����˵��")]
        public string FieldMemo { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string FieldType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string FieldMaxLength { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����")]
        public int? AllowNull { get; set; }
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
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.InterfaceParameterId = CommonHelper.GetGuid;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.InterfaceParameterId = KeyValue;
        }
        #endregion
    }
}