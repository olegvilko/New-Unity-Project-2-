using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour {

    public bool go=true;
	// Use this for initialization
	void Start () {
        go = true;

    }
	
	// Update is called once per frame
	void Update () {
     //   Debug.Log(go);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        go = true;
        //if (collision)
        //{
        //    go = true;
        //}
        //else
        //{
        //    go = false;
        //}
        //Debug.Log(collision.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        go = false;
    }
}
