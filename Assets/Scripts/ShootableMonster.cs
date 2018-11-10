using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableMonster : Monster {

    public int rotationX;

    [SerializeField]
    private float rate = 2.0F;
    [SerializeField]
    private Color bulletColor=Color.white;

    private Bullet bullet;

  //  private GameObject player;

    protected override void Awake()
    {   // это надо переделать
        player = GameObject.FindGameObjectWithTag("Player");

        bullet = Resources.Load<Bullet>("items/Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot",rate,rate);
      //  transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y);
    }

    protected override void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (transform.position.x - player.transform.position.x < 0)
        {
            if(transform.localScale.x>0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        else
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.3F;
        Bullet newBullet = Instantiate(bullet,position,bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right*transform.localScale.x;
        newBullet.color = bulletColor;
        newBullet.timeDestroy = 3;

        Type type = newBullet.GetComponent<Type>();
        type.enemy = Enemy.enemy;

       // newBullet.Direction = newBullet.transform.right;

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
}
