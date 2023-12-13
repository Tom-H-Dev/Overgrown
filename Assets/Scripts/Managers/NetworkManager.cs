using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    #region Singleton
    public static NetworkManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public string url = "https://u210399.gluwebsite.nl/gameapi.php";

    private IEnumerator requestAsync;

    public string token;
    public bool classChosen  = false;

    [Header("UI")]
    [SerializeField] private TMP_InputField _loginEmailField;
    [SerializeField] private TMP_InputField _loginPasswordField;
    [SerializeField] private TextMeshProUGUI _errorText;
    [SerializeField] private TMP_InputField _createUsernameField, _createEmailField, _createPasswordField;

    private void Start()
    {
        _errorText.text = "";
    }

    public void LogInPlayer()
    {
        if (requestAsync == null)
        {
            requestAsync = LoginAccount();
            StartCoroutine(requestAsync);
        }
    }

    public void CreateAccountPlayer()
    {
        if (requestAsync == null)
        {
            requestAsync = CreateAccount();
            StartCoroutine(requestAsync);
        }
    }

    public void GuestAccountPlayer()
    {
        if (requestAsync == null)
        {
            requestAsync = GuestAccount();
            StartCoroutine(requestAsync);
        }
    }

    private IEnumerator CreateAccount()
    {
        Debug.Log(_createEmailField.text);
        CreateAccountRequest request = new();
        request.email = _createEmailField.text;
        request.username = _createUsernameField.text;
        request.password = _createPasswordField.text;


        List<IMultipartFormSection> formData = new();
        string json = JsonUtility.ToJson(request);
        Debug.Log(json);
        MultipartFormDataSection entery = new("json", json);
        formData.Add(entery);
        Debug.Log(url);
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, formData))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.downloadHandler.text);
            CreateAccountResponse response = JsonUtility.FromJson<CreateAccountResponse>(webRequest.downloadHandler.text);
            Debug.Log(response.serverMessage);
            token = response.token;
        }
        requestAsync = null;
    }
    private IEnumerator LoginAccount()
    {
        LoginAccountRequest request = new();
        request.email = _loginEmailField.text;
        request.password = _loginPasswordField.text;


        List<IMultipartFormSection> formData = new();
        string json = JsonUtility.ToJson(request);

        MultipartFormDataSection entery = new("json", json);
        formData.Add(entery);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, formData))
        {
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.downloadHandler.text);
            LoginAccountResponse response = JsonUtility.FromJson<LoginAccountResponse>(webRequest.downloadHandler.text);
            if (response.serverMessage == "Succes")
            {
                
                token = response.token;
            }
            else if (response.serverMessage == "Email_not_found")
            {
                _errorText.text = "No Account Found";
            }
            else if (response.serverMessage == "WrongPassword")
            {
                _errorText.text = "Password is incorrect";
            }

            Debug.Log(response.serverMessage);
        }
        requestAsync = null;
    }
    private IEnumerator GuestAccount()
    {
        GuestAccountRequest request = new();

        List<IMultipartFormSection> formData = new();
        string json = JsonUtility.ToJson(request);

        MultipartFormDataSection entery = new("json", json);
        formData.Add(entery);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, formData))
        {
            yield return webRequest.SendWebRequest();
            GuestAccountResponse response = JsonUtility.FromJson<GuestAccountResponse>(webRequest.downloadHandler.text);
        }
        requestAsync = null;
    }
}
#region Server Classes
[System.Serializable]
public class CreateAccountRequest
{
    public string action = "create_account";

    public string email;
    public string username;
    public string password;
}
[System.Serializable]
public class CreateAccountResponse
{
    public string serverMessage;
    public string token;
}

[System.Serializable]
public class LoginAccountRequest
{
    public string action = "login_request";
    public string email;
    public string password;
}
[System.Serializable]
public class LoginAccountResponse
{
    public string serverMessage;
    public string token;
}

[System.Serializable]
public class GuestAccountRequest
{
    public string action = "guest_request";
}
[System.Serializable]
public class GuestAccountResponse
{
    public string serverMessage;
    public string token;
}


#endregion