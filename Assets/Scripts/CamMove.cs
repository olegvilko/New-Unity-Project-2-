using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

    [SerializeField]
    float posY = 1;
    [SerializeField]
    float posZ = -10.0F;

    private GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update () {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y+posY,posZ);
	}
}
