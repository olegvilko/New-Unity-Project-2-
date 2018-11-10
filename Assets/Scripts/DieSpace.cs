using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour {

    public GameObject respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag=="Player")
        {
            
            collision.transform.position = respawn.transform.position;
        }
    }
}
