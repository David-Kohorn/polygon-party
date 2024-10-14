using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificSize : MonoBehaviour
{
    public GameObject activateButton2;
    public GameObject disWall2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.transform.localScale.x > activateButton2.transform.localScale.x)
        {
            disWall2.gameObject.transform.position = new Vector2(disWall2.transform.position.x, disWall2.transform.position.y + 0.5f);
            activateButton2.gameObject.SetActive(false);
        }
    }
}
