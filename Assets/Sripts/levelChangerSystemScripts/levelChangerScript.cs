using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChangerScript : ScriptableObject
{
    public static void changeLevel(nextLevelScript lc)
    {
        colliderScript.appleCount=0;
        SceneManager.LoadScene(lc.SceneIndex+1);
    }
}