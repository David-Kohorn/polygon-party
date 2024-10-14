using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool canClick;
    //private bool isOn = false;
    public float timer;
    public GameObject plr1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(plr1.name))
        {
            
            canClick = true;
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)  
    {
        if (collision.gameObject.name.Equals(plr1.name))
        {
            canClick = false;
        }
           
    }


    IEnumerator endBlock()
    {
        //isOn = true;
        Debug.Log("blocks on");
        yield return new WaitForSeconds(timer);
        //isOn = false;
        Debug.Log("Blocks off");
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canClick)
        {
            StartCoroutine("endBlock");

        }
    }


}
    