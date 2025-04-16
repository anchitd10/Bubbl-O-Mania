using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    /*
    [SerializeField] GameObject[] objects;
    [SerializeField] Vector3 Spawnvalues;
    [SerializeField] float spawnwait;
    [SerializeField] float startwait;
    [SerializeField] float objectLifetime;
    int object_index;
    */

    public GameObject objectPrefab; // The object to spawn
    public float spawnInterval = 2f;

    private bool canSpawn = false; // Determines whether spawning is allowed
    private Coroutine spawnCoroutine;

    /*
    void Start()
    {
        StartCoroutine(waitSpawner());
    }
    */

    public void StartSpawning()
    {
        if (!canSpawn)
        {
            canSpawn = true;
            spawnCoroutine = StartCoroutine(SpawnObjects());
        }
    }

    public void StopSpawning()
    {
        if (canSpawn)
        {
            canSpawn = false;
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }
    }
    private IEnumerator SpawnObjects()
    {
        while (canSpawn)
        {
            Instantiate(objectPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //IEnumerator waitSpawner()
    //{
    //yield return new WaitForSeconds(startwait);

    //while (true)
    //{
    //object_index = Random.Range(0, objects.Length);
    //Vector3 spawnPosition = new Vector3(Spawnvalues.x, Spawnvalues.y, Spawnvalues.z);
    //  Instantiate(objects[object_index], spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity /*gameObject.transform.rotation*/);
    // //GameObject spawnedObject = Instantiate(objects[object_index], spawnPosition + transform.TransformPoint(0, 0, 0),Quaternion.identity /*gameObject.transform.rotation*/);
    // //spawnedObjects.Add(spawnedObject);
    // //Debug.Log(spawnedObjects);

    //    yield return new WaitForSeconds(spawnwait);
    //  }
    //}
}
