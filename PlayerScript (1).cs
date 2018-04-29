using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    Rigidbody2D player;
    Animator anim;
    //CircleCollider2D circle;
    bool Grounded = true;
    float moveX = 1.0f;
    public float runSpeed;
    public float JumpSpeed;
    public Text score;

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

        //score.text = (float.Parse(score.text)+0.5f).ToString();
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

        if (col.tag == "DeathHardle")
        {
            Death();
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

    void Death()
    {
        //anim.SetTrigger("DeathTridder");
        //RestartGame();
       //score.text = "0";
    }

    void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
