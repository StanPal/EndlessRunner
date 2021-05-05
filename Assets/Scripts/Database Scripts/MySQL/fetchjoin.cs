using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class fetchjoin : MonoBehaviour
{
    public InputField playerNameField;
    public void Start()
    {
        // A correct website page.
        //StartCoroutine(GetMaxScore());

    }

    public void CallJoin()
    {
        StartCoroutine(GetAccountPlayer());
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
}