using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{
    #region script & groundCheck references
    [Header ("Scripts references")]
    [SerializeField] deathScript deathScript;
    [SerializeField] playerAnimationScript playerAnimationScript;

    [Header ("GroundCheck objects")]
    [SerializeField] private Transform GroundC;//groundCheck
    [SerializeField] private Transform GroundL;
    [SerializeField] private Transform GroundR;
    #endregion

    #region fields
    internal static int appleCount = 0;
    internal static bool isGround=false;
    #endregion

    private void Update()
    {
        groundCheck();
    }

    #region groundCheck func
    private void groundCheck()
    {
        if (gameObject != null)
        {
            if ((Physics2D.Linecast(transform.position, GroundC.position, 1 << LayerMask.NameToLayer("Ground"))) ||
              (Physics2D.Linecast(transform.position, GroundR.position, 1 << LayerMask.NameToLayer("Ground"))) ||
              (Physics2D.Linecast(transform.position, GroundL.position, 1 << LayerMask.NameToLayer("Ground"))))
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
    }
    #endregion

    #region deathAnimation Coroutine
    public IEnumerator deathAnim()
    {
        playerAnimationScript.animationDeath();
        deathScript.disableOnDeath();
        yield return new WaitForSeconds(1f);   
        deathScript.Death();
        playerAnimationScript.isDead=false;
        deathScript.Revive();
    }
    #endregion

    #region deathFromSpikes func
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            StartCoroutine(deathAnim());
        }
    }
    #endregion
}

