using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VGTDataStore.Core;
using static Game;
using static RequestSender;

public class Lobby : MonoBehaviour
{
    public GameObject Game;
    public GameObject Pla;
    public GameObject Playingtable;
    public bool Change = false;
    public class Card
    {
        public Image front { get; set; }
        public Image Back { get; set; }
        public GameObject GCard { get; set; }
    }
    public class PokerPlayer
    {
        public Text Id { get; set; }
    }
    Kek kek = new Kek();
    int countPlayers,ReadyPlayers;
    public string SessionId;
    private Coroutine coroutine;
    List<PlayerInfo> playerInfos;
    PlayerInfo info;
    public List<GameObject> Players;
    private IEnumerator Refresh(float waitTime)
    {
        Playingtable.transform.GetChild(0).GetComponent<Text>().color = Color.red;
        while (true)
        {
            kek.UsersId = new List<string>();
            playerInfos = RequestSender.GetUserSession(SessionId);
            ReadyPlayers = 0;
            countPlayers = playerInfos.Count;
            foreach (PlayerInfo p in playerInfos)
            {
                if ((p.PlayerStatusId != 0)&&(p.PlayerStatusId != 1)&&(p.UserRoleId != 1))
                {
                    StopCoroutine(coroutine);
                    Dictionary<Guid, List<PlayingCards>> a = RequestSender.GetCards(SessionId);
                    Game.SetActive(true);
                    this.gameObject.SetActive(false);
                    Game.GetComponent<Game>().SessionId = SessionId;
                    Game.GetComponent<Game>().GameStart(a);
                }
                    kek.UsersId.Add(p.UserId);
                if (p.UserId == Pla.GetComponent<Player>().userId)
                {
                    Playingtable.transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                    info = p;
                    if (Change == true)
                    {
                        Change = false;
                    }
                    if (info.PlayerStatusId == 0)
                    {
                        Playingtable.transform.GetChild(0).GetComponent<Text>().color = Color.red;
                    }
                    else if (info.PlayerStatusId == 1)
                    {
                        Playingtable.transform.GetChild(0).GetComponent<Text>().color = Color.green;
                    }
                }
                else
                { 
                    switch (p.SeatPlace)
                    { 
                        case 1:
                            Players[0].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if(p.PlayerStatusId == 0)
                            {
                                Players[0].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[0].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 2:
                            Players[1].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[1].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[1].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 3:
                            Players[2].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[2].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[2].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 4:
                            Players[3].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[3].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[3].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 5:
                            Players[4].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[4].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[4].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 6:
                            Players[5].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[5].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[5].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 7:
                            Players[6].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[6].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[6].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 8:
                            Players[7].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[7].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[7].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                        case 9:
                            Players[8].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            if (p.PlayerStatusId == 0)
                            {
                                Players[8].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                            }
                            else
                            {
                                ReadyPlayers++;
                                Players[8].transform.GetChild(0).GetComponent<Text>().color = Color.green;
                            }
                            break;
                    }
                }
            }
            print("gre0");
            if (info.UserRoleId == 1)
            {
                if (info.PlayerStatusId == 1)
                {
                    ReadyPlayers++;
                }
                if (countPlayers == ReadyPlayers)
                {
                    StopCoroutine(coroutine);
                    Dictionary<Guid, List<PlayingCards>> a = RequestSender.GetStart(SessionId, kek);
                    Game.SetActive(true);
                    Game.GetComponent<Game>().SessionId = SessionId;
                    this.gameObject.SetActive(false);
                    Game.GetComponent<Game>().GameStart(a);
                }

            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    public void Ready()
    {
        if (info.PlayerStatusId == 0)
        {
            RequestSender.ChangeUsersStatus(new Guid (SessionId), new Guid( Pla.GetComponent<Player>().userId), 1);
            info.PlayerStatusId = 1;
        }
        else if (info.PlayerStatusId == 1)
        {
            RequestSender.ChangeUsersStatus(new Guid(SessionId), new Guid(Pla.GetComponent<Player>().userId), 0);
            info.PlayerStatusId = 0;
        }
        //info.PlayerStatusId == 0

    }
    public void startGame()
    {
        if (info.UserRoleId == 1)
        {
            StopAllCoroutines();
            StartCoroutine(RequestSender.ChangeUsersStatus(new Guid(SessionId), new Guid(Pla.GetComponent<Player>().userId), 2));
            Dictionary<Guid, List<PlayingCards>> a = RequestSender.GetStart(SessionId, kek);
            Game.SetActive(true);
            Game.GetComponent<Game>().SessionId = SessionId;
            Game.GetComponent<Game>().GameStart(a);
            this.gameObject.SetActive(false);
        }
        else
        {
            StopAllCoroutines();
            Dictionary<Guid, List<PlayingCards>> a = RequestSender.GetCards(SessionId);
            Game.SetActive(true);
            this.gameObject.SetActive(false);
            Game.GetComponent<Game>().SessionId = SessionId;
            Game.GetComponent<Game>().GameStart(a);
        }
    }
    public void Join()
    {
        coroutine = StartCoroutine(Refresh(5f));
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
