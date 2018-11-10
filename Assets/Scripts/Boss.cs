using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster {

    private Animator animator;
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    protected override void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    //void Awake () {

    //}

    // Update is called once per frame
    protected override void Update () {
        RotationToPlayer();

        Move(type.speed);

        State = CharState.Run;
	}
}
