using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace messageBoard
{
    static class RequestExtension
    {
        public static string GetRealIp(this HttpRequest request)
        {
            if (request.ServerVariables["HTTP_VIA"] == null)//有無代理伺服器
            {
                return request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else
            {
                return request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
        }
        public static bool RequestStringNull(this HttpRequest request,string param)
        {
            if (request.QueryString[param]==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}