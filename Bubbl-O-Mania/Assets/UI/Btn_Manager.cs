using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Manager : MonoBehaviour
{
    
    void Start()
    {
        
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Maps");
    }
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void OnHazardButtonClick()
    {
        // SceneManager.LoadScene("Hazard");
        SceneManager.LoadScene("Level-1");
    }

    public void OnCombButtonClick()
    {
        // SceneManager.LoadScene("BubbleComb");
        SceneManager.LoadScene("Level-2");
    }

    public void OnPlayerOneWin()
    {
        SceneManager.LoadScene("RetryP2");
    }
    public void OnPlayerTwoWin()
    {
        SceneManager.LoadScene("RetryP1");
    }
    public void OnHTP()
    {
        SceneManager.LoadScene("htp");
    }




}
