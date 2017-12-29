<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PluginSys.Web._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="appPluginForm" name="appPluginForm" enctype="multipart/form-data" method="post"
    action="http://test.grih.gree.com/InternalAPI/AddAppPlugin?">
    <input type="hidden" id="appId" name="appId" />
    <input type="hidden" id="appr" name="appr" />
    <input type="hidden" id="appt" name="appt" />
    <input type="hidden" id="apivc" name="apivc" />
    机型编码<input name="mid" id="mid" value="" /><br />
    插件版本<input name="ver" id="ver" value="1.0" /><br />
    适用的APP版本<input name="appVer" id="appVer" value="小于100的整数" /><br />
    中文描述<input name="descriptionCN" id="descriptionCN" value="" /><br />
    英文描述<input name="descriptionEN" id="descriptionEN" value="" /><br />
    <input type="file" name="POST" />
    <input type="submit" id="uplaodbtn" value="保存" />
    </form>
    <script type="text/javascript">

    
        $("#appPluginForm").submit(function () {
            var appId = "5185135031351000951";
       
//          var  appt = "2017-10-14 9:14:00";
//            var appKey = "067b90d133f1312476f2599c77260fd7";
//            var appr = Math.floor(Math.random() * 1000000);
//            var apivc = "123123";

//            //var filename = $("#file").val();
//            var mid = "99999";
//            var ver = "1.0";
//            var appVer = "1";
//            var descriptionCN = "wu";
//            var descriptionEN = "none";


            $("#appId").val(appId);
            $("#appt").val("2017-10-24 11:05:11");
            $("#appr").val("33808");
            $("#apivc").val("4CF3966BB34B5B25D37DA250D724D75B");
            $("#filename").val(filename);
            $("#mid").val("99999");
            $("#ver").val("1.0");
            $("#appVer").val("1");
            $("#descriptionCN").val("wu");
            $("#descriptionEN").val("none");

            return true;

        });

        $(function () {

        });
    </script>
</body>
</html>
