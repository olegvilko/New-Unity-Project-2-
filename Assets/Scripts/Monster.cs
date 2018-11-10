using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;
using UnityEngine.UI;

public class Monster : Unit
{
    //protected Animator animator;
    //protected CharState State
    //{
    //    get { return (CharState)animator.GetInteger("State"); }
    //    set { animator.SetInteger("State", (int)value); }
    //}

    protected GameObject player;
   // protected Type type;

    int direction=1;

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        type = GetComponent<Type>();
        transform.localScale = new Vector3(transform.localScale.x*type.scale,transform.localScale.y*type.scale,transform.localScale.z);
        //if (type.boss)
        //{

        //}
    }

    protected virtual void Start()
    {
  //      animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Bullet bullet = collider.GetComponent<Bullet>();

        //if (bullet)
        //{
        //    //Destroy(gameObject);
        //    ReceiveDamage();
        //}

        Unit unit = collision.GetComponent<Unit>();

        if (unit && unit is PlayerController)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.1F)
            {
                ReceiveDamage();
            }
            else
            {
                unit.ReceiveDamage();
            }
        }
    }

    public void RotationToPlayer()
    {
        if (transform.position.x - player.transform.position.x < 0)
        {

            //    if (transform.localScale.x > 0)
            if (direction == -1)
            {
                direction = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
        }
        else
        {

            //        if (transform.localScale.x < 0)
            if (direction == 1)
            {
                direction = -1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
        }
    }

    public void Move(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right*direction, speed * Time.deltaTime);
        //  transform.position += Vector3.forward;
    }

    public enum CharState
    {
        Idle,
        Run,
        Jump,
        Attack,
        Shield
    }
}
