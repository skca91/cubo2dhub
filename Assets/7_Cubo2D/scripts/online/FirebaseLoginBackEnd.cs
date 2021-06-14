using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
/*
using Firebase;
using Firebase.Auth;
using Firebase.Unity.Editor;
*/
using System.Threading.Tasks;
//using Firebase.Extensions;
using Proyecto26;

public class FirebaseLoginBackEnd : MonoBehaviour, IFirebaseLoginBackEnd {

    [SerializeField]
    GameObject InicioSessionMenu;
    [SerializeField]
    GameObject RegistroMenu;
    [SerializeField]
    InputField NombreInputField;
    [SerializeField]
    InputField ApellidoInputField;
    [SerializeField]
    InputField UsuarioInputField;
    [SerializeField]
    InputField PasswordInputField;
    [SerializeField]
    InputField UsuarioRegistroInputField;
    [SerializeField]
    InputField PasswordRegistroInputField;
    [SerializeField]
    Toggle TerminosCondicionesToggle;
    [SerializeField]
    menu NoInternetMenu;
    [SerializeField]
    GameObject LoginErrorMenuGO;
    [SerializeField]
    Text ErrorText;
    [SerializeField]
    InputField ResetPasswordInputField;
    [SerializeField]
    GameObject ResetPasswordMenu;
    [SerializeField]
    FirebaseWebAuthUserCubo2dView MenuFirebase;

    string email = "u@m.com";
    string password = "123456";
    [SerializeField]
    string WebApiKey = "";
    /*
    FirebaseAuth auth;
    FirebaseApp app;
    FirebaseUser user;
    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    */
    IMenuControlador LoginErrorMenu;

    string Token = "";
    FirebaseWebAuthUserCubo2d user;
    // Use this for initialization
    void Start() {

        LoginErrorMenu = LoginErrorMenuGO.GetComponent<IMenuControlador>();


        InitializeFirebase();

        OnFirebaseStart();
    }

    public void OnFirebaseStart() {

        /*Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // EstaCargando(false);
                //SendMessage("MostrarTelex",idiomaV2.textoTraducido("todo ok"));
                InitializeFirebase();
            }
            else
            {
                //  EstaCargando(false);
                //  SendMessage("MostrarTelex", idiomaV2.textoTraducido("Problema de dependencias"));
                Debug.LogError(
                    "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });*/
    }
    // Update is called once per frame
    void Update() {

    }
    public void CerrarSesion() {
        //auth.SignOut();
        PlayerPrefs.SetString("UserEmail", "");
        PlayerPrefs.SetString("Password", "");

    }
    public void verificarSesionAnterior()
    {

        if (Application.internetReachability.Equals(NetworkReachability.NotReachable)) {
            ErrorText.text = "Sin internet.";
            NoInternetMenu.showMenu();
            return;
        }

#if UNITY_EDITOR

        email = "stephanie.correa24@cubo2d.com";
        password = "123456";
#else

        

#endif

        UsuarioInputField.text = PlayerPrefs.GetString("UserEmail", "");
        PasswordInputField.text = PlayerPrefs.GetString("Password", "");

        if (user == null || string.IsNullOrEmpty(user.idToken))
        {
            if (!string.IsNullOrEmpty(UsuarioInputField.text) && !string.IsNullOrEmpty(PasswordInputField.text))
            {
                IniciarSession();
            }
            else {
                //InicioSessionMenu.gameObject.SendMessage("showMenu");
            }

        }
        else {
            GetToken();
        }

    }

