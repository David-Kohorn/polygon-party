using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public int playerExitCount = 0;
    public TextMeshProUGUI playerCount;
    // Start is called before the first frame update
    void Start()
    {
        playerCount.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerExitCount > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playerCount.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerExitCount++;
            playerCount.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}   
