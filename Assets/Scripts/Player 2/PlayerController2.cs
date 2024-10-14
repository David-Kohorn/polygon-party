using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    private KeyCode jumpInput = KeyCode.UpArrow;
    private KeyCode leftInput = KeyCode.LeftArrow;
    private KeyCode rightInput = KeyCode.RightArrow;

    private Player2Dash dashScript;

    public PlayerController1 p1ControllerScript;
    private GravityChange gravScript;

    public GameObject rightBarrierCollider;
    public GameObject leftBarrierCollider;

    public Rigidbody2D rb;

    public bool canJumpOffPlayer;
    public bool isGrounded;
    List<Collider2D> touchingColliders = new List<Collider2D>();

    public float moveSpeed;
    public float jumpPower;

    public AudioSource source;
    public AudioClip jump;

    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        dashScript = GetComponent<Player2Dash>();
        gravScript = GetComponent<GravityChange>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = touchingColliders.Count > 0;

        foreach (Collider2D col in touchingColliders)
        {
            if (col.gameObject.CompareTag("Player") && !p1ControllerScript.isGrounded)
            {
                canJumpOffPlayer = false;
            }
            else
            {
                canJumpOffPlayer = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Input.GetKey(leftInput) || !Input.GetKey(rightInput))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (SceneManager.GetActiveScene().name == "Level 3 (grav change)")
        {
            if (Input.GetKey(jumpInput) && isGrounded && canJumpOffPlayer && !isPlaying)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower * gravScript.gravityMultiplyerp2);
                source.PlayOneShot(jump, 0.5f);
                isPlaying = true;
            }
        }
        else
        {
            if (Input.GetKey(jumpInput) && isGrounded && canJumpOffPlayer && !isPlaying)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                source.PlayOneShot(jump, 0.5f);
                isPlaying = true;
            }
        }

        //Left and right
        if (Input.GetKey(leftInput))
        {
            rb.velocity = new Vector2(-moveSpeed * dashScript.dashingMultiplier, rb.velocity.y);
        }

        if (Input.GetKey(rightInput))
        {
            rb.velocity = new Vector2(moveSpeed * dashScript.dashingMultiplier, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Level 3 (grav change)")
        {
            if (gravScript.gravityMultiplyerp2 == 1)
            {
                if (((collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate")) && ((collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y / 2) < transform.position.y)))
                {
                    touchingColliders.Add(collision.collider);
                    isPlaying = false;
                    gravScript.abilityUsesp2 = 1;
                }
            }

            if (gravScript.gravityMultiplyerp2 == -1)
            {
                if (((collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate")) && ((collision.gameObject.transform.position.y - collision.gameObject.transform.localScale.y / 2) > transform.position.y)))
                {
                    touchingColliders.Add(collision.collider);
                    isPlaying = false;
                    gravScript.abilityUsesp2 = 1;
                }
            }
        }

        else
        {
            if (((collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate")) && ((collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y / 2) < transform.position.y)))
            {
                touchingColliders.Add(collision.collider);
                isPlaying = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
        {
            touchingColliders.Remove(collision.collider);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            leftBarrierCollider.SetActive(true);
            rightBarrierCollider.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            leftBarrierCollider.SetActive(false);
            rightBarrierCollider.SetActive(false);
        }
    }
}

