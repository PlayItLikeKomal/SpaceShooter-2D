using UnityEngine;


public class enemy : MonoBehaviour
{
    private player _Player;
    private Animator _animation;
    [SerializeField] float speed = 2f;
    [SerializeField] private AudioSource _audiosource;
   
    void awake()
    {
        _Player= GameObject.FindWithTag("Player").GetComponent<player>();
        _audiosource = GetComponent<AudioSource>();

      /*  _animation = GetComponent<Animator>();
        if(_animation!=null)
        {
            Debug.Log("the animator is null");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
        if (transform.position.y < -4.4f)
        {
            transform.position = new Vector3(Random.Range(23.0f, -23.0f),0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            player Player = other.transform.GetComponent<player>();
            if (Player != null)
            {
               // _audiosource.Play();
                Player.demage();
                
            }

            GetComponent<Animator>().SetTrigger("onenemydeath");
            speed = 0;
            _audiosource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject,1.8f);

        }

        if (other.tag =="laser")
        {
            Destroy(other.gameObject);

          if (_Player!= null)
          {
                _Player.addScore();
           }
            GetComponent<Animator>().SetTrigger("onenemydeath");
            speed = 0;
            _audiosource.Play();
            Destroy(this.gameObject,1.8f);
        }
    }
}
