using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class JoinPoker : MonoBehaviour
{
    public GameObject ButtonEnter;
    public GameObject PanelButt;
    public GameObject Lobby;
    public GameObject Pla;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Refresh()
    {
        for(int i = 0;i< PanelButt.transform.childCount; i++)
        {
            Destroy(PanelButt.transform.GetChild(i).gameObject);
        }
        JObject dynamic = JsonConvert.DeserializeObject<JObject>(RequestSender.GetSessionPoker());
        List<string> Keys = new List<string>();
        foreach (JProperty property in dynamic.Properties())
        {
            if(property.Value["sessionStatusId"].ToString() == "0")
            {
                GameObject obj = Instantiate(ButtonEnter);
                obj.GetComponent<Button>().onClick.AddListener(delegate { Join(property.Value["sessionId"].ToString()); });
                obj.GetComponentInChildren<Text>().text = "Session Id:" + property.Value["sessionId"].ToString();
                obj.transform.parent = PanelButt.transform;
            }
            Keys.Add(property.Name);
        }
    }
    public void Join(string SessionId)
    {
        RequestSender.joinLobby(SessionId, Pla.GetComponent<Player>().userId);
        Lobby.SetActive(true);
        var component = Lobby.GetComponent<Lobby>();
        component.SessionId = SessionId;
        Lobby.GetComponent<Lobby>().Join();
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
