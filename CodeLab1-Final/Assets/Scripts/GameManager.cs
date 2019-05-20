using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameEnd;

//    public Text HPText;
    
    public Text scoreText;
    public Text highScoreText;

    const string PLAYER_PREF_HIGHSCORE = "highScore";
    const string FILE_HIGH_SCORE = "/MyHighScoreFile.txt";


    //public HighscoreManager HighscoreManager;
    
	
    int score = 0;
    // Use this for initialization
    void Start()
    {
//        HPText = GameObject.Find("Canvas/Hearts").GetComponent<Text>();
        highScoreText = GameObject.Find("Canvas/HighScore").GetComponent<Text>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();

        gameEnd = GameObject.Find("Canvas/GameOver");
        gameEnd.SetActive(false);


        
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Score = 0;
        HP = 5;

        string highScoreFileTxt = File.ReadAllText(Application.dataPath + FILE_HIGH_SCORE);

        string[] scoreSplit = highScoreFileTxt.Split(' ');
		
        HighScore = Int32.Parse(scoreSplit[1]);
    }
   
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreText.text = "Couples: " + score;
            HighScore = score;
        }
    }

    int highScore = 0;
    
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            if (value > highScore)
            {
                highScore = value;
                print("highScore = " + highScore);
                highScoreText.text = "Most Couples: " + highScore;
				PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, highScore);

                Debug.Log("Application.dataPath: " +  Application.dataPath);
                string fullPathToFile = Application.dataPath + FILE_HIGH_SCORE;
				
                File.WriteAllText(fullPathToFile, "HighScore: " + highScore);

            }
        }
    }

    int hp = 5;
    public int HP {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
            //HPText.text = "Hearts: " /*+ hp*/;
    
        }
    }

    public static GameManager instance;

   
	
    // Update is called once per frame
    void Update () {
        if (HP<=0)
        {
            gameEnd.SetActive(true);
        }
    }

    /*public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
        
        HPText = GameObject.Find("Canvas/Hearts").GetComponent<Text>();
        highScoreText = GameObject.Find("Canvas/HighScore").GetComponent<Text>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();

        
        gameEnd = GameObject.Find("Canvas/GameOver");
        gameEnd.SetActive(false);
        print("restart");
    }
    
    public void RestartScene()
    {
        StartCoroutine(YouWin_Coroutine());
    }
    IEnumerator YouWin_Coroutine()
    {
        SceneManager.LoadScene("SampleScene");        
        yield return null; // wait for scene to be loaded
        
        HPText = GameObject.Find("Canvas/Hearts").GetComponent<Text>();
        highScoreText = GameObject.Find("Canvas/HighScore").GetComponent<Text>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();

        
        gameEnd = GameObject.Find("Canvas/GameOver");
        //gameEnd.SetActive(false);
        print("restart");
    }*/
    
    
}
