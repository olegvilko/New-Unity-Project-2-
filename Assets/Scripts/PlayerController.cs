using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Unit
{
 //   [SerializeField]
    public float speed = 3f;
    public float jump = 4f;
    public int lives = 5;
    public float speedMount=0.001F;

    public Enemy enemy = Enemy.your;

    public BackgroundHelper backgroundHelper;

    public RawImage rawImage;

    public Collider2D colliderObstracle;

    public GameObject shield;

    int scale;

    Type type;

    public int Lives
    {
        get { return lives; }
        set {
            if(value<5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

  //  [SerializeField]
  //  private GameObject bullet;

    private Rigidbody2D rb;
//    private bool faceRight = true;
    private Animator animator;
    private bool isGrounded;
    private SpriteRenderer sprite;
    new private Rigidbody2D rigidbody;

    [SerializeField]
    private Bullet bullet;

    float pos = 0;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        type = GetComponent<Type>();
        type.enemy = Enemy.your;


        livesBar = FindObjectOfType<LivesBar>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
   //     bullet = Resources.Load<Bullet>("Bullet");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isGrounded && !(Input.GetButton("Fire1")))
            State = CharState.Idle;

        if (Input.GetButton("Horizontal"))
            Run();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
               Jump();
        }

        if (Input.GetButton("Fire2"))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);

            if (Input.GetButton("Fire1"))
            {
                 Shoot();
            }
        }
        
          //  Shield();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Unit unit = collision.gameObject.GetComponent<Unit>();
        Type typeCollision = collision.GetComponent<Type>();
        if (type.enemy != typeCollision.enemy)
        {
          //  ReceiveDamage();
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tag = collision.gameObject.tag;
  //      Debug.Log(collision.gameObject.name);
        if (tag=="vertical")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

    private void Shield()
    {
        if (Input.GetButton("Fire2"))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    private void Shoot()
    {
        
        //  newBullet.transform.localScale=new Vector3(0.26F,1,1);

        State = CharState.Attack;
    }

    void Attack()
    {
        Vector3 position = transform.position;
       // var rotation = (sprite.flipX ? -1 : 1);
        position.y += 0.25F;
        position.x -= 0.15F * scale;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation);
        Type type = newBullet.GetComponent<Type>();
        type.enemy = Enemy.your;

        newBullet.Direction = newBullet.transform.right * scale*-1;
        newBullet.Parent = gameObject;

        newBullet.transform.localScale = new Vector3(scale*-1, 1, 1);

        
    }

    private void FixedUpdate()
    {
        CheckGround();

        //Vector3 pos=transform.position;
        //pos.x -= 0.1F;
        //pos.y += 0.3F;
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 0.1f);
        //isGrounded = colliders.Length > 2;
        //if (!isGrounded)
        //{
        //    Debug.Log("23423");
        //}
    }

    void Run()
    {
        float right = Input.GetAxis("Horizontal");
        Vector3 direction = transform.right * right;
        float run = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, run);

        // sprite.flipX = direction.x < 0.0F;
        
        if (right > 0) scale = -1;
          else scale = 1;

        transform.localScale = new Vector3(scale,1,1);



        if(isGrounded)
            State = CharState.Run;

       // float sp = 0.0003F;        
        pos += speedMount*right*Time.deltaTime;
        if (pos > 1.0F)
            pos -= 1.0F;
        rawImage.uvRect = new Rect(pos, 0, 1, 1);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        isGrounded = colliders.Length > 1;

        if (!isGrounded)State = CharState.Jump;
    }

    public enum CharState
    {
        Idle,
        Run,
        Jump,
        Attack
    }

    public override void ReceiveDamage()
    {
        Lives--;

     //   Debug.Log(lives);

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up*3.0F,ForceMode2D.Impulse);
        
    }
}
