using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDissapear : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] float dissapearTime = 3;
    Animator myAnim;

    [SerializeField] bool canReset;
    [SerializeField] float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("DissapearTime", 1 / dissapearTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == playerTag)
        {
            myAnim.SetBool("Trigger", true);

        }
    }

    public void TriggerReset()
    {
        if (canReset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(resetTime);
        myAnim.SetBool("Trigger", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
