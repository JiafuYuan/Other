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
    /// ���ݷ�ΧȨ�ޱ�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.22 15:35</date>
    /// </author>
    /// </summary>
    [Description("���ݷ�ΧȨ�ޱ�")]
    [PrimaryKey("DataScopePermissionId")]
    public class Base_DataScopePermission : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ���ݷ�ΧȨ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ݷ�ΧȨ������")]
        public string DataScopePermissionId { get; set; }
        /// <summary>
        /// �������:1-����2-��ɫ3-��λ4-Ⱥ��5-�û�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�������:1-����2-��ɫ3-��λ4-Ⱥ��5-�û�")]
        public string Category { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ObjectId { get; set; }
        /// <summary>
        /// ģ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("ģ������")]
        public string ModuleId { get; set; }
        /// <summary>
        /// ��ʲô��Դ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ʲô��Դ")]
        public string ResourceId { get; set; }
        /// <summary>
        /// �Զ�������
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Զ�������")]
        public string Condition { get; set; }
        /// <summary>
        /// �Զ���������Json
        /// </summary>
        /// <returns></returns>
        [DisplayName("�Զ���������Json")]
        public string ConditionJson { get; set; }
        /// <summary>
        /// ��Χ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Χ����")]
        public string ScopeType { get; set; }
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
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.DataScopePermissionId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateUserName = ManageProvider.Provider.Current().UserName;
            this.ScopeType = "1";
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.DataScopePermissionId = KeyValue;
        }
        #endregion
    }
}