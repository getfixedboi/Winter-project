using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{
    private Rigidbody2D rb;

    #region Movement parameters

    [Header ("Movement parameters")]
    [SerializeField] private float movSpeed;
    [SerializeField] private float jumpForce;
    #endregion
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    #region default movement
    public void Right()
    {
        rb.velocity = new Vector2(movSpeed, rb.velocity.y);
    }

    public void Left()
    {
        rb.velocity = new Vector2(-movSpeed, rb.velocity.y);
    }

    public void Idle()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Jump()
    {
        if(colliderScript.isGround)
        {
            if(SpecialJumpMechanicCheck())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce*2.3f); 
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private bool SpecialJumpMechanicCheck()
    {
        return SceneManager.GetActiveScene().buildIndex == 6;
    }

    public void disableMovement()
    {
       rb.velocity = new Vector2(0,0); 
    }
    #endregion
}
