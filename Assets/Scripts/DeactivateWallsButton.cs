using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWallsButton : MonoBehaviour
{
    public GameObject activateButton;
    public GameObject disWall;
    public string otherTag;
    public float transformHeight;
    public bool requiresSpecificSize;
    public int requiredPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !requiresSpecificSize && (disWall.gameObject.activeSelf)) //this is sus
        {
            disWall.gameObject.transform.position = new Vector2(disWall.transform.position.x, disWall.transform.position.y + transformHeight);
            activateButton.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag(otherTag) && !requiresSpecificSize && (!disWall.gameObject.activeSelf)) //this is sus
        {
            //      Debug.Log("Yo");
            disWall.gameObject.SetActive(true);
            activateButton.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag(otherTag) && requiredPlayer > 0 && (disWall.gameObject.activeSelf)) //this is sus
        {
            if (requiredPlayer == 1 && other.gameObject.name == "Player 1")
            {
                disWall.gameObject.SetActive(false);
                activateButton.gameObject.SetActive(false);
            }
            if (requiredPlayer == 2 && other.gameObject.name == "Player 2")
            {
                disWall.gameObject.SetActive(false);
                activateButton.gameObject.SetActive(false);
            }

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (requiresSpecificSize && other.gameObject.CompareTag("Player") && other.gameObject.transform.localScale.x > activateButton.transform.localScale.x)
        {
            disWall.gameObject.transform.position = new Vector2(disWall.transform.position.x, disWall.transform.position.y + transformHeight);
            activateButton.gameObject.SetActive(false);
        }
    }
}
