using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UpdatePlayers : MonoBehaviour
{
    public InputField playerNameField;
    public InputField newNameField;
    public Button updateButton;

    public void CallRegister()
    {
        StartCoroutine(UpdateUser());
    }

    IEnumerator UpdateUser()
    {

        WWWForm form = new WWWForm();
        form.AddField("getplayername", playerNameField.text);
        form.AddField("newplayername", newNameField.text);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/updateplayer.php", form))
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
    public void VerifyInputs()
    {
        updateButton.interactable = (playerNameField.text != string.Empty && newNameField.text != string.Empty);
    }
}
