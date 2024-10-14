using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateReset : MonoBehaviour
{
    public GameObject crate;
    public Vector2 spawnPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            crate.transform.position = spawnPos;
        }
    }
}
