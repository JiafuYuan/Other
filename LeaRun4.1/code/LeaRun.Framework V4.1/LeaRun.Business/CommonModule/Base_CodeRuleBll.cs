//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2014
// Software Developers @ Learun 2014
//=====================================================================================

using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;


namespace LeaRun.Business
{
    /// <summary>
    /// �����������
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.10.03 16:51</date>
    /// </author>
    /// </summary>
    public class Base_CodeRuleBll : RepositoryFactory<Base_CodeRule>
    {
        #region ��ȡ��������б�
        /// <summary>
        /// ��ȡ����滮�б�
        /// </summary>
        /// <returns></returns>
        public List<Base_CodeRule> GetList()
        {
            return Repository().FindList();
        }
        #endregion

        #region ���ύ
        /// <summary>
        /// ��Excelģ�����á����ύ�¼�
        /// </summary>
        /// <param name="KeyValue">����ֵ</param>
        /// <param name="Entity">����ģ��ʵ��</param>
        /// <param name="ExcelImportDetailJson">����ģ����ϸJson</param>
        /// <returns></returns>
        public int SubmitForm(string KeyValue, Base_CodeRule base_coderule, string CodeRuleDetailJson)
        {
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            try
            {
                List<Base_CodeRuleDetail> CodeRuleDetailList = CodeRuleDetailJson.JonsToList<Base_CodeRuleDetail>();
                if (!string.IsNullOrEmpty(KeyValue))
                {
                    base_coderule.Modify(KeyValue);
                    database.Update(base_coderule, isOpenTrans);
                    database.Delete("Base_CodeRuleDetail", "CodeRuleId", base_coderule.CodeRuleId);//��ԭ����ϸɾ��������������������ȷ���������ظ���ϸֵ
                }
                else
                {

                    base_coderule.Create(); database.Insert(base_coderule, isOpenTrans);
                    //������ˮ������
                    Base_CodeRuleSerious base_coderuleserious = new Base_CodeRuleSerious();
                    base_coderuleserious.Create();
                    base_coderuleserious.CodeRuleId = base_coderule.CodeRuleId;
                    base_coderuleserious.NowValue = 1;
                    database.Insert<Base_CodeRuleSerious>(base_coderuleserious, isOpenTrans);
                }
                int i = 1;
                foreach (Base_CodeRuleDetail base_coderuledetail in CodeRuleDetailList)
                {
                    //��������
                    if (string.IsNullOrEmpty(base_coderuledetail.FormatStr))
                    {
                        continue;
                    }
                    base_coderuledetail.CodeRuleId = base_coderule.CodeRuleId;
                    base_coderuledetail.CodeRuleDetailId = CommonHelper.GetGuid;
                    base_coderuledetail.SortCode = i;
                    i++;
                    database.Insert(base_coderuledetail, isOpenTrans);
                }
                database.Commit();
                return 1;
            }
            catch
            {
                database.Rollback();
                return -1;
            }
        }
        #endregion

