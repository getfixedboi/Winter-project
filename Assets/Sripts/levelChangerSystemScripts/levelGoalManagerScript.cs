using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using NUnit.Framework.Constraints;

public class levelGoalManagerScript : MonoBehaviour
{
    private const string filePath = "Assets/gameDataSaves/levelData.txt";
    private string progressFromFile = "";
    private int levelProgress;
   
    List<nextLevelScript> list4goals;

    private void Start()
    {
        CreateGoals();
    }

    public void PassArgument()
    {
        for(int i = 0; i < list4goals.Count;i++)
        {
            if((list4goals[i].SceneIndex == SceneManager.GetActiveScene().buildIndex) && Check(list4goals[i]))
            {
                levelChangerScript.changeLevel(list4goals[i]);
                levelProgressSaver(list4goals[i]);
            }
        }
    }

    private bool Check(nextLevelScript lc)
    {
        if(lc.appleGoalCount==colliderScript.appleCount) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    private void CreateGoals()
    {
        nextLevelScript l1 = ScriptableObject.CreateInstance<nextLevelScript>();
        nextLevelScript l2 = ScriptableObject.CreateInstance<nextLevelScript>();
        nextLevelScript l3 = ScriptableObject.CreateInstance<nextLevelScript>();
        nextLevelScript l4 = ScriptableObject.CreateInstance<nextLevelScript>();
        nextLevelScript l5 = ScriptableObject.CreateInstance<nextLevelScript>();
        nextLevelScript l6 = ScriptableObject.CreateInstance<nextLevelScript>();
        nextLevelScript l7 = ScriptableObject.CreateInstance<nextLevelScript>();

        l1.SetFields(1,6);
        l2.SetFields(2,5);
        l3.SetFields(3,3);
        l4.SetFields(4,4);
        l5.SetFields(5,7);
        l6.SetFields(6,1);
        l7.SetFields(7,11);

        list4goals = new List<nextLevelScript>{l1,l2,l3,l4,l5,l6,l7};
    }
    private void levelProgressSaver(nextLevelScript currLevel)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            progressFromFile = reader.ReadToEnd();
        }
        levelProgress = int.Parse(progressFromFile);

        if(currLevel.SceneIndex==levelProgress)
        {
            progressFromFile=(currLevel.SceneIndex+1).ToString();

            File.WriteAllText(filePath, progressFromFile);
        }
    }
}