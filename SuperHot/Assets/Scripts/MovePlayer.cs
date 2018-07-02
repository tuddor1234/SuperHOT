using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovePlayer : MonoBehaviour {

    public float speed = 100f;


    private float h;
    private Rigidbody rb;
    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(rb==null)
        {
            Debug.LogError("Player has no rigidbody");
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Input
        h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        Move(h);
        


	}

    void Move(float h)
    {
        movement.Set(h, 0,0);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(this.transform.position + movement);
    }

}
