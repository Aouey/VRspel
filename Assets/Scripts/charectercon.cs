using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charectercon : MonoBehaviour {


    //gubens hastighet
    private float speed = 0.3f;
    Rigidbody rb;
    // variabler för framåt bakåt
    private float translation;
    private float straffe;
    bool canJump = false;
    public bool onGround;
    float fallmulti = 8f, lowmulti = 6f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update () {
        //raw input värden från keypress
        translation = Input.GetAxis("Vertical") * speed;
        straffe = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown("space") && canJump)
        {
            rb.AddRelativeForce(transform.up * 350f);
            
            canJump = false;
        }

    }
    void FixedUpdate()
    {
        //adderar värderna
        transform.Translate(straffe, 0, translation);

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallmulti - 1) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && Input.GetKeyDown("space"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowmulti - 1) * Time.deltaTime;
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (rb.velocity.y == 0)
        {
            canJump = true;
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
        onGround = false;
    }

}
