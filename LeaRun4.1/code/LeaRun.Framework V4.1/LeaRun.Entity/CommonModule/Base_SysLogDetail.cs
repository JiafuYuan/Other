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
    /// ϵͳ��־��ϸ
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.07.22 22:44</date>
    /// </author>
    /// </summary>
    [Description("ϵͳ��־��ϸ")]
    [PrimaryKey("SysLogDetailId")]
    public class Base_SysLogDetail : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ϵͳ��־��ϸ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ϵͳ��־��ϸ����")]
        public string SysLogDetailId { get; set; }
        /// <summary>
        /// ��־����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��־����")]
        public string SysLogId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string PropertyName { get; set; }
        /// <summary>
        /// �����ֶ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�����ֶ�")]
        public string PropertyField { get; set; }
        /// <summary>
        /// ������ֵ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������ֵ")]
        public string NewValue { get; set; }
        /// <summary>
        /// ���Ծ�ֵ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���Ծ�ֵ")]
        public string OldValue { get; set; }
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
            this.SysLogDetailId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
                                }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.SysLogDetailId = KeyValue;
                                            }
        #endregion
    }
}