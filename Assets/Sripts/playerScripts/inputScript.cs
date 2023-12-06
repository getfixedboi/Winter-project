using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class inputScript : MonoBehaviour
{
    #region check fields
    internal bool isPressedD;
    internal bool isPressedA;
    internal bool isGround;
    internal bool isJumped;
    internal bool isPressedEsc;
    #endregion

    private void Update()
    {
        movement();
        jump();
        exit();
    }

    #region movement inputs
    private void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isPressedD = true;
            isPressedA = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isPressedA = true;
            isPressedD = false;
        }
        else
        {
            isPressedA = false;
            isPressedD = false;
        }
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;
        }
        else 
        {
            isJumped = false;
        }
        
    }
    #endregion

    private void exit()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPressedEsc=!isPressedEsc;
        }
    }
    
}
