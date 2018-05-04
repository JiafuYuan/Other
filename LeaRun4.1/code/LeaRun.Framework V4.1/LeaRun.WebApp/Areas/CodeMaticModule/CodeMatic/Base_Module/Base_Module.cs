//=====================================================================================
// All Rights Reserved , Copyright ? Learun 2014
// Software Developers ? Learun 2014
//=====================================================================================

using LeaRun.Kernel;
using System;
using System.ComponentModel;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ģ�����ñ�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.06.22 19:28</date>
    /// </author>
    /// </summary>
    [Description("ģ�����ñ�")]
    [Key("ModuleId")]
    [MaxField("SortCode")]
    public class Base_Module
    {
        /// <summary>
        /// ģ������
        /// </summary>
        /// <returns></returns>
        [Description("ģ������")]
        [Display(Name = "ģ������")]
        public string ModuleId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Description("��������")]
        [Display(Name = "��������")]
        public string ParentId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Description("����")]
        [Display(Name = "����")]
        public string Code { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Description("����")]
        [Display(Name = "����")]
        public string FullName { get; set; }
        /// <summary>
        /// ͼ��
        /// </summary>
        /// <returns></returns>
        [Description("ͼ��")]
        [Display(Name = "ͼ��")]
        public string Icon { get; set; }
        /// <summary>
        /// ���ʵ�ַ
        /// </summary>
        /// <returns></returns>
        [Description("���ʵ�ַ")]
        [Display(Name = "���ʵ�ַ")]
        public string Location { get; set; }
        /// <summary>
        /// Ŀ��
        /// </summary>
        /// <returns></returns>
        [Description("Ŀ��")]
        [Display(Name = "Ŀ��")]
        public string Target { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Description("������")]
        [Display(Name = "������")]
        public int? Level { get; set; }
        /// <summary>
        /// ��̬��ť
        /// </summary>
        /// <returns></returns>
        [Description("��̬��ť")]
        [Display(Name = "��̬��ť")]
        public int? AllowButton { get; set; }
        /// <summary>
        /// ��̬��ͼ
        /// </summary>
        /// <returns></returns>
        [Description("��̬��ͼ")]
        [Display(Name = "��̬��ͼ")]
        public int? AllowView { get; set; }
        /// <summary>
        /// ��̬��
        /// </summary>
        /// <returns></returns>
        [Description("��̬��")]
        [Display(Name = "��̬��")]
        public int? AllowForm { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Description("��ע")]
        [Display(Name = "��ע")]
        public string Remark { get; set; }
        /// <summary>
        /// ��Ч
        /// </summary>
        /// <returns></returns>
        [Description("��Ч")]
        [Display(Name = "��Ч")]
        public int? Enabled { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Description("������")]
        [Display(Name = "������")]
        public int? SortCode { get; set; }
        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <returns></returns>
        [Description("ɾ�����")]
        [Display(Name = "ɾ�����")]
        public int? DeleteMark { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Description("����ʱ��")]
        [Display(Name = "����ʱ��")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        [Description("�����û�����")]
        [Display(Name = "�����û�����")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        [Description("�����û�")]
        [Display(Name = "�����û�")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Description("�޸�ʱ��")]
        [Display(Name = "�޸�ʱ��")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        [Description("�޸��û�����")]
        [Display(Name = "�޸��û�����")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        [Description("�޸��û�")]
        [Display(Name = "�޸��û�")]
        public string ModifyUserName { get; set; }
    }
}