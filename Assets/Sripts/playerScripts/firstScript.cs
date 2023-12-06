using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class firstScript : MonoBehaviour
{
    #region script references
    [Header ("Scripts references")]
    [SerializeField] inputScript objInputScript;
    [SerializeField] movementScript objMovementScript;
    [SerializeField] colliderScript objColliderScript;
    [SerializeField] playerAnimationScript objPlayerAnimationScript;
    [SerializeField] escapeMenuScript objEscapeMenuScript;
    #endregion
    
    #region start & update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        defaultMovenent();
        jump();
        exitGame();
    }
    #endregion

    #region  defaultMovement funcions call
    private void defaultMovenent()
    {
        if(disableCall())
        {
        
            if (objInputScript.isPressedA)
            {
                objMovementScript.Left();
                objPlayerAnimationScript.animationMoveLeft();
            }
            else if (objInputScript.isPressedD)
            {
                objMovementScript.Right();
                objPlayerAnimationScript.animationMoveRight();
            }
            else
            {
                objMovementScript.Idle();
                objPlayerAnimationScript.animationIdle();
            }
                
            if(playerAnimationScript.isDead)
            {
                objMovementScript.disableMovement();
            }
        }
    }

    private bool disableCall()
    {
        return !objInputScript.isPressedEsc || gameObject != null || !playerAnimationScript.isDead;
    }

    private void jump()
    {
        if (objInputScript.isJumped && colliderScript.isGround)
        {
            objMovementScript.Jump();
        }
    }
    #endregion
    private void exitGame() 
    {
        if (objInputScript.isPressedEsc)
        {
            objEscapeMenuScript.Pause();
        }
        else
        {
            objEscapeMenuScript.Resume();
        }
    }
}
