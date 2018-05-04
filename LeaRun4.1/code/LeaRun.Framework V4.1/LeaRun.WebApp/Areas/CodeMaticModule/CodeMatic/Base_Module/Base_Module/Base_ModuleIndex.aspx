<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Src="~/UserControl/LoadButton.ascx" TagPrefix="uc1" TagName="LoadButton" %>

<!DOCTYPE html>

<html>
<head >
    <meta name="viewport" content="width=device-width" />
    <title>ģ�����ñ��б�</title>
    <!--��ܱ���start-->
    <link href="/Content/Styles/style.css" rel="stylesheet" />
    <script src="/Content/Scripts/jquery-1.8.2.min.js"></script>
    <script src="/Content/Scripts/framework.js"></script>
    <!--��ܱ���end-->
    <!--������start-->
    <script src="/Content/Scripts/PqGrid/jquery-ui.min.js"></script>
    <script src="/Content/Scripts/PqGrid/pqgrid.min.js" charset="GBK"></script>
    <link href="/Content/Scripts/PqGrid/pqgrid.min.css" rel="stylesheet" />
    <!--������end-->
    <script type="text/javascript">
        $(function () {
            GetGrid();
        });
        //����ģ�����ñ��б�
        function GetGrid() {
            //url�������ַ
            var url = "/CodeMaticModule/Base_Module/Base_ModuleGrid?Parm_Key_Value=";
            //colM����ͷ����
            var colM = [

            ];
            //sort��Ҫ��ʾ�ֶ�,�����Ӧ
            var sort = [

            ];
            PQLoadGridNoPage("#grid_paging", url, colM, sort)
            $("#grid_paging").pqGrid({ topVisible:false });
            pqGridResize("#grid_paging", -83);
        }
        //ˢ��
        function windowload() {
            $("#grid_paging").pqGrid("refreshDataAndView");
        }
    </script>
</head>
<body>
</body>
</html>
