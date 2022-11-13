using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public float roundTime = 60f;
    private UIManager uiMan;

    private bool endingRound = false;

    private Board board;

    public int currentScore;
    public float displayScore;
    public float scoreSpeed;

    public int scoreTarget1, scoreTarget2, scoreTarget3;

    public GameObject Interstitial;


    void Awake()
    {
        uiMan = FindObjectOfType<UIManager>();
        board = FindObjectOfType<Board>();
    }


    // Update is called once per frame
    void Update()
    {
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;

            if (roundTime <= 0)
            {
                roundTime = 0;

                endingRound = true;

            }
        }

        if (endingRound && board.currentState == Board.BoardState.move)
        {
            WinCheck();
            endingRound = false;
        }

        uiMan.timeText.text = roundTime.ToString("0.0");

        displayScore = Mathf.Lerp(displayScore, currentScore, scoreSpeed * Time.deltaTime);
        uiMan.scoreText.text = displayScore.ToString("0");
    }

    private void WinCheck()
    {
        uiMan.roundOverScreen.SetActive(true);

        uiMan.winScore.text = currentScore.ToString();

        

        if (currentScore >= scoreTarget3)
        {
            uiMan.winText.text = "Excellent!";
            uiMan.winStars3.SetActive(true);

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star2", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star3", 1);

            Interstitial.GetComponent<InterstitialAds>().ShowInterstitial();

        }
        else if (currentScore >= scoreTarget2)
        {
            uiMan.winText.text = "Great Job!";
            uiMan.winStars2.SetActive(true);

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star2", 1);

            Interstitial.GetComponent<InterstitialAds>().ShowInterstitial();

        }
        else if (currentScore >= scoreTarget1)
        {
            uiMan.winText.text = "Try again?";
            uiMan.winStars1.SetActive(true);

            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);

            Interstitial.GetComponent<InterstitialAds>().ShowInterstitial();

        }
        else
        {
            uiMan.winText.text = "Try again?";

            Interstitial.GetComponent<InterstitialAds>().ShowInterstitial();
        }

        SFXManager.instance.PlayRoundOver();

    }
}
