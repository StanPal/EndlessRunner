using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySQLLogin : MonoBehaviour
{
    public InputField playerNameField;
    public Button submitbutton;
    public static string loggedinplayer { get; private set; }

    public void CallLogin()
    {
            StartCoroutine(PlayerLogin());
        
    }

    IEnumerator PlayerLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("playername", playerNameField.text);
        form.AddField("lastlogin", System.DateTime.Now.ToShortDateString());

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/login.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log("Logged in: " + playerNameField.text);
                Debug.Log(webRequest.downloadHandler.text);
                loggedinplayer = playerNameField.text;
                GoToNextScene();
            }
        }
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene("Main");
    }
}
