using UnityEngine;

public class Type : Unit {

    public Enemy enemy;
    
    public int lives = 1;
    [HideInInspector]
    public int livesMax;
    public float speed = 1.0F;
    public bool boss;
    public float scale = 1;

    private void Awake()
    {
        livesMax = lives;
    }
}


