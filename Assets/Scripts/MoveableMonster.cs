using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster
{
    public Enemy enemy = Enemy.enemy;

    [SerializeField]
    private float speed = 1.0F;

    private SpriteRenderer sprite;

  //  public CheckPlatform checkPlatform;

    // private Bullet bullet;

    private Vector3 direction;

    //protected override void Awake()
    //{
    //    sprite = GetComponentInChildren<SpriteRenderer>();

    ////    checkPlatform = GetComponentInChildren<CheckPlatform>();
    //    //  bullet = Resources.Load<Bullet>("Bullet");
    //}

    protected override void Start()
    {
        direction = transform.right;
    }


    protected override void Update()
    {
        Move();
    }



    protected override void OnTriggerEnter2D(Collider2D collision)
    {
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

    // Use this for initialization



    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.14F + transform.right * direction.x * 0.2F, 0.01F);

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<PlayerController>()))
        {
            direction *= -1.0F;
        }

        colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.2F + transform.right * direction.x * 0.2F, 0.01F);
        if (colliders.Length == 0)
        {
            direction *= -1.0F;
        }

        //  direction = transform.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);



        //  transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);


    }
}
