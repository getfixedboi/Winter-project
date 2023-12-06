using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationScript : MonoBehaviour
{
    #region fields
    private Animator anim;
    private SpriteRenderer sp;

    internal static bool isDead=false;
    #endregion

    #region start
    private void Start()
    {
        GetGraphicsComponents();
    }

    private void GetGraphicsComponents()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }
    #endregion

    public void animationMoveRight()
    {
    if (colliderScript.isGround && !isDead)
        {
            anim.Play("run");
        }
        else
        {
            animationFall();
        }
        sp.flipX = false;
    }

    public void animationMoveLeft()
    {
        if (colliderScript.isGround && !isDead)
        {
            anim.Play("run");
        }
        else
        {
            animationFall();
        }
        sp.flipX = true;
    }

    public void animationIdle()
    {
        if (colliderScript.isGround && !isDead)
        {
            anim.Play("idle_animation");
        }
         else
        {
            animationFall();
        }
    }
    
    private void animationFall()
    {
        if (!colliderScript.isGround && !isDead)
        {
            anim.Play("jump");
        }
    }

    public void animationDeath()
    {
        isDead = true;
        anim.Play("death");

    }
}
