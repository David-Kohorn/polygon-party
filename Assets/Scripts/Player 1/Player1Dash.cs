using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Dash : MonoBehaviour
{
    public Rigidbody2D rb;

    private KeyCode dashInput = KeyCode.LeftShift;

    private bool canDash = true;
    private bool isDashing;
    public float dashingMultiplier = 1f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    [SerializeField] private TrailRenderer tr;

    public AudioSource source;
    public AudioClip dash;

    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(dashInput) && canDash && !isPlaying)
        {
            StartCoroutine(Dash());
            source.PlayOneShot(dash, 0.5f);
            isPlaying = true;

        }

        isPlaying = false;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 3f;
        tr.emitting = true;
        dashingMultiplier = 5f;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        dashingMultiplier = 1f;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

/*public int leftTotal = 0;
public int rightTotal = 0;
public float leftTimeDelay = 0;
public float rightTimeDelay = 0;
*/

/*if (isDashing)
{
    return;
}

if (Input.GetKeyDown(dashInputRight))
{
    rightTotal += 1;
}

if (rightTotal == 0)
{
    canDash = true;
}

if ((rightTotal) == 1 && (rightTimeDelay < 0.3))
{
    rightTimeDelay += Time.deltaTime;
}

if ((rightTotal == 1) && (rightTimeDelay >= 0.3))
{
    rightTimeDelay = 0;
    rightTotal = 0;
}

if ((rightTotal == 2) && (rightTimeDelay < 0.3) && canDash)
{
    StartCoroutine(Dash());
    rightTotal = 0;
}

if ((rightTotal == 2) && (rightTimeDelay >= 0.3))
{
    rightTimeDelay = 0;
    rightTotal = 0;
}

if (Input.GetKeyDown(dashInputLeft))
{
    leftTotal += 1;
}

if (leftTotal == 0)
{
    canDash = true;
}

if ((leftTotal) == 1 && (leftTimeDelay < 0.3))
{
    leftTimeDelay += Time.deltaTime;
}

if ((leftTotal == 1) && (leftTimeDelay >= 0.3))
{
    leftTimeDelay = 0;
    leftTotal = 0;
}

if ((leftTotal == 2) && (leftTimeDelay < 0.3) && canDash)
{
    StartCoroutine(Dash());
    leftTotal = 0;
}

if ((leftTotal == 2) && (leftTimeDelay >= 0.3))
{
    leftTimeDelay = 0;
    leftTotal = 0;
}
*/
