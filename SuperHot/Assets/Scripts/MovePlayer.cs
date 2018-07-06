using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;



public class MovePlayer : MonoBehaviour {
    
    public float speed = 10f;
    public bool powerSpeed=false;
    public float jumpForce = 20f;
    public Button jump;
    public LayerMask ground;

    private float horizontalInput;
    private float scaleFactor = 50f;

    private Rigidbody rb;
    private Vector3 movement;
    private BoxCollider bc;
    


    private void Awake()
    {
        powerSpeed = false; 
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();

        if(rb==null || bc==null)
        {
            Debug.LogError("Player has no Rigidbody or boxColider");
        }
     
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Input
        horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        Move(horizontalInput);
       
	}

    void Move(float h)
    {
     
        //Player jump
        if (isGrounded() &&  Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce * scaleFactor);
            print("You jumped");
        }

        //Player left-right movement
        movement.Set(h, 0,0);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(this.transform.position + movement);
    }

    private bool isGrounded()
    {
        return Physics.CheckBox(bc.bounds.center,bc.extents,Quaternion.identity,ground);

    }

}
