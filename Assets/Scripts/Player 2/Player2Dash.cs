using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Dash : MonoBehaviour
{
    public Rigidbody2D rb;

    private KeyCode dashInput = KeyCode.RightShift;

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

        if (Input.GetKeyDown(dashInput) && canDash)
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