        #region ���ݱ��봦��
        /// <summary>
        /// ��õ�ǰģ��ĵ��ݱ�����û�ж������ͷ��ؿ�
        /// </summary>
        /// <param name="userId">�û�ID</param>
        /// <param name="moduleId">ģ��ID</param>
        /// <returns>���ݺ�</returns>
        public string GetBillCode(string userId, string moduleId)
        {
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            //���ģ��ID
            string billCode = "";//���ݺ�
            Base_User base_user = database.FindEntity<Base_User>(userId);
            Base_CodeRule base_coderule = Repository().FindEntity("ModuleId", moduleId);
            try
            {
                int nowSerious = 0;
                //ȡ����ˮ������
                List<Base_CodeRuleSerious> base_coderuleseriouslist = database.FindList<Base_CodeRuleSerious>("CodeRuleId", base_coderule.CodeRuleId);
                //ȡ���������
                Base_CodeRuleSerious maxCodeRuleSerious = base_coderuleseriouslist.Find(delegate(Base_CodeRuleSerious p) { return p.ValueType == "0" && p.UserId == null; });
                if (!string.IsNullOrEmpty(base_coderule.CodeRuleId))
                {
                    List<Base_CodeRuleDetail> base_coderuledetailList = database.FindList<Base_CodeRuleDetail>("CodeRuleId", base_coderule.CodeRuleId);
                    foreach (Base_CodeRuleDetail base_coderuledetail in base_coderuledetailList)
                    {
                        switch (base_coderuledetail.FullName)
                        {
                            //�Զ�����
                            case "0":
                                billCode = billCode + base_coderuledetail.FormatStr;
                                break;
                            //����
                            case "1":
                                //�����ַ�������
                                billCode = billCode + DateTime.Now.ToString(base_coderuledetail.FormatStr);
                                //�����Զ�������ˮ��
                                if (base_coderuledetail.AutoReset == 1)
                                {
                                    //�ж��Ƿ�����ˮ��
                                    if (maxCodeRuleSerious != null)
                                    {
                                        //���ϴθ���ʱ����������ڲ�һ��ʱ������ˮ������
                                        if (maxCodeRuleSerious.LastUpdateDate != DateTime.Now.ToString(base_coderuledetail.FormatStr))
                                        {
                                            maxCodeRuleSerious.LastUpdateDate = DateTime.Now.ToString(base_coderuledetail.FormatStr);//����������ʱ��
                                            maxCodeRuleSerious.NowValue = 1;//��������
                                            database.Update<Base_CodeRuleSerious>(maxCodeRuleSerious, isOpenTrans);
                                            //���������Ժ�ɾ����֮ǰ�û�ռ���˵����ӡ�
                                            StringBuilder deleteSql = new StringBuilder(string.Format("delete Base_CodeRuleSerious where CodeRuleId='{0} AND UserId IS NOT NULL '", base_coderule.CodeRuleId));
                                            database.ExecuteBySql(deleteSql, isOpenTrans);
                                        }
                                    }
                                }
                                break;
                            //��ˮ��
                            case "2":
                                //���ҵ�ǰ�û��Ƿ�����֮ǰδ�õ�������
                                Base_CodeRuleSerious base_coderuleserious = base_coderuleseriouslist.Find(delegate(Base_CodeRuleSerious p) { return p.UserId == userId && p.Enabled == 1; });
                                //���û�о�ȡ��ǰ��������
                                if (base_coderuleserious == null)
                                {
                                    //ȡ��ϵͳ��������
                                    int maxSerious = (int)maxCodeRuleSerious.NowValue;
                                    nowSerious = maxSerious;
                                    base_coderuleserious = new Base_CodeRuleSerious();
                                    base_coderuleserious.Create();
                                    base_coderuleserious.NowValue = maxSerious;
                                    base_coderuleserious.UserId = userId;
                                    base_coderuleserious.ValueType = "1";
                                    base_coderuleserious.Enabled = 1;
                                    base_coderuleserious.CodeRuleId = base_coderule.CodeRuleId;
                                    database.Insert<Base_CodeRuleSerious>(base_coderuleserious, isOpenTrans);
                                    //�������Ӹ���
                                    maxCodeRuleSerious.NowValue += 1;//��������
                                    database.Update<Base_CodeRuleSerious>(maxCodeRuleSerious, isOpenTrans);
                                }
                                else
                                {
                                    nowSerious = (int)base_coderuleserious.NowValue;
                                }
                                string seriousStr = new string('0', (int)(base_coderuledetail.FLength)) + nowSerious.ToString();
                                seriousStr = seriousStr.Substring(seriousStr.Length - (int)(base_coderuledetail.FLength));
                                billCode = billCode + seriousStr;
                                break;
                            //����
                            case "3":

                                Base_Department base_department = database.FindEntity<Base_Department>(base_user.DepartmentId);
                                billCode = billCode + base_coderuledetail.FormatStr;
                                if (base_coderuledetail.FormatStr == "code")
                                {
                                    billCode = billCode + base_department.Code;
                                }
                                else
                                {
                                    billCode = billCode + base_department.FullName;
                                }
                                break;
                            //��˾
                            case "4":
                                Base_Company base_company = database.FindEntity<Base_Company>(base_user.CompanyId);
                                if (base_coderuledetail.FormatStr == "code")
                                {
                                    billCode = billCode + base_company.Code;
                                }
                                else
                                {
                                    billCode = billCode + base_company.FullName;
                                }
                                break;
                            //�û�
                            case "5":
                                if (base_coderuledetail.FormatStr == "code")
                                {
                                    billCode = billCode + base_user.Code;
                                }
                                else
                                {
                                    billCode = billCode + base_user.Account;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Other, "-1", string.Format("{0}�ڻ�ȡ{1}���ݱ���ʱ����", base_user.RealName, base_coderule.FullName) + ex.Message);
                database.Rollback();
                return billCode;
            }
            database.Commit();
            return billCode;
        }
        /// <summary>
        /// ռ�õ��ݺ�
        /// </summary>
        /// <param name="userId">�û�ID</param>
        /// <param name="moduleId">ģ��ID</param>
        /// <returns>true/false</returns>
        public bool OccupyBillCode(string userId, string moduleId, DbTransaction isOpenTrans = null)
        {
            Base_CodeRule base_coderule = Repository().FindEntity("ModuleId", moduleId);
            try
            {
                IDatabase database = DataFactory.Database();
                if (base_coderule != null)
                {
                    List<Base_CodeRuleSerious> base_coderuleseriouslist = database.FindList<Base_CodeRuleSerious>("CodeRuleId", base_coderule.CodeRuleId);
                    //���ҵ�ǰ�û��Ƿ�����֮ǰδ�õ�������
                    Base_CodeRuleSerious base_coderuleserious = base_coderuleseriouslist.Find(delegate(Base_CodeRuleSerious p) { return p.UserId == userId && p.Enabled == 1; });
                    if (base_coderuleserious != null)
                    {
                        database.Delete<Base_CodeRuleSerious>(base_coderuleserious);
                    }
                }
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Other, "-1", string.Format("ռ��{0}���ݱ���ʱ����", base_coderule.FullName) + ex.Message);
                return false;
            }
            return true;
        }
        #endregion
    }
}