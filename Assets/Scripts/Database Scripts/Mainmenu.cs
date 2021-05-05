using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Mainmenu : MonoBehaviour
{
    public void GoToRegisterScreen()
    {
        SceneManager.LoadScene("Register Menu");
    }

    public void GoToMySQLLogin()
    {
        SceneManager.LoadScene("MySQLLogin Screen");
    }

    public void GoToMongoDBLogin()
    {
        SceneManager.LoadScene("MongoLogin");
    }
 
}
