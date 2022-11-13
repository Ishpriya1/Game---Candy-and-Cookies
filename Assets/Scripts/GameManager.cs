using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    public GameObject Interstitial;

    private void Start()
    {
        Time.timeScale = 1;
       
    }

    
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        Interstitial.GetComponent<InterstitialAds>().ShowInterstitial();
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

 
}
