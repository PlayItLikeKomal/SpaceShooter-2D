using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 8.0f;
    
    void Update()
    {
        transform.Translate(Vector3.up *speed* Time.deltaTime);
        if(transform.position.y>7.5)
        { if(transform.parent!=null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject,3f);
        }

        
        
    }
  
}
