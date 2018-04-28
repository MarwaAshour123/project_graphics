using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boy_code : MonoBehaviour {

    public int speed=3;
    Animator anim;
    public GameObject sky_image;
    public GameObject ground_image;
    public GameObject mounts_image;
    public string varName;
    int direction = 0;
    public Text score;
    int scoreVar = 0;
    public AudioSource sound1;

    public void run_R()
    {
        anim.SetBool(varName, true);
        transform.localRotation= Quaternion.Euler(0, 0, 0);
        direction = 1;
    }
    public void run_L()
    {
        anim.SetBool(varName, true);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        direction = 2;
    }
    public void run_Stop()
    {
        anim.SetBool(varName, false);
        direction = 0;
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        score.text = 0+"";
    }
	
	// Update is called once per frame
	void Update () {
        if (direction==1)
        {
            sky_image.transform.position += Vector3.left * speed * Time.deltaTime;
            mounts_image.transform.position += Vector3.left * speed * Time.deltaTime / 2;
            ground_image.transform.position += Vector3.left * speed * Time.deltaTime / 2;
        }
        else if (direction==2)
        {
            sky_image.transform.position += Vector3.right * speed * Time.deltaTime;
            mounts_image.transform.position += Vector3.right * speed * Time.deltaTime / 2;
            ground_image.transform.position += Vector3.right * speed * Time.deltaTime / 2;
        }
	}

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag=="target")
        {
            Destroy(obj.gameObject);
            scoreVar++;
            score.text = scoreVar + "";
            sound1.Play();
        }
        if (obj.gameObject.tag == "endGame"){
            direction = 0;
            anim.SetBool(varName, false);
        }
    }

}
