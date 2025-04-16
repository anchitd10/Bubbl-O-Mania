using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Htp_Handler : MonoBehaviour
{
    int count = 0;

    public GameObject htp1;
    public GameObject htp2;
    public GameObject htp3;
    public GameObject htp4;

    public GameObject b1;
    public GameObject f1;

    void Start()
    {
        count = 0;
        htp1.SetActive(true);
        htp2.SetActive(false);
        htp3.SetActive(false);
        htp4.SetActive(false);
        b1.SetActive(true);
        f1.SetActive(true);
    }

    public void OnforwardButton()
    {
        if (count == 0) {
            htp1.SetActive(true);
            htp2.SetActive(false);
            htp3.SetActive(false);
            htp4.SetActive(false);

        }
        else if (count == 1) {
            htp1.SetActive(false);
            htp2.SetActive(true);
            htp3.SetActive(false);
            htp4.SetActive(false);
        }
        else if (count == 2) {
            htp1.SetActive(false);
            htp2.SetActive(false);
            htp3.SetActive(true);
            htp4.SetActive(false);
        }
        else if (count == 3) {
            htp1.SetActive(false);
            htp2.SetActive(false);
            htp3.SetActive(false);
            htp4.SetActive(true);
            f1.SetActive(false);
        }
    }

    public void forWards()
    {
        count++;
        if (count == 4) {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void backWards()
    {
        count--;
        if (count == -1) {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
        {
        OnforwardButton();
        }
    }

