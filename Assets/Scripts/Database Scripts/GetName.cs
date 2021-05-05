using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetName : MonoBehaviour
{
    public Text playername;
    public static bool usingMongoDB;
    void Start()
    {
        if (!string.IsNullOrEmpty(MySQLLogin.loggedinplayer))
        {
            playername.text = MySQLLogin.loggedinplayer;
        }
        if(!string.IsNullOrEmpty(MongoDBQuery.loggedin))
        {
            usingMongoDB = true;
            playername.text = MongoDBQuery.loggedin;
        }
    }
}
