using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using System;
using System.IO;

public class Connection : MonoBehaviour
{
    [Header("canvas references")]
    [SerializeField] Canvas regCanvas;
    [SerializeField] Canvas mainMenuCanvas;

    [Header("inputFields references")]
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TMP_InputField confirmPasswordField;

    [Header("errorText reference")]
    [SerializeField] TMP_Text errorText;

    [Header("Script reference")]
    [SerializeField] mainMenuScript objMainMenuScript;

    public static string dbName = "URI=file:Users.db";

    private const string filePath = "Assets/gameDataSaves/levelData.txt";

    public static string currentUser;

    private void Start()
    {
        CreateDB();
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS users (username VARCHAR(20), password VARCHAR(20));";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS userScore (username VARCHAR(20), score INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    private bool Validation()
    {
        return usernameField.text!="" && passwordField.text!="" && usernameField.text.Length>4 && passwordField.text.Length>4 && passwordField.text==confirmPasswordField.text;
    }

    public void Login()
{
    if (Validation())
    {
        string username = usernameField.text;
        string password = passwordField.text;

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM users WHERE username='" + username + "' AND password='" + password + "';";
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currentUser = username;
                        // Login successful
                        errorText.text = "";
                        Debug.Log("Login successful");
                        SwitchToMainMenu();
                        reader.Close();
                        // Get user's score from the userScore table
                        command.CommandText = "SELECT score FROM userScore WHERE username='" + username + "';";
                        using (IDataReader scoreReader = command.ExecuteReader())
                        {
                            if (scoreReader.Read())
                            {
                                int score = scoreReader.GetInt32(0);
                                string scoreText = score.ToString();

                                // Save progress
                                string progressText = scoreText;
                                System.IO.File.WriteAllLines(@"Assets/gameDataSaves/levelData.txt", new string[] { progressText });
                                Debug.Log("Progress saved to file");

                                objMainMenuScript.levelLocker();
                            }
                            scoreReader.Close();
                        }
                    }
                    else
                    {
                        // Login failed
                        errorText.text = "Invalid username or password";
                        Debug.Log("Login failed");
                    }
                    
                }
            }

            connection.Close();
        }
    }
}

public void Register()
{
    if (Validation())
    {
        string username = usernameField.text;
        string password = passwordField.text;

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM users WHERE username='" + username + "';";
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    errorText.text = "User already exists";
                }
                else
                {
                    currentUser = username;
                    command.CommandText = "INSERT INTO users (username, password) VALUES ('" + username + "', '" + password + "');";
                    command.ExecuteNonQuery();
                    Debug.Log("Registration successful");

                    // Add user to userScore table
                    command.CommandText = "INSERT INTO userScore (username, score) VALUES ('" + username + "', 1);";
                    command.ExecuteNonQuery();

                    // Save progress
                    File.WriteAllText(filePath, "1");

                    Debug.Log("Progress saved to file");
                    objMainMenuScript.levelLocker();
                    SwitchToMainMenu();
                    
                }
            }

            connection.Close();
        }
    }
}
    private void SwitchToMainMenu()
    {
        regCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
}