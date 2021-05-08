using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseWebAuthUserCubo2dView : MonoBehaviour
{
    [SerializeField]
    Text DisplayName;
    [SerializeField]
    Text Email;
    [SerializeField]
    Image Photo;
    [SerializeField]
    Button LoginIn;
    [SerializeField]
    Button LoginOut;
    // Start is called before the first frame update
    void Start()
    {
        if(LoginOut!=null)
            LoginOut.gameObject.SetActive( false );
        if (LoginIn != null)
            LoginIn.gameObject.SetActive( true );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFirebaseWebAuthUserCubo2d(FirebaseLoginBackEnd.FirebaseWebAuthUserCubo2d user) {
        if (string.IsNullOrEmpty(user.idToken))
        {
            if (LoginOut != null)
                LoginOut.gameObject.SetActive(false);
            if (LoginIn != null)
                LoginIn.gameObject.SetActive(true);
                DisplayName.text = string.Empty;
                Email.text = string.Empty; ;
        }
        else {
            if (LoginOut != null)
                LoginOut.gameObject.SetActive(true);
            if (LoginIn != null)
                LoginIn.gameObject.SetActive(false);
            DisplayName.text = user.displayName;
            Email.text = user.email;
        }
    }
}
