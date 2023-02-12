using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour

{
    [SerializeField] float speed = 3;
    private float speedmultiplier = 2;
    public GameObject laserprefab;
    public GameObject tripleshot;
    private float firerate = 0.5f;
    private float canfire = -1f;
    [SerializeField]  int lives=3;
    private spawnmanager _spawnmanager;
    [SerializeField]private bool istripleshotactive = false;
    [SerializeField] private bool isspeedboastactive = false;
    [SerializeField]  private bool issheildactive = false;
    [SerializeField] private GameObject sheildvitualizerenable;
    [SerializeField] private double _score=0;
    [SerializeField] private uimanager _uimanager;
    [SerializeField] private GameObject fireleft;
    [SerializeField] private GameObject fireright;
    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private AudioClip lasersound;
 
    void Start()
    {
        _spawnmanager = GameObject.Find("spawnmanager").GetComponent<spawnmanager>();
        _uimanager = GameObject.Find("canvas").GetComponent<uimanager>();
        _audiosource = GetComponent<AudioSource>();
        if(_spawnmanager==null) 
        {
            Debug.Log("error");
        }
        if(_audiosource==null)
        {
            Debug.Log("audioerror");
        }
        else 
        {
            _audiosource.clip = lasersound;
        }
        



    }

    // Update is called once per frame
    void Update()
    {
        calculatemovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            firelaser();
          //  Instantiate(laserprefab,transform.position,Quaternion.identity);
        }


    }
    private void calculatemovement()
    {

        // both are same 
        /* transform.Translate(Vector3.right);
         transform.Translate(new Vector3(1, 0, 0)); */
        float horizontalinput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalinput * speed * Time.deltaTime);
         float verticalinput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalinput * speed * Time.deltaTime);


        if (transform.position.y > 6.7f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.4f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        if (transform.position.x > 25f)
        {
            transform.position = new Vector3(-25f, transform.position.y, 0);
        }
        else if (transform.position.x < -25f)
        {
            transform.position = new Vector3(25, transform.position.y, 0);
        }
    }
    void firelaser()
    {
        canfire = Time.time + -firerate;
       
        if(istripleshotactive==true)
        {
            Instantiate(tripleshot,transform.position,Quaternion.identity);
        }
       else
        {
            Instantiate(laserprefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        }
        _audiosource.Play();

      }
    public void demage()
    {
       
        if(issheildactive==true)
        {
            issheildactive = false;
            sheildvitualizerenable.SetActive(false);
         
            return;
        }
         
        lives--;
     if(lives==2)
        {
            fireleft.SetActive(true);
        }
        if(lives==1)
        {
            fireright.SetActive(true);
        }
        _uimanager.UpdateLives(lives);
        if(lives<1)
        {
            _spawnmanager.onplayerdeath();
            Destroy(this.gameObject);
        }
        
    }
    public void tripleshotactive()
    {
       istripleshotactive = true;
        StartCoroutine(tripleshotpowerdownroutine());
    }
   
      
    IEnumerator tripleshotpowerdownroutine()
    {
       
            
            yield return new WaitForSeconds(3f);
        istripleshotactive =false;
    }

    public void speedboastactive()
    {    
        isspeedboastactive = true;
        speed *= speedmultiplier;
        StartCoroutine(speedboostpowerdownbost());
    }
    IEnumerator speedboostpowerdownbost()
    {
        yield return new WaitForSeconds(5.0f);
        isspeedboastactive = false;
        speed /= speedmultiplier;
    }

    public void sheildactive()
    {
        issheildactive = true;
        sheildvitualizerenable.SetActive(true);
       
    }

    /* public void increasescore(double points=0)
   {
        Debug.Log("eneny ship down");
        score +=points;
         _uimanager.updatescore(score);
        
    }*/
    public void addScore()

    {

        _score += 10;

    }
}
        