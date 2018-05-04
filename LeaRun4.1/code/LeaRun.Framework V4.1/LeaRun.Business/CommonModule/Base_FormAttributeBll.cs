//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2014
// Software Developers @ Learun 2014
//=====================================================================================

using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ����������
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.11.06 17:03</date>
    /// </author>
    /// </summary>
    public class Base_FormAttributeBll : RepositoryFactory<Base_FormAttribute>
    {
        private static Base_FormAttributeBll item;
        /// <summary>
        /// ��̬��
        /// </summary>
        public static Base_FormAttributeBll Instance
        {
            get
            {
                if (item == null)
                {
                    item = new Base_FormAttributeBll();
                }
                return item;
            }
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="ModuleId">ģ��Id</param>
        /// <returns></returns>
        public List<Base_FormAttribute> GetList(string ModuleId)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM Base_FormAttribute WHERE 1=1");
            strSql.Append(" AND ModuleId = @ModuleId AND Enabled=1");
            strSql.Append(" ORDER BY SortCode");
            parameter.Add(DbFactory.CreateDbParameter("@ModuleId", ModuleId));
            return Repository().FindListBySql(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// ���涯̬������
        /// </summary>
        /// <param name="BuildFormJson">��JSON����</param>
        /// <param name="ObjectId">����Id</param>
        /// <param name="ModuleId">ģ��Id</param>
        public void SaveBuildForm(string BuildFormJson, string ObjectId, string ModuleId, DbTransaction isOpenTrans)
        {
            try
            {
                Base_FormAttributeValue formattributevalue = new Base_FormAttributeValue();
                formattributevalue.Create();
                formattributevalue.ObjectId = ObjectId;
                formattributevalue.ModuleId = ModuleId;
                formattributevalue.ObjectParameterJson = BuildFormJson;
                DataFactory.Database().Delete<Base_FormAttributeValue>("ObjectId", ObjectId, isOpenTrans);
                DataFactory.Database().Insert<Base_FormAttributeValue>(formattributevalue, isOpenTrans);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("�Զ������" + ex);
            }
        }
        /// <summary>
        /// ��ȡ��̬������(����JSON)
        /// </summary>
        /// <returns></returns>
        public string GetBuildForm(string ObjectId)
        {
            Base_FormAttributeValue formattributevalue = DataFactory.Database().FindEntity<Base_FormAttributeValue>("ObjectId", ObjectId);
            if (!string.IsNullOrEmpty(formattributevalue.ObjectParameterJson) && formattributevalue.ObjectParameterJson.Length > 2)
            {
                return formattributevalue.ObjectParameterJson.Replace("{", "").Replace("}", "") + ",";
            }
            else
            {
                return "";
            }
        }

        #region ƴ�ӱ�������html��
        /// <summary>
        /// ���ɱ�table
        /// </summary>
        /// <param name="ColumnCount">�Ű�ģʽ��1����2�б�2����4�У�3���� 6��</param>
        /// <param name="ModuleId">ģ��Id</param>
        /// <returns></returns>
        public string CreateBuildFormTable(int ColumnCount, string ModuleId)
        {
            List<Base_FormAttribute> ListData = this.GetList(ModuleId); ;
            return CreateBuildFormTable(ColumnCount, ListData); ;
        }
        /// <summary>
        /// ���ɱ�table
        /// </summary>
        /// <param name="ColumnCount">�Ű�ģʽ��1����2�б�2����4�У�3���� 6��</param>
        /// <param name="ListData">����Դ</param>
        /// <returns></returns>
        public string CreateBuildFormTable(int ColumnCount, List<Base_FormAttribute> ListData)
        {
            StringBuilder FormTable = new StringBuilder();
            FormTable.Append("<table class=\"form\">\r\n        <tr>\r\n");
            int RowIndex = 1;
            foreach (Base_FormAttribute entity in ListData)
            {
                if (entity.PropertyName == null && entity.ControlId == null)
                {
                    continue;
                }
                string PropertyName = entity.PropertyName;                                            //��������
                int ControlColspan = CommonHelper.GetInt(entity.ControlColspan);                      //�ϲ���
                FormTable.Append("            <th class='formTitle'>" + PropertyName + "��</th>\r\n");
                if (ControlColspan == 0)
                {
                    FormTable.Append("            <td class='formValue'>\r\n                " + CreateControl(entity) + "\r\n            </td>\r\n");
                }
                else
                {
                    FormTable.Append("            <td colspan='" + ControlColspan + "' class='formValue'>\r\n                " + CreateControl(entity) + "\r\n            </td>\r\n");
                    FormTable.Append("        </tr>\r\n        <tr>\r\n");
                    RowIndex += ControlColspan - 1;
                }
                if (RowIndex % ColumnCount == 0)
                {
                    FormTable.Append("        </tr>\r\n        <tr>\r\n");
                }
                RowIndex++;
            }
            FormTable.Append("        </tr>\r\n    </table>\r\n");
            return FormTable.ToString().Replace("<tr>\r\n</tr>", "");
        }
        /// <summary>
        /// ���ɿؼ�
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string CreateControl(Base_FormAttribute entity)
        {
            StringBuilder sbControl = new StringBuilder();
            string PropertyName = entity.PropertyName;                          //��������
            string ControlId = entity.ControlId;                                //�ؼ�Id
            string ControlType = entity.ControlType;                            //�ؼ�����
            string ControlStyle = entity.ControlStyle;                          //�ؼ���ʽ
            string ControlValidator = "";
            if (entity.ControlValidator != null)
            {
                ControlValidator = entity.ControlValidator.Replace("&nbsp;", "");                  //�ؼ���֤
            }
            string ImportLength = entity.ImportLength.ToString().Replace("&nbsp;", "");        //���볤��
            string AttributesProperty = "";
            if (entity.AttributesProperty != null)
            {
                AttributesProperty = entity.AttributesProperty.Replace("&nbsp;", "");              //�Զ�������
            }
            int DataSourceType = CommonHelper.GetInt(entity.DataSourceType);    //�ؼ�����Դ����
            string DataSource = entity.DataSource;                              //�ؼ�����Դ
            if (!string.IsNullOrEmpty(ControlValidator.Trim()))
            {
                ControlValidator = "datacol=\"yes\" err=\"" + PropertyName + "\" checkexpession=\"" + ControlValidator + "\"";
            }
            string maxlength = "";
            if (!string.IsNullOrEmpty(ImportLength))
            {
                maxlength = "maxlength=" + ImportLength + "";
            }
            switch (ControlType)
            {
                case "1"://�ı���
                    sbControl.Append("<input id=\"Build_" + ControlId + "\" " + maxlength + " type=\"text\" class=\"" + ControlStyle + "\" " + ControlValidator + " " + AttributesProperty + " />");
                    break;
                case "2"://������
                    if (!string.IsNullOrEmpty(DataSource))
                    {
                        if (DataSourceType == 0)
                        {
                            sbControl.Append("<select id=\"Build_" + ControlId + "\"class=\"" + ControlStyle + "\" " + ControlValidator + " " + AttributesProperty + ">");
                            sbControl.Append(DataSource);
                            sbControl.Append("</select>");
                        }
                        else
                        {
                            sbControl.Append("<select dictionaryValue=\"" + DataSource + "\" dictionary=\"yes\" id=\"Build_" + ControlId + "\"class=\"" + ControlStyle + "\" " + ControlValidator + " " + AttributesProperty + ">");
                            sbControl.Append(CreateBindDrop(DataSource));
                            sbControl.Append("</select>");
                        }
                    }
                    else
                    {
                        sbControl.Append("<select id=\"Build_" + ControlId + "\"class=\"" + ControlStyle + "\" " + ControlValidator + " " + AttributesProperty + ">");
                        sbControl.Append("</select>");
                    }
                    break;
                case "3"://���ڿ�
                    sbControl.Append("<input id=\"Build_" + ControlId + "\" " + maxlength + " type=\"text\" class=\"" + ControlStyle + "\" " + ControlValidator + " " + AttributesProperty + "/>");
                    break;
                case "4"://��  ǩ
                    sbControl.Append("<label id=\"Build_" + ControlId + "\" " + AttributesProperty + "/>");
                    break;
                case "5"://�����ı���
                    sbControl.Append("<textarea id=\"Build_" + ControlId + "\" " + maxlength + " class=\"" + ControlStyle + "\" " + ControlValidator + " " + AttributesProperty + "></textarea>");
                    break;
                default:
                    return "�ڲ����������д���";
            }
            return sbControl.ToString();
        }
        /// <summary>
        /// �������ֵ䣨������
        /// </summary>
        /// <param name="DataSource">�����ֵ�����Դ</param>
        /// <returns></returns>
        public string CreateBindDrop(string DataSource)
        {
            StringBuilder sb = new StringBuilder("<option value=''>==��ѡ��==</option>");
            Base_DataDictionaryBll base_datadictionarybll = new Base_DataDictionaryBll();
            List<Base_DataDictionaryDetail> ListData = base_datadictionarybll.GetDataDictionaryDetailListByCode(DataSource);
            if (ListData != null)
            {
                foreach (Base_DataDictionaryDetail item in ListData)
                {
                    sb.Append("<option value=\"" + item.Code + "\">" + item.FullName + "</option>");
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}