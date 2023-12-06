using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevelScript : ScriptableObject
{
    public int SceneIndex;
    public int appleGoalCount;

    public void SetFields(int SceneIndex,int appleGoalCount)
    {
        this.SceneIndex = SceneIndex;
        this.appleGoalCount=appleGoalCount; 
    }
}