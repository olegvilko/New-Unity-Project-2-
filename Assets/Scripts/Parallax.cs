using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject player;

    public float speed = 0.01F;

    private void Awake()
    {
        transform.position = player.transform.position;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position=
        transform.position = transform.position + Vector3.right*speed;

        float diff = transform.position.x - player.transform.position.x;
        if (diff > 10)
        {
            transform.position=transform.position+Vector3.left*20;
        }
    }
}
