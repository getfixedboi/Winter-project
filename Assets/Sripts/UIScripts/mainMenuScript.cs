using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Mono.Data.Sqlite;

public class mainMenuScript : MonoBehaviour
{
    private const string filePath = "Assets/gameDataSaves/levelData.txt";
    private string progressFromFile = "";
    private int levelProgress;

    [Header ("registerCanvas refecence")]
    [SerializeField] public Canvas registerCanvas;
    private static bool isLoaded=false;

    [Header ("mainMenuCanvas refecence")]
    [SerializeField] Canvas mainMenuCanvas;

    [Header ("chapterMenuCanvas refecence")]
    [SerializeField] Canvas chapterSelectMenuCanvas;

    [Header ("levelMenuCanvas refecence")]
    [SerializeField] public Canvas levelSelectMenuCanvas;

    [Header ("settingsCanvas refecence")]
    [SerializeField] public Canvas settingsCanvas;

    [Header ("Buttons refecence")]
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;
    [SerializeField] Button button7;
    private void Start()
    {
        CanvasLoader();
        levelLocker();
    }

    private void CanvasLoader()
    {
        if(isLoaded==false)
        {
            registerCanvas.gameObject.SetActive(true);
            mainMenuCanvas.gameObject.SetActive(false);
            chapterSelectMenuCanvas.gameObject.SetActive(false);
            levelSelectMenuCanvas.gameObject.SetActive(false);
            settingsCanvas.gameObject.SetActive(false);
            isLoaded=true;
        }
        else
        {
             registerCanvas.gameObject.SetActive(false);
            mainMenuCanvas.gameObject.SetActive(false);
            chapterSelectMenuCanvas.gameObject.SetActive(false);
            levelSelectMenuCanvas.gameObject.SetActive(true);  
            settingsCanvas.gameObject.SetActive(false);
        }
    }

    //settings functions
    public void exitFromSettings()
    {
        settingsCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    } 

    

    public void levelLocker()
    {
        levelUnlockCheck(button2,2);
        levelUnlockCheck(button3,3);
        levelUnlockCheck(button4,4);
        levelUnlockCheck(button5,5);
        levelUnlockCheck(button6,6);
        levelUnlockCheck(button7,7);
    }
    //mainMenu functions
    public void ShowSettings()
    {
        settingsCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
    }

    public void DisplayChapterSelectMenu()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        chapterSelectMenuCanvas.gameObject.SetActive(true);
    }

    public void eraseData()
    {
        File.WriteAllText(filePath, "1");
        levelLocker();
    }

public void CloseGame()
{
    Application.Quit();

    using (var connection = new SqliteConnection(Connection.dbName))
    {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            int score = int.Parse(System.IO.File.ReadAllText(filePath));
            command.CommandText = "UPDATE userScore SET score = '" + score + "' WHERE username = '" + Connection.currentUser + "';";
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
}

    //chapterSelectMenu functions
    public void DisplayLevelSelectMenu()
    {
        chapterSelectMenuCanvas.gameObject.SetActive(false);
        levelSelectMenuCanvas.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        chapterSelectMenuCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
    //levelSelectMenu functions
    public void BackToChapterSelectMenu()
    {
        levelSelectMenuCanvas.gameObject.SetActive(false);
        chapterSelectMenuCanvas.gameObject.SetActive(true);
    }

    //levels
    private void levelUnlockCheck(Button button,int levelNum)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            progressFromFile = reader.ReadToEnd();
        }
        levelProgress = int.Parse(progressFromFile);

        if(levelProgress<levelNum)
        {
            button.interactable=false;
        }
        else 
        {
            button.interactable=true;
        }
    }

    private void levelLoader(int index)
    {
        levelSelectMenuCanvas.gameObject.SetActive(false);
        
        SceneManager.LoadScene(index);
    }

    public void LoadLevel1()
    {
        levelLoader(1);
    }

    public void LoadLevel2()
    {
    levelLoader(2);
    }

    public void LoadLevel3()
    {
    levelLoader(3);
    }
    public void LoadLevel4()
    {
        levelLoader(4);
    }
    public void LoadLevel5()
    {
        levelLoader(5);
    }
    public void LoadLevel6()
    {
        levelLoader(6);
    }
    public void LoadLevel7()
    {
        levelLoader(7);
    }


}