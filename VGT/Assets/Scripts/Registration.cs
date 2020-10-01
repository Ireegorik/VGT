using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Net;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.IO;
using System.Text;
public class Registration : MonoBehaviour
{
    public InputField login;
    public InputField Password;
    public InputField PasswordRep;
    public InputField Email;
    public GameObject Auth;
    public Text Resp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    class RegisterRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public void RegisterButton()
    {
      if(  RequestSender.PostRegister(login.text, Password.text, PasswordRep.text, Email.text) == "Пароль и подтверждение пароля не совпадают!")
        {
            Resp.text = "Пароль и подтверждение пароля не совпадают!";
        }
        else
        {
            RegisterSighin();
        }
    }
    public void RegisterSighin()
    {
        Auth.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
