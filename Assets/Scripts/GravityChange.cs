using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public KeyCode changeGravityInput;

    public int abilityUsesp1;
    public int abilityUsesp2;
    public Rigidbody2D rb;
    public int gravityMultiplyerp1;
    public int gravityMultiplyerp2;

    // Start is called before the first frame update
    void Start()
    {
        gravityMultiplyerp1 = 1;
        gravityMultiplyerp2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(changeGravityInput) && gameObject.name == "Player 1" && abilityUsesp1 == 1)
        {
            rb.gravityScale = -rb.gravityScale;
            gravityMultiplyerp1 = -gravityMultiplyerp1;
            abilityUsesp1 = 0;
        }

        if (Input.GetKeyDown(changeGravityInput) && gameObject.name == "Player 2" && abilityUsesp2 == 1)
        {
            rb.gravityScale = -rb.gravityScale;
            gravityMultiplyerp2 = -gravityMultiplyerp2;
            abilityUsesp2 = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }
}
