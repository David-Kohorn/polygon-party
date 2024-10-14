using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && transform.localScale.x < 4f && transform.localScale.y < 4f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, 1);
        }

        if (Input.GetKey(KeyCode.V) && transform.localScale.x > 0.4f && transform.localScale.y > 0.4f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, 1);
        }
    }
}