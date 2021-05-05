using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField playerNameField;
    public InputField firstnameField;
    public InputField lastNameField;
    public InputField nickNameField; 
    public InputField emailField;
    public InputField DOBField;
    public Toggle optinToggle; 
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Registeruser());
    }

    IEnumerator Registeruser()
    {

        WWWForm form = new WWWForm();
        form.AddField("playername", playerNameField.text);
        form.AddField("firstname", firstnameField.text);
        form.AddField("lastname", lastNameField.text);
        form.AddField("nickname", nickNameField.text);
        form.AddField("DOB", DOBField.text);
        form.AddField("email", emailField.text);
        form.AddField("optin", optinToggle.isOn.ToString());
        form.AddField("lastlogin", System.DateTime.Now.ToShortDateString());
        form.AddField("score", 0);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/dbFinalProject/register.php", form))
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
                Debug.Log("Form upload complete!");
                Debug.Log("Player name: " + playerNameField.text);
                Debug.Log("Date: " + System.DateTime.Now.ToShortDateString());
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }
        public void VerifyInputs()
        {
        submitButton.interactable = (playerNameField.text != string.Empty && firstnameField.text != string.Empty && lastNameField.text != string.Empty && emailField.text != string.Empty);   
        }
}
       

