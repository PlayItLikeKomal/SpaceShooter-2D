using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    
    [SerializeField] float speed=3;
    [SerializeField] int powerupid;
    [SerializeField] AudioClip _audioclip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y<-6.3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {              
            player player = collision.transform.GetComponent<player>();
            AudioSource.PlayClipAtPoint(_audioclip, transform.position);
            if(player!=null)
            {
     
                switch (powerupid)
                {
                    case 0:
                        player.tripleshotactive();
                        break;
                    case 1:
                        player.speedboastactive();
                        break;
                    case 2:
                        player.sheildactive();
                        break;
                    default:
                        Debug.Log("sheild1");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
