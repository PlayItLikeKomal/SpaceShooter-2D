using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    [SerializeField] private AudioClip explosionsound;
   // [SerializeField] private AudioSource _audiosource;
    void Start()
    {
        
        Destroy(this.gameObject, 3f);
        
    }

   

   
}
