using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryManager : MonoBehaviour
{
    [SerializeField] GameObject BackgroundImage;

    [SerializeField] List<GameObject> retryList = new List<GameObject>();

    public int index = 0;

    void RandomizeIndex()
    {
        if (retryList.Count > 0) {
            index = Random.Range(0, retryList.Count); // Generates a random index from 0 to retryList.Count - 1
            Debug.Log($"Randomized Index: {index}");
        }
        else {
            Debug.LogWarning("The retryList is empty. Cannot randomize index.");
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        RandomizeIndex();
        BackgroundImage = retryList[index];
        BackgroundImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
