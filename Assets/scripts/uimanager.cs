using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class uimanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private Image livesimg;
    [SerializeField] private Sprite[] _livesprits;
    [SerializeField] private GameObject gameovertext;
    [SerializeField] private GameObject restart;
    [SerializeField] gamemanager _gamemanager;

    void Start()
    {    // assingning score 10

        scoretext.text = "score:" + 0;
        gameovertext.gameObject.SetActive(false);
        _gamemanager = GameObject.Find("game_manager").GetComponent<gamemanager>();
        if(_gamemanager==null)
        {
            Debug.LogError("gamemanager");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updatescore(double playerscore)
    {
        scoretext.text = "score:" + playerscore.ToString();

    }
    public void UpdateLives(int currentLives)
    {
        livesimg.sprite = _livesprits[currentLives];
        if (currentLives == 0)
        {
            _gamemanager.gameover();
            gameovertext.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }
}