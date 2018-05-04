<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head >
    <meta name="viewport" content="width=device-width" />
    <title>ģ�����ñ��</title>
    <!--��ܱ���start-->
    <link href="/Content/Styles/style.css" rel="stylesheet" />
    <script src="/Content/Scripts/jquery-1.8.2.min.js"></script>
    <script src="/Content/Scripts/framework.js"></script>
    <!--��ܱ���end-->
    <!--����֤���start-->
    <script src="/Content/Scripts/JValidator.js"></script>
    <!--����֤���end-->
    <script type="text/javascript">
        $(function () {
            if (IsNullOrEmpty(GetQuery('key'))) {
                InitControl()
            }
        })
        //�����¼�
        function AcceptClick() {
            if (!CheckDataValid('#form1')) {
                return false;
            }
            var postData = GetWebControls("#form1");
            getAjax("/CodeMaticModule/Base_Module/SubmitBase_ModuleForm?key=" + GetQuery('key'), postData, function (data) {
                if (data.toLocaleLowerCase() == 'true') {
                    top.jBox.tip('��ϲ���������ɹ�', 'success');
                    top.jBox.close();//�رյ�ǰ����
                    top.$('#' + TabIframeId())[0].contentWindow.windowload();//ˢ�¸�ҳ��
                } else {
                    top.jBox.tip('�ܱ�Ǹ������ʧ��', 'error');
                }
            });
        }
        //�õ�һ������ʵ��
        function InitControl() {
            getAjax("/CodeMaticModule/Base_Module/GetBase_ModuleForm", { key: GetQuery('key') }, function (data) {
                var data = eval("(" + data + ")");
                SetWebControls(data);
            });
        }
    </script>
</head>
<body>
    <form id="form1">
        <table border="0" cellpadding="0" cellspacing="0" class="" style="padding-top: 20px;">
        </table>
    </form>
</body>
</html>
