using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text UsersCount;
    public GameObject COJFull;
    public GameObject COJPoker;
    // Start is called before the first frame update
    void Start()
    {
      //  GetCountUsers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DurakClick()
    {
        COJFull.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void PokerClick()
    {
        COJPoker.SetActive(true);
        this.gameObject.SetActive(false);
    }
    void GetCountUsers()
    {
        WebRequest request = WebRequest.Create("http://localhost:59065/api/Info/GetPlayerCount");
        WebResponse response = request.GetResponse();
        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string Count = "";
                while ((Count = reader.ReadLine()) != null)
                {
                    UsersCount.text = Count + " пользователей";
                }
            }
        }
    }
}
