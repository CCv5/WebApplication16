<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication16.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        textarea {
            width: 100%;
            height: 100%;
        }
    </style>
    <link href="css/easyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="css/easyUI/themes/icon.css" rel="stylesheet" />
    <link href="css/div.css" rel="stylesheet" />
    <script src="js/jquery-2.2.3.min.js"></script>
    <script src="js/jquery.easyui.min.js"></script>
    <script>



        $(function () {

            $('#tree').tree({

                onClick: function (node) {

                    $.post(
                     'treedata.ashx',
                     {
                         node: node.text
                     },
                     function (msg) {

                         var strs = msg.split('|')
                         if (strs.length > 0) {
                             $("#img").attr("src", strs[0]);
                             $("#txtArea").val(strs[1]);
                         } else {
                             alert('删除失败');
                         }
                     }
                 );
                }

            })
        })

    </script>
</head>
<body>


    <span style="font-size: 16px; font-weight: bold;margin-left: 20px;">生物分子列表</span>
    <span style="margin-left: 320px; font-size: 16px; font-weight: bold">数据曲线</span>
    <span style="margin-left: 340px; font-size: 16px; font-weight: bold">分子数据</span>


    <div style="margin: 20px 0;"></div>
    <div class="left" style="padding: 5px; width: 400px;  border: dashed">
        <ul class="easyui-tree" id="tree">
                   <%=tree %>
           
 
        </ul>
    </div>

    <div class="left" style="padding: 5px; width: 400px;  border: dashed; ">
        <img id="img" width="400" height="300" />
    </div>
    <div class="left" style="padding: 5px; border: dashed;  width: 400px;height:300px;">
        <textarea id="txtArea">
          
        </textarea>
    </div>

</body>

</html>
