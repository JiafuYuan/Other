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
    /// ְԱ��Ϣ
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.11 15:45</date>
    /// </author>
    /// </summary>
    [Description("ְԱ��Ϣ")]
    [PrimaryKey("EmployeeId")]
    public class Base_Employee : BaseEntity
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// ְԱ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("ְԱ����")]
        public string EmployeeId { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�û�����")]
        public string UserId { get; set; }
        /// <summary>
        /// ��Ƭ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��Ƭ")]
        public string Photograph { get; set; }
        /// <summary>
        /// ���֤����
        /// </summary>
        /// <returns></returns>
        [DisplayName("���֤����")]
        public string IDCard { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public int? Age { get; set; }
        /// <summary>
        /// ���ʿ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ʿ�")]
        public string BankCode { get; set; }
        /// <summary>
        /// �칫�̺�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�칫�̺�")]
        public string OfficeCornet { get; set; }
        /// <summary>
        /// �칫�绰
        /// </summary>
        /// <returns></returns>
        [DisplayName("�칫�绰")]
        public string OfficePhone { get; set; }
        /// <summary>
        /// �칫�ʱ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("�칫�ʱ�")]
        public string OfficeZipCode { get; set; }
        /// <summary>
        /// �칫��ַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("�칫��ַ")]
        public string OfficeAddress { get; set; }
        /// <summary>
        /// �칫����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�칫����")]
        public string OfficeFax { get; set; }
        /// <summary>
        /// ���ѧ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ѧ��")]
        public string Education { get; set; }
        /// <summary>
        /// ��ҵԺУ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ҵԺУ")]
        public string School { get; set; }
        /// <summary>
        /// ��ҵʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ҵʱ��")]
        public DateTime? GraduationDate { get; set; }
        /// <summary>
        /// ��ѧרҵ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ѧרҵ")]
        public string Major { get; set; }
        /// <summary>
        /// ���ѧλ
        /// </summary>
        /// <returns></returns>
        [DisplayName("���ѧλ")]
        public string Degree { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʱ��")]
        public DateTime? WorkingDate { get; set; }
        /// <summary>
        /// ��ͥסַ�ʱ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ͥסַ�ʱ�")]
        public string HomeZipCode { get; set; }
        /// <summary>
        /// ��ͥסַ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ͥסַ")]
        public string HomeAddress { get; set; }
        /// <summary>
        /// סլ�绰
        /// </summary>
        /// <returns></returns>
        [DisplayName("סլ�绰")]
        public string HomePhone { get; set; }
        /// <summary>
        /// ��ͥ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ͥ����")]
        public string HomeFax { get; set; }
        /// <summary>
        /// ����ʡ
        /// </summary>
        /// <returns></returns>
        [DisplayName("����ʡ")]
        public string Province { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string City { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [DisplayName("������")]
        public string Area { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string NativePlace { get; set; }
        /// <summary>
        /// ������ò
        /// </summary>
        /// <returns></returns>
        [DisplayName("������ò")]
        public string Party { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Nation { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("����")]
        public string Nationality { get; set; }
        /// <summary>
        /// ְ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("ְ��")]
        public string Duty { get; set; }
        /// <summary>
        /// �ù�����
        /// </summary>
        /// <returns></returns>
        [DisplayName("�ù�����")]
        public string WorkingProperty { get; set; }
        /// <summary>
        /// ְҵ�ʸ�
        /// </summary>
        /// <returns></returns>
        [DisplayName("ְҵ�ʸ�")]
        public string Competency { get; set; }
        /// <summary>
        /// ������ϵ
        /// </summary>
        /// <returns></returns>
        [DisplayName("������ϵ")]
        public string EmergencyContact { get; set; }
        /// <summary>
        /// ��ְ
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ְ")]
        public int? IsDimission { get; set; }
        /// <summary>
        /// ��ְ����
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ְ����")]
        public DateTime? DimissionDate { get; set; }
        /// <summary>
        /// ��ְԭ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ְԭ��")]
        public string DimissionCause { get; set; }
        /// <summary>
        /// ��ְȥ��
        /// </summary>
        /// <returns></returns>
        [DisplayName("��ְȥ��")]
        public string DimissionWhither { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.EmployeeId = CommonHelper.GetGuid;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.EmployeeId = KeyValue;
        }
        #endregion
    }
}