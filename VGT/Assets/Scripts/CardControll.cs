using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControll : MonoBehaviour
{
    float x, y;
    bool ismoved = false;
    public bool isPlayerCards;
    // Start is called before the first frame update
    void Start()
    {
        if(isPlayerCards == false)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
            ismoved = true;
        }
        if (ismoved && ((Input.mousePosition.x >= this.transform.position.x)&&(Input.mousePosition.x <= this.transform.position.x + 100))&& ((Input.mousePosition.y >= this.transform.position.y) && (Input.mousePosition.y <= this.transform.position.y + 150)))
        {
            this.transform.Translate(new Vector3(Input.mousePosition.x - x, Input.mousePosition.y-y));
            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
        {
            ismoved = false ;
        }
    }
}
