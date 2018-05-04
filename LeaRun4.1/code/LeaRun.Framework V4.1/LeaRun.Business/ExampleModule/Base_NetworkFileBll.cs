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
using System.Data;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ����Ӳ���ļ���
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.10.16 10:54</date>
    /// </author>
    /// </summary>
    public class Base_NetworkFileBll : RepositoryFactory<Base_NetworkFile>
    {
        /// <summary>
        /// �����ļ���Id ��ѯ�������ļ��У��ݹ飩
        /// </summary>
        /// <param name="FolderId">�ļ�������</param>
        /// <returns></returns>
        public List<Base_NetworkFolder> GetChildrenNodeList(string FolderId)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"WITH  cte
                                  AS ( SELECT   a.FolderId ,
                                                a.ParentId
                                       FROM     Base_NetworkFolder a
                                       WHERE    FolderId = @FolderId
                                       UNION ALL
                                       SELECT   k.FolderId ,
                                                k.ParentId
                                       FROM     dbo.Base_NetworkFolder k
                                                INNER JOIN cte c ON c.FolderId = k.ParentId
                                     )
                            SELECT  *
                            FROM    Base_NetworkFolder
                            WHERE   FolderId IN ( SELECT FolderId FROM cte )");
            parameter.Add(DbFactory.CreateDbParameter("@FolderId", FolderId));
            return DataFactory.Database().FindListBySql<Base_NetworkFolder>(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// ��ȡ�ļ����ļ��� �б�
        /// </summary>
        /// <param name="keywords">�ļ�����������</param>
        /// <param name="FolderId">�ļ���ID</param>
        /// <param name="DepartmentId">�û�ID</param>
        /// <returns></returns>
        public DataTable GetList(string keywords, string FolderId, string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            if (string.IsNullOrEmpty(keywords))
            {
                strSql.Append(@"SELECT  *
                                FROM    ( SELECT    NetworkFileId AS Id ,	--����
                                                    FolderId ,				--�ļ�������
                                                    filename AS fullname,
                                                    FILENAME ,				--�ļ�����
                                                    FileSize ,				--�ļ���С
                                                    FileType ,				--�ļ�����
                                                    Icon ,					--�ļ�ͼ��
                                                    CreateDate ,			--����ʱ��
                                                    CreateUserId,			--������Id
                                                    CreateUserName ,		--������
                                                    2 AS IsPublic ,		    --�Ƿ񹫹� 1-������0-�ҵ�
                                                    0 AS SortCode ,		    --�������
                                                    0 AS Sort				--����0-�ļ���1-�ļ���
                                          FROM      Base_NetworkFile
                                          UNION
                                          SELECT    FolderId AS Id ,		--����
                                                    ParentId AS FolderId ,	--�ļ�������
                                                    FolderName AS fullname,
                                                    FolderName ,			--�ļ�������
                                                    '' AS FileSize ,		--�ļ��д�С
                                                    '�ļ���' AS FileType ,	--����
                                                    '-1' AS Icon ,			--ͼ��
                                                    CreateDate ,			--����ʱ��
                                                    CreateUserId,			--������Id
                                                    CreateUserName ,		--������
                                                    IsPublic ,				--�Ƿ񹫹� 1-������0-�ҵ�
                                                    SortCode ,				--�������
                                                    1 AS Sort				--����0-�ļ���1-�ļ���
                                          FROM      Base_NetworkFolder
                                        ) A WHERE 1=1 AND FolderId = @FolderId ");
            }
            else
            {
                strSql.Append(@" WITH   cte
                                      AS ( SELECT   a.FolderId ,
                                                    a.ParentId
                                           FROM     Base_NetworkFolder a
                                           WHERE    FolderId = @FolderId
                                           UNION ALL
                                           SELECT   k.FolderId ,
                                                    k.ParentId
                                           FROM     dbo.Base_NetworkFolder k
                                                    INNER JOIN cte c ON c.FolderId = k.ParentId
                                         )
                                SELECT  NetworkFileId AS Id ,	--����
                                        FolderId ,				--�ļ�������
                                        filename AS fullname ,
                                        FILENAME ,				--�ļ�����
                                        FileSize ,				--�ļ���С
                                        FileType ,				--�ļ�����
                                        Icon ,					--�ļ�ͼ��
                                        CreateDate ,			--����ʱ��
                                        CreateUserId ,			--������Id
                                        CreateUserName ,		--������
                                        2 AS IsPublic ,		    --�Ƿ񹫹� 1-������0-�ҵ�
                                        0 AS SortCode ,		    --�������
                                        0 AS Sort				--����0-�ļ���1-�ļ���
                                FROM    Base_NetworkFile
                                WHERE   FileName LIKE @FileName
                                        AND FolderId IN ( SELECT    FolderId FROM cte )");
                parameter.Add(DbFactory.CreateDbParameter("@FileName", "%" + keywords + "%"));
            }
            parameter.Add(DbFactory.CreateDbParameter("@FolderId", FolderId));
            if (!string.IsNullOrEmpty(UserId))
            {
                strSql.Append(" AND CreateUserId = @UserId");
                parameter.Add(DbFactory.CreateDbParameter("@UserId", UserId));
            }
            strSql.Append(" ORDER BY Sort DESC , SortCode ASC,CreateDate DESC");
            return Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
        }
    }
}