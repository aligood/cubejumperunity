using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// its import for Text mesh pro for score 
using TMPro;


public class GameManager : MonoBehaviour
{

    //for obstacle and its taksir and spwan location 
    public GameObject obstacle;
    public Transform spwanPoint;
    
    //for score and text of score 
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;

    public GameObject player;


    // in ja miaim oon gameobject button ha ro tarif mikonim 
    public GameObject exitButton;
    

    //for mute and sound btn 
    private bool isMuted;
    public GameObject muteButton;
    public GameObject SoundButton;

    // for stop game 
    public GameObject stopButton;



    

    // emkan dare ke ezafe she 
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED" , isMuted ? 1 : 0) == 1;
        AudioListener.pause = isMuted;
        if(isMuted)
        {
            muteButton.SetActive(false);
            SoundButton.SetActive(true);
           
        }
        else
        {
            muteButton.SetActive(true);
            SoundButton.SetActive(false);
        }
    }

    // IEnum for spacial work in spacial time and its spacialy for Spwan obstacle
    IEnumerator SpwanObstacle()
    {
        while(true)
        {
            float waitTime = Random.Range(0.6f , 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spwanPoint.position , Quaternion.identity);
        }
    }
    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // this func for Start the Game and etefaghati ke to halat start miofte 
    public void GameStart()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        stopButton.SetActive(true);
        playButton.SetActive(false);
        exitButton.SetActive(false);

        

        StartCoroutine("SpwanObstacle");
        InvokeRepeating("ScoreUp", 2f , 1f);
    }

    // this func is for stop the game and everything
    public void GameStop()
    {
        Time.timeScale = 0;
        player.SetActive(false);
        stopButton.SetActive(false);
        playButton.SetActive(true);
        StopCoroutine("SpwanObstacle");
        CancelInvoke("ScoreUp");
        
        
    }


    // this func is for Mute or sound va save shodanesh  
    public void MuteSound()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        PlayerPrefs.SetInt("MUTED" , isMuted ? 1 : 0);

        if(isMuted)
        {
            muteButton.SetActive(false);
            SoundButton.SetActive(true);
        }
        else
        {
            muteButton.SetActive(true);
            SoundButton.SetActive(false);
        }

        
    }

    // this func for Exit as app 

    public void Exit()
    {
        Application.Quit();
    }

}
