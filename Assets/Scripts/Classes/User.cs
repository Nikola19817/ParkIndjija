using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public int userID { get; set; }
    public string userName{ get; set; }
    public string userPassword { get; set; }
    public string userRole { get; set; }

    public User(int userID, string userName, string userPassword, string userRole)
    {
        this.userID = userID;
        this.userName = userName;
        this.userPassword = userPassword;
        this.userRole = userRole;
    }
}
