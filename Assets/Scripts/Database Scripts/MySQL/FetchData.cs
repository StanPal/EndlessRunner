using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchData : MonoBehaviour
{
    public InputField playerNameField;
    public InputField scorerangeField;
    public void Start()
    {
           
    }

    public void CallPlayer()
    {
        StartCoroutine(GetPlayer());
    }

    public void CallAllPlayers()
    {
        StartCoroutine(GetAllPlayers());
    }

    public void CallAccount()
    {
        StartCoroutine(GetAccount());
    }

    public void CallJoin()
    {
        StartCoroutine(GetAccountPlayer());
    }

    public void CallMaxScore()
    {
        StartCoroutine(GetMaxScore());
    }

    public void CallScoreRange()
    {
        StartCoroutine(GetScoreRange());
    }

    IEnumerator GetAccountPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("getplayername", playerNameField.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/fetchjoin.php", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

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

    IEnumerator GetAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("getfirstname", playerNameField.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/fetchaccount.php", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

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

    IEnumerator GetPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("getplayername", playerNameField.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/fetchplayer.php", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

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

    IEnumerator GetAllPlayers()
    {
        WWWForm form = new WWWForm();
        form.AddField("getplayername", playerNameField.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/fetchallplayers.php", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

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

    IEnumerator GetScoreRange()
    {
        WWWForm form = new WWWForm();
        form.AddField("getscorerange", scorerangeField.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/fetchscorerange.php", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

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

    IEnumerator GetMaxScore()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/dbFinalProject/fetchhighestscore.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


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
