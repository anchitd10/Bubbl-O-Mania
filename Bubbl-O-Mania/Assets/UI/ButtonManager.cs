using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button mainButton;           // Main menu button
    public Button SettingButton;        // Settings button
    public Button HTPButton;            // How to Play button
    public Button startButton;          // Start button
    public Button BubblecombButton;     // Map Level-1 button
    public Button WaterhazardButton;    // Map Level-2 button
    public Button BackButton;           // Back button
    public Button RetryButton;          // Retry button
    public Button exitButton;           // Exit button

    // Start is called before the first frame update
    public void Start()
    {
        // Ensure the option buttons are hidden at the start
        BubblecombButton.gameObject.SetActive(false);
        WaterhazardButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

        // Add listeners to the buttons
        mainButton.onClick.AddListener(() => LoadScene("Menu"));
        SettingButton.onClick.AddListener(() => LoadScene("Settings"));
        HTPButton.onClick.AddListener(() => LoadScene("HTP"));
        exitButton.onClick.AddListener(ExitGame);
        startButton.onClick.AddListener(OnStartButtonClick);
        BubblecombButton.onClick.AddListener(() => LoadScene("Level-1"));
        WaterhazardButton.onClick.AddListener(() => LoadScene("Level-2"));
        BackButton.onClick.AddListener(() => LoadScene("Menu"));
        RetryButton.onClick.AddListener(() => LoadScene("Menu"));
    }

    // Called when the Start button is clicked
    public void OnStartButtonClick()
    {
        // Disable the main menu buttons
        mainButton.gameObject.SetActive(false);
        SettingButton.gameObject.SetActive(false);
        HTPButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        // Enable the map option buttons and back button
        BubblecombButton.gameObject.SetActive(true);
        WaterhazardButton.gameObject.SetActive(true);
        //BackButton.gameObject.SetActive(true);
    }

    // Called when the Back button is clicked
    public void OnBackButtonClick()
    {
        // Disable the map option buttons and back button
        BubblecombButton.gameObject.SetActive(false);
        WaterhazardButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

        // Enable the main menu buttons
        mainButton.gameObject.SetActive(true);
        SettingButton.gameObject.SetActive(true);
        HTPButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    // Load a specific scene
    public void LoadScene(string sceneName)
    {
        // Check if the scene exists in the Build Settings
        if (SceneUtility.GetBuildIndexByScenePath(sceneName) != -1) {
            Debug.Log($"Loading scene: {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
        else {
            Debug.LogError($"Scene '{sceneName}' is not in the Build Settings.");
        }
    }

    // Exit the application
    public void ExitGame()
    {
        Debug.Log("Exiting the game...");

        // Exit the application
        Application.Quit();

#if UNITY_EDITOR
        // Stop play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
