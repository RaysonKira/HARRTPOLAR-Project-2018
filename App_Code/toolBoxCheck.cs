using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for toolBoxCheck
/// </summary>
public class toolBoxCheck
{
    public toolBoxCheck()
    {

    }

    public toolBoxCheck(string userId, string userName, string password, string buttonEnabled, string email, string tools)
    {
        userIdClass = userId;
        userNameClass = userName;
        passwordClass = password;
        buttonEnabledClass = buttonEnabled;
        emailClass = email;
        toolsClass = tools;
    }

    public string userIdClass { get; set; }
    public string userNameClass { get; set; }
    public string passwordClass { get; set; }
    public string buttonEnabledClass { get; set; }
    public string emailClass { get; set; }
    public string toolsClass { get; set; }

}