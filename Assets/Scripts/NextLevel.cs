using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public string nextLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     //   Debug.Log("Col");
    }

    public void MySwitchScenes(string MyScene2Load)
    {

        SceneManager.LoadScene(nextLevel);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Col");
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        SceneManager.LoadScene(nextLevel);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
