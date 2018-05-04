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
    /// Excel�����ϵ��
    /// <author>
    ///		<name>Liu</name>
    ///		<date>2014.08.25 22:41</date>
    /// </author>
    /// </summary>
    [Description("Excel�����ϵ��")]
    [PrimaryKey("ImportId")]
    public class Base_ExcelImport : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ImportId { get; set; }
        /// <summary>
        /// ģ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ģ����")]
        public string Code { get; set; }
        /// <summary>
        /// ģ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������")]
        public string ImportName { get; set; }
        /// <summary>
        /// Ҫ����ı�
        /// </summary>
        /// <returns></returns>
        [DisplayName("Ҫ����ı�")]
        public string ImportTable { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ע")]
        public string ImportTableName { get; set; }
        /// <summary>
        /// ����Excel���ļ���
        /// </summary>
        /// <returns></returns>
        [DisplayName("����Excel���ļ���")]
        public string ImportFileName { get; set; }
        /// <summary>
        /// ��������Ĵ�����ƣ�0-ֹͣ��1-����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��������Ĵ�����ƣ�0-ֹͣ��1-����")]
        public string ErrorHanding { get; set; }
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
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸�ʱ��")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸��û�����")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�޸��û�")]
        public string ModifyUserName { get; set; }
        /// <summary>
        /// ��Ӧģ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ӧģ��")]
        public string ModuleId { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ImportId = CommonHelper.GetGuid;
            this.Enabled = 1;
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
            this.ImportId = KeyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = ManageProvider.Provider.Current().UserId;
            this.ModifyUserName = ManageProvider.Provider.Current().UserName;                               
        }
        #endregion
    }
}