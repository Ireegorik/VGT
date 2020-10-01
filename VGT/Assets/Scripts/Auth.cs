using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.CSharp;

public class Auth : MonoBehaviour
{
    public InputField login;
    public InputField Password;
    public GameObject Reg;
    public GameObject MainMenu;
    public GameObject Pla;
    void Start()
    {
        
    }
    class AuthResponce
    {
      public  bool Result { get; set; }
        public string Login { get; set; }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AuthEnter()
    {
      dynamic message =  RequestSender.GetAuth(login.text,Password.text);
        if (message.result == "OK")
        {
            var component = Pla.GetComponent<Player>();
            component.userId = message.userId;
            MainMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
    public void AuthRegistration()
    {
        
        Reg.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
