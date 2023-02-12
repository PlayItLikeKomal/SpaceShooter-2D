using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    [SerializeField] float rotationspeed=3f;
    [SerializeField] private GameObject explosionprefabs;
  //  private spawnmanager _spawnmanager;
    void Start()
    {
     //   _spawnmanager = GameObject.Find("spawnmanager").GetComponent<spawnmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationspeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag=="laser")
        {
            Instantiate(explosionprefabs, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
         //   _spawnmanager.startspawning();
            Destroy(this.gameObject);
        }
    }
}
