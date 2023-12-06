using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    [Header ("UI from canvas")]
    [SerializeField] Text appleCounter;
    [SerializeField] Image appleImage;

    public void Death()
    {
        Destroy(gameObject);
    }
    public void Revive()
    {
        playerAnimationScript.isDead=false;
        enableOnRevive();
        RestartScene();
    }

    public void disableOnDeath()
    {
        colliderScript.appleCount=0;
        appleCounter.gameObject.SetActive(false);
        appleImage.gameObject.SetActive(false);
    }
    private void enableOnRevive()
    {
        appleCounter.gameObject.SetActive(true);
        appleImage.gameObject.SetActive(true);

    }
    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
