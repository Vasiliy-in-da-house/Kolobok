using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneJump : MonoBehaviour
{
    public bool isGrounded;

    void OnCollosionEnter()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            isGrounded = false;

            GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }


    }
}
