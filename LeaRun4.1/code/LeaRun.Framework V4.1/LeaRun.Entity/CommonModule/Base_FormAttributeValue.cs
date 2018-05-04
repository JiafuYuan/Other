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
    /// ����������ʵ��
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.11.06 17:04</date>
    /// </author>
    /// </summary>
    [Description("����������ʵ��")]
    [PrimaryKey("AttributeValueId")]
    public class Base_FormAttributeValue : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��������ʵ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������ʵ������")]
        public string AttributeValueId { get; set; }
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
        public string ObjectId { get; set; }
        /// <summary>
        /// ����Json
        /// </summary>
        /// <returns></returns>
        [DisplayName("����Json")]
        public string ObjectParameterJson { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.AttributeValueId = CommonHelper.GetGuid;
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.AttributeValueId = KeyValue;
                                            }
        #endregion
    }
}