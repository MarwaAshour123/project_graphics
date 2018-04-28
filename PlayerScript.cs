using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    Rigidbody2D player;
    Animator anim;
    //CircleCollider2D circle;
    bool Grounded = true;
    float moveX = 1.0f;
    public float runSpeed;
    public float JumpSpeed;

    // Use this for initialization
    void Start () {

        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //circle = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        player.transform.Translate(0, 0, moveX * Time.deltaTime * runSpeed);
        //player.velocity = new Vector2(moveX * runSpeed, player.velocity.y);
    }
    public void Jump()
    {
        print("Jump");
        player.velocity += JumpSpeed * Vector2.up;
        //player.AddForce(new Vector3(0, JumpSpeed));
    }

    public bool isGrounded()
    {
        if (Grounded)
            return true;

        return false;
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            print(col.tag);
            Grounded = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            Grounded = false;
            print("exit");
        }
    }
}