    public void IniciarSessionAnonimo() {

        /* if (PlayerPrefs.GetString("UserEmail", "") != "")
         {
             UsuarioInputField.text = PlayerPrefs.GetString("UserEmail", "");
             PasswordInputField.text = PlayerPrefs.GetString("Password", "");
             IniciarSession();
             return;
         }
         else {
             RegistroAnonimo();
             return;
         }*/
        /*

        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={WebApiKey}",
            payLoad).Then(response => {

                Debug.Log("Response StatusCode: " + response.StatusCode);

                if (response.StatusCode.Equals(200))
                {
                    user = JsonUtility.FromJson<FirebaseWebAuthUserCubo2d>(response.Text);

                    InicioSessionMenu.gameObject.SendMessage("hideMenu");
                    GetToken();

                    PlayerPrefs.SetString("UserEmail", email);
                    PlayerPrefs.SetString("Password", password);
                    //Debug.Log(user.ToPrettyString());
                }
                else
                {
                    ErrorText.text = "StatusCode: " + response.StatusCode;
                    LoginErrorMenu.showMenu();
                }
            }).Catch(error => {
                Debug.Log("error Message: " + error.Message);
                ErrorText.text = "Error: " + error.Message;
                LoginErrorMenu.showMenu();
            });*/
    }


    public void OnClickSetCredenciales() {
        UsuarioInputField.text = $"test2021@cubo2d.com";
        PasswordInputField.text = "123456";
    }
    public void IniciarSession() {

        

        email = UsuarioInputField.text;
        password = PasswordInputField.text;

        if (email.Length < 7 || password.Length < 4)
        {

            ErrorText.text = "Email or password very short";
            LoginErrorMenu.showMenu();
            return;
        }


        Debug.Log("payload: " + email + " " + password);
        var payLoad = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";
        
        RestClient.Post($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key={WebApiKey}",
            payLoad).Then(response => {

                Debug.Log("Response StatusCode: " + response.StatusCode);

                if (response.StatusCode.Equals(200))
                {
                    user = JsonUtility.FromJson<FirebaseWebAuthUserCubo2d>(response.Text);

                    InicioSessionMenu.gameObject.SendMessage("hideMenu");
                    GetToken();

                    PlayerPrefs.SetString("UserEmail", email);
                    PlayerPrefs.SetString("Password", password);
                    //Debug.Log(user.ToPrettyString());
                }
                else {
                    ErrorText.text = "StatusCode: " + response.StatusCode;
                    LoginErrorMenu.showMenu();
                }
            }).Catch( error => {
                Debug.Log("error Message: " + error.Message);
                ErrorText.text = "Error: " + error.Message;
                LoginErrorMenu.showMenu();
            });

        /*
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                ErrorText.text = "Error: " + task.Exception;
                LoginErrorMenu.showMenu();
                return;
            }
            user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",user.DisplayName, user.UserId);

            InicioSessionMenu.gameObject.SendMessage("hideMenu");
            GetToken();
        });*/

    }

