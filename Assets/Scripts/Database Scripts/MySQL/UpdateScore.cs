using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class UpdateScore : MonoBehaviour
{


    public void Start()
    {
        if (!GetName.usingMongoDB)
        {
            StartCoroutine(UpdateUser());
        }
    }

    IEnumerator UpdateUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("getplayername", MySQLLogin.loggedinplayer);
        form.AddField("score", PlayerData.gethighscore);
        Debug.Log(PlayerData.gethighscore);
        Debug.Log(MySQLLogin.loggedinplayer);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/updatescore.php", form))
        {
            //Delay this until we gather the rest of the code. 
            yield return webRequest.SendWebRequest();
            //connection work
            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }
}
