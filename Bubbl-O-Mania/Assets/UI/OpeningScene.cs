using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    private void Start()
    {
        Invoke("NextScene", 4.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            NextScene();
        }
    }

    public void NextScene()
    {

        SceneManager.LoadScene("MainMenu");
    }
}
