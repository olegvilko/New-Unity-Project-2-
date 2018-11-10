using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private GameObject heart;

    private Type type;
    private MonsterLivesBar monsterLivesBar;
    //protected GameObject player;

    //  protected virtual void Awake()
    //  {
    ////      player = GameObject.FindGameObjectWithTag("Player");
    //  //    type = this.GetComponent<Type>();
    //      //   Debug.Log("123");

    //  }

    private void Start()
    {
        //type = this.GetComponent<Type>();
        //Debug.Log("123");
    }
    //public void Awake()
    //{
    //    heart = Resources.Load("Heart") as GameObject;
    //    Debug.Log("Utit");
    //}

    public enum Enemy
    {
        your,
        enemy
    }

	public virtual void ReceiveDamage()
    {
        // Тут надо переделать
        type = this.GetComponent<Type>();

        monsterLivesBar = FindObjectOfType<MonsterLivesBar>();

        
        type.lives--;
        monsterLivesBar.Refresh(type.lives, type.livesMax);

        if (type.lives <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        heart = Resources.Load("Heart") as GameObject;
        GameObject newHeart= Instantiate(heart);
        newHeart.transform.position = gameObject.transform.position;

        Destroy(gameObject);
    }
}
