using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    [SerializeField] private bool isgameover;
    


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&& isgameover==true)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void gameover()
    {
        isgameover= true;
    }
}
