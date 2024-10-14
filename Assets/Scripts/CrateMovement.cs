using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrateMovement : MonoBehaviour
{
    private Vector2 zeroVector;
    private Rigidbody2D currentrb;
    private Rigidbody2D collisionrb;

    // Start is called before the first frame update
    void Start()
    {
        currentrb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !(transform.position.y < collision.gameObject.transform.position.y))
        {
            collisionrb = collision.gameObject.GetComponent<Rigidbody2D>();
            currentrb.velocity = new Vector2(collisionrb.velocity.x, collisionrb.velocity.y);
        }

        if (SceneManager.GetActiveScene().name == "Level 3 (grav change)" && collision.gameObject.GetComponent<Rigidbody2D>().gravityScale < 0 && currentrb.velocity.y == 0 && collisionrb.velocity.y == 0) 
        {
            currentrb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentrb.velocity = Vector2.zero;
        }
    }


}
