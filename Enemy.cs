using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private bool left = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(moveLeft());

    }
	
	// Update is called once per frame
	void Update () {
        if (left)
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y);



    }

    IEnumerator moveLeft() {
        left = true;
        yield return new WaitForSeconds(2);
        StartCoroutine(moveRight());

    }

    IEnumerator moveRight()
    {
        left = false;
        yield return new WaitForSeconds(2);
        StartCoroutine(moveLeft());

    }
}
