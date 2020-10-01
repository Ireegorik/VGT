using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VGTDataStore.Core;
using static RequestSender;

public class Game : MonoBehaviour
{
    public string SessionId;
    public GameObject Pla;
    int Turn = 0;
    public GameObject Playingtable;
    public GameObject Table;
    public GameObject Cards;
    private IEnumerator coroutine;
    public Button Pass, Take;
    List<PlayerInfo> playerInfos;
    PlayerInfo info;
    Guid nextPlayer = new Guid();
    public List<GameObject> Players;
    public class Answer
    {
        string player { get; set; }
        string gameSessionId { get; set; }
        public JArray usersCards { get; set; }
        string message { get; set; }
    }
    Dictionary<Guid, List<PlayingCards>> al;
    Dictionary<int, Guid> PlayerSits;
    private IEnumerator Refresh(float waitTime)
    {
            while (true)
            {
            playerInfos = RequestSender.GetUserSession(SessionId);
            foreach (PlayerInfo p in playerInfos)
            {
                
                if (p.UserId == Pla.GetComponent<Player>().userId)
                {
                    if(Turn == 1)
                    {
                    }
                    if(p.PlayerStatusId == 2)
                    {
                        Take.interactable = true;
                        Pass.interactable = true;
                    }
                    else
                    {
                    }
                    info = p;
                }
                else
                {
                    switch (p.SeatPlace)
                    {
                        case 1:
                            Players[0].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 2:
                            Players[1].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 3:
                            Players[2].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 4:
                            Players[3].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 5:
                            Players[4].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 6:
                            Players[5].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 7:
                            Players[6].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 8:
                            Players[7].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                        case 9:
                            Players[8].transform.GetChild(0).GetComponent<Text>().text = p.UserId;
                            break;
                    }
                }
            }
            if (info.UserRoleId == 1)
            {
                if (info.PlayerStatusId == 1)
                {
                }
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    public void makeMove(bool BPass)
    {
        if (BPass)
        {
           StartCoroutine( RequestSender.ChangeUsersStatus(new Guid(SessionId), new Guid(Pla.GetComponent<Player>().userId), 4));
        } else StartCoroutine(RequestSender.ChangeUsersStatus(new Guid(SessionId), new Guid(Pla.GetComponent<Player>().userId), 3));
        StartCoroutine(RequestSender.ChangeUsersStatus(new Guid(SessionId), nextPlayer, 2));
        Take.interactable = false;
        Pass.interactable = false;
        Turn++;
        if(Turn >0 && Turn < 2)
        {
            Playingtable.transform.GetChild(1).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid(Pla.GetComponent<Player>().userId)][0].CardId];
            Playingtable.transform.GetChild(2).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid(Pla.GetComponent<Player>().userId)][1].CardId];
        }
        putcards(Turn);
    }
    public void GameStart(Dictionary<Guid, List<PlayingCards>> a)
    {
        al = a;
        playerInfos = RequestSender.GetUserSession(SessionId);
        bool bo = false;
        foreach (PlayerInfo p in playerInfos)
        {
            if (bo == true)
            {
                nextPlayer = new Guid(p.UserId);
                bo = false;
            }
            if (p.UserId == Pla.GetComponent<Player>().userId)
            {
                bo = true;
            }
        }
        if (bo == true)
        {
            nextPlayer = new Guid(playerInfos[0].UserId);
        }
        print(nextPlayer);
        StartCoroutine(Refresh(2.5f));
    }
    void putcards(int turn)
    {
        switch (turn)
        {
            case 1:
                foreach(GameObject image in Players)
                {
                    image.transform.GetChild(1).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[0];
                    image.transform.GetChild(2).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[0];
                }
                break;
            case 2:

                    Table.transform.GetChild(0).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid("00000000-0000-0000-0000-000000000000")][0].CardId];
                    Table.transform.GetChild(1).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid("00000000-0000-0000-0000-000000000000")][1].CardId];
                    Table.transform.GetChild(2).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid("00000000-0000-0000-0000-000000000000")][2].CardId];
                break;

            case 3:
                foreach (GameObject image in Players)
                {
                    if (image.transform.GetChild(0).GetComponent<Text>().text != "")
                    {
                        image.transform.GetChild(1).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid(image.transform.GetChild(0).GetComponent<Text>().text)][0].CardId];
                        image.transform.GetChild(2).GetComponent<Image>().sprite = Cards.GetComponent<Card>().cards[al[new Guid(image.transform.GetChild(0).GetComponent<Text>().text)][1].CardId];
                    }
                }
                break;
        }
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
