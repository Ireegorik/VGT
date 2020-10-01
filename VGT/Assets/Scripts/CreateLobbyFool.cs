using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLobbyFool : MonoBehaviour
{
    public GameObject Lobby; 
    class  GameSettings
    {
        public void GameSetting()
        {
            CountCards = 0;
            CountPlayers = 0;
            login = "";
        }
       public int CountCards { get; set; }
       public int CountPlayers { get; set; }
       public string login { get; set; }
    }
    static GameSettings settings = new GameSettings();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setModeGame(string Mode)
    {
        settings.login = Mode;
    }
    public void setCountCards(int count)
    {
        settings.CountCards = count;
    }
    public void setCountPlayers(int count)
    {
        settings.CountPlayers = count;
    }
    public void Create()
    {
        if ((settings.CountCards == 0)|| (settings.CountPlayers == 0)|| (settings.login == ""))
        {

        }
        else
        {
            Lobby.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
