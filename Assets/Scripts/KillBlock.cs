using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBlock : MonoBehaviour
{
    public bool sendToPos;
    public Vector2 respawnPos;
    private Vector2 respawnPosOffsetp1;
    private Vector2 respawnPosOffsetp2;
    private GameObject p1;
    private GameObject p2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sendToPos)
            {
                respawnPosOffsetp1 = respawnPos - new Vector2(3, 0);
                respawnPosOffsetp2 = respawnPos + new Vector2(3, 0);
                p1 = GameObject.Find("Player 1");
                p2 = GameObject.Find("Player 2");
                p1.transform.position = respawnPosOffsetp1;
                p2.transform.position = respawnPosOffsetp2;

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
