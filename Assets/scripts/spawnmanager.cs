using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    [SerializeField] GameObject enemyprefabs;
    [SerializeField] GameObject enemycontainer;
    //[SerializeField] GameObject powerupprefabs;
    [SerializeField] GameObject[] powerups;
    private bool stopspawning=false;
    void Start()
    {
        StartCoroutine(spawnenemy());
        StartCoroutine(spawnpoweup());

    }
    /*public void startspawning()
    {
        StartCoroutine(spawnenemy());
        StartCoroutine(spawnpoweup());
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnenemy()
    {
       // yield return new WaitForSeconds(3f);
        while(stopspawning==false)
        {
         GameObject newenemy= Instantiate(enemyprefabs, new Vector3(Random.Range(23f, -23f), 6, 0), Quaternion.identity);
            // create new gameoject name enemycontainer nd make ut parent of enemyprefabs;
            newenemy.transform.parent = enemycontainer.transform;
            yield return new WaitForSeconds(2f);
        }
    }

   IEnumerator spawnpoweup()
    {
        //yield return new WaitForSeconds(3f);
        while (stopspawning == false)
        {
            Instantiate(powerups[Random.Range(0,3)], new Vector3(Random.Range(23f, -23f), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 8f));
        }
    }

    public void onplayerdeath()
    {
        stopspawning = true;
    }
}
