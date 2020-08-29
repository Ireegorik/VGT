using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField login;
    public InputField Password;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RegisterButton()
    {
        
        WebRequest request = WebRequest.Create($"http://localhost:59065/api/Auth/register/Login={login.text}&Password={Password.text}");
        WebResponse response = request.GetResponse();
        print( response.ToString());
    }
}