    public void IniciarSessionTokenFacebook(string tokenFacebook, string correo, string facebookId)
    {

        /*
         curl 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key=[API_KEY]' \
-H 'Content-Type: application/json' \
--data-binary '
        {
        "postBody":"access_token=[FACEBOOK_ACCESS_TOKEN]&providerId=[facebook.com]",
        "requestUri":"[http://localhost]",
        "returnIdpCredential":true,
        "returnSecureToken":true
        }'
         */

        //Debug.Log("payload: " + email + " " + password);

        var payLoad ="{"+
        "\"postBody\":\"access_token="+ tokenFacebook + "&providerId=facebook.com\"," +
        "\"requestUri\":\"https://login-app-5aa55.firebaseapp.com/__/auth/handler\"," +
        "\"returnIdpCredential\":true,"+
        "\"returnSecureToken\":true"+
        "}";
        
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={WebApiKey}",
            payLoad).Then(response => {

                Debug.Log("Response StatusCode: " + response.StatusCode);

                if (response.StatusCode.Equals(200))
                {
                    user = JsonUtility.FromJson<FirebaseWebAuthUserCubo2d>(response.Text);

                    InicioSessionMenu.gameObject.SendMessage("hideMenu");
                    GetToken();

                    PlayerPrefs.SetString("UserEmail", user.email);
                    PlayerPrefs.SetString("displayName", user.displayName);
                    PlayerPrefs.SetString("idToken", user.idToken);
                    PlayerPrefs.SetString("localId", user.localId);
                    Debug.Log(user.ToPrettyString());
                }
                else
                {
                    ErrorText.text = "StatusCode: " + response.StatusCode;
                    LoginErrorMenu.showMenu();
                }
            
            }).Catch(error => {
                Debug.Log("error Message: " + error.Message);
                ErrorText.text = "Error: " + error.Message;
                LoginErrorMenu.showMenu();
            });

        
    }

    public void GetToken() {
        
        MenuFirebase?.setFirebaseWebAuthUserCubo2d(user);
        Token = user.idToken;
        SendMessage("VerificarIdFirebase", Token);

    }

    public void OnClickDevLogToken() {
#if UNITY_EDITOR
        Debug.Log("token: " + Token);
#endif
    }

    public void Registro() {

        //UsuarioRegistroInputField.text = $"test@cubo2d.com";
        //PasswordRegistroInputField.text = "123456";

        email = UsuarioRegistroInputField.text;
        password = PasswordRegistroInputField.text;
        string nombre = (string.IsNullOrEmpty(NombreInputField?.text) ? "Usuario" : NombreInputField?.text);
        string apellido = (string.IsNullOrEmpty(ApellidoInputField?.text) ? $"{Random.Range(0, 9999999).ToString("00000")}" : ApellidoInputField?.text);

        if (NombreInputField?.text.Length < 2 || ApellidoInputField?.text.Length < 2) {
            ErrorText.text = "Falta nombre y apellido";
            LoginErrorMenu.showMenu();
            return;
        }

        if (email.Length < 7 || password.Length < 4)
        {
            ErrorText.text = "Error correo o clave muy corta";
            LoginErrorMenu.showMenu();
            return;
        }
        string DisplayName= $"{ nombre }-{apellido}";

        var payLoad = $"{{\"displayName\":\"{DisplayName}\",\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";
        RestClient.Post($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key={WebApiKey}",
            payLoad).Then(response => {

                Debug.Log("Response StatusCode: " + response.StatusCode);

                if (response.StatusCode.ToString().Equals("200"))
                {
                    user = JsonUtility.FromJson<FirebaseWebAuthUserCubo2d>(response.Text);

                    InicioSessionMenu.gameObject.SendMessage("hideMenu");
                    GetToken();

                    PlayerPrefs.SetString("UserEmail", email);
                    PlayerPrefs.SetString("Password", password);

                    SendMessage("RegistroInternoBackEnd", user);
                    Debug.Log(user.ToPrettyString());
                }
                else
                {
                    ErrorText.text = "StatusCode: " + response.StatusCode;
                    LoginErrorMenu.showMenu();
                }
            }).Catch(error => {
                
                Debug.Log("error Message: " + error.Message);
                RequestException request = (RequestException)error;
                if (request.Response.Contains("EMAIL_EXISTS"))
                {
                    ErrorText.text = "El correo:\n"+email+"\nya se encuentra registrado,\nuse la opcion para recuperar password";
                }
                else {
                    ErrorText.text = "Error: " + error.Message;
                    ErrorText.text = "\n" + request.Response;
                }
                LoginErrorMenu.showMenu();
            });
    }

    /// <summary>
    /// Puedo registrarme pero no se como iniciar sesion de nuevo, bueno si se pero la api no responde bien por el resquesuri
    /// </summary>
    public void RegistroAnonimo() {

        var payLoad = "{\"returnSecureToken\":true}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={WebApiKey}",
            payLoad).Then(response => {

                Debug.Log("Response StatusCode: " + response.StatusCode);

                if (response.StatusCode.ToString().Equals("200"))
                {
                    user = JsonUtility.FromJson<FirebaseWebAuthUserCubo2d>(response.Text);

                    InicioSessionMenu.gameObject.SendMessage("hideMenu");
                    GetToken();

                    //PlayerPrefs.SetString("UserEmail", email);
                    PlayerPrefs.SetString("localId", user.localId);

                    Debug.Log(user.ToPrettyString());
                }
                else
                {
                    ErrorText.text = "StatusCode: " + response.StatusCode;
                    LoginErrorMenu.showMenu();
                }
            }).Catch(error => {
                Debug.Log("error Message: " + error.Message);
                ErrorText.text = "Error: " + error.Message;
                LoginErrorMenu.showMenu();
            });

    }
    protected virtual void InitializeFirebase()
    {
        /*
        app = FirebaseApp.DefaultInstance;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        */
        //this.verificarSesionAnterior();
    }

    public void EnviaEmailVerifiacion(string LocalId) {

        var payLoad = $"{{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"{LocalId}\"}}";
        RestClient.Post($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/getOobConfirmationCode?key={WebApiKey}",payLoad);

    }

    //Para los hermanos
    public void VerificarIdFirebase(string Token)
    {
        Debug.Log("Token:\n"+Token);
        RestClient.DefaultRequestHeaders["Authorization"] = Token;
        //throw new NotImplementedException();
    }

    public class FirebaseWebAuthUserCubo2d {
        public string kind;
        public string idToken;
        public string email;
        public int expiresIn;
        public string localId;
        public string displayName;

        public string ToPrettyString()
        {
            string todo = "";
            todo += $"kind\t{kind}\n";
            todo += $"idToken\t{idToken}\n";
            todo += $"email\t{email}\n";
            todo += $"expiresIn\t{expiresIn}\n";
            todo += $"localId\t{localId}\n";
            todo += $"displayName\t{displayName}\n";

            return todo;
        }
    }

    public void ForgotPasswordReset(string mail) {

        var payLoad = "{ \"requestType\":\"PASSWORD_RESET\",\"email\":\""+ mail +"\"}";
        RestClient.Post($"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={WebApiKey}",
            payLoad).Then(response => {

                Debug.Log("Response StatusCode: " + response.StatusCode);

                if (response.StatusCode.ToString().Equals("200"))
                {
                    user = JsonUtility.FromJson<FirebaseWebAuthUserCubo2d>(response.Text);

                    InicioSessionMenu.gameObject.SendMessage("hideMenu");
                    GetToken();

                    //PlayerPrefs.SetString("UserEmail", email);
                    PlayerPrefs.SetString("localId", user.localId);

                    Debug.Log(user.ToPrettyString());
                }
                else
                {
                    ErrorText.text = "StatusCode: " + response.StatusCode;
                    LoginErrorMenu.showMenu();
                }
            }).Catch(error => {
                Debug.Log("error Message: " + error.Message);
                ErrorText.text = "Error: " + error.Message;
                LoginErrorMenu.showMenu();
            });

    
    }

    public void OnClickForgotPasswordReset() {
        if (ResetPasswordInputField.text.Length<5)
        {
            ForgotPasswordReset(ResetPasswordInputField.text);
        }   
    }

    public void OnClickCerrarSessionBackEnd() {
        CerrarSessionBackEnd();
        SendMessage("CerrarSession");
    }
    public void CerrarSessionBackEnd() {

        user = new FirebaseWebAuthUserCubo2d();

        PlayerPrefs.SetString("UserEmail", "");
        PlayerPrefs.SetString("localId", "");
        MenuFirebase?.setFirebaseWebAuthUserCubo2d(user);
    }


    public void RegistroInternoBackEnd(object data)
    {
        //Para ser usado en los hermanos
    }

    public void CerrarSession()
    {
        ErrorText.text = "CERRAR SESSION";
        LoginErrorMenu.showMenu();
        //Para ser usado en los hermanos
    }
}

public interface IFirebaseLoginBackEnd {
   void VerificarIdFirebase(string Token);

   void RegistroInternoBackEnd(object data);

    void CerrarSession();
}