using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Unit
{
    Type type;

    public Vector3 Direction { set { direction = value; } }
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    public float timeDestroy = 0.1F;

    public float scale = 0;

    public Color color {
        set { sprite.color = value; }
    }

    public float speed =4.0F;
    private SpriteRenderer sprite;
    private Vector3 direction;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        type = GetComponent<Type>();
    }

    private void Start()
    {
        Destroy(gameObject,timeDestroy);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        transform.localScale =new Vector3(transform.localScale.x+scale,transform.localScale.y+Mathf.Abs(scale),transform.localScale.z+scale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "shield")
        {
           // Debug.Log(collision.tag);
            Destroy(gameObject);
        }
        else
        {

            Unit unit = collision.GetComponent<Unit>();

            Type typeCollision = collision.GetComponent<Type>();

            // if(type.enemy != typeCollision.enemy)
            //Debug.Log(typeCollision.enemy);
            //Debug.Log(type.enemy);

            if (unit && unit.gameObject != parent && type.enemy != typeCollision.enemy)
            {
                unit.ReceiveDamage();
                Destroy(gameObject);
            }
        }
    }
}
