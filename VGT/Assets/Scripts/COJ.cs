using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COJ : MonoBehaviour
{
    public GameObject CreateRoom;
    public GameObject JoinRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createroom()
    {
        CreateRoom.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void joinroom()
    {
        JoinRoom.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
