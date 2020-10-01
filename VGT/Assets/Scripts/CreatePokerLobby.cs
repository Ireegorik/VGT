using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VGTDataStore.Core.Models.Enums;

public class CreatePokerLobby : MonoBehaviour
{
    public GameObject Play;
    public GameObject Lobby;
    public InputField count;
    public class PokerGamePlayer
    {
        public Guid UserId { get; set; }

        public int SeatPlace { get; set; }

        public PokerPlayerStatus Status { get; set; }

        public UserRolesForPoker UserRole { get; set; }

        public int ChipsForGame { get; set; }

        public PokerGamePlayer(
            Guid userId,
            int place,
            UserRolesForPoker role,
            int chipsForGame)
        {
            UserId = userId;
            SeatPlace = place;
            Status = PokerPlayerStatus.WaitingForStart;
            UserRole = role;

            if (UserRole == UserRolesForPoker.Stickman)
                ChipsForGame = 0;
            else
                ChipsForGame = chipsForGame;
        }
    }
    public void Create()
    {
        dynamic s= JsonConvert.DeserializeObject( RequestSender.PostRegisterSession(Convert.ToInt32(count.text), Play.GetComponent<Player>().userId,1,"WaitingForGame","Stickman",1000));
        Lobby.SetActive(true);
        Lobby.GetComponent<Lobby>().SessionId = s.gameSessionId;
        Lobby.GetComponent<Lobby>().Join();
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
