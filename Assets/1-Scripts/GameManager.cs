using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text txtPoints;
    public Text txtTime;
    public Text txtBestScore;
    public Text txtBestTime;
    public GameObject txtGameOver;

    public int points;
    public float time;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            txtBestScore.text = "BEST: " + PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            txtBestScore.text = "BEST: 0";
        }
        if (PlayerPrefs.HasKey("BestTime"))
        {
            txtBestTime.text = "TIME: " + PlayerPrefs.GetInt("BestTime");
        }
        else
        {
            txtBestTime.text = "TIME: 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        txtPoints.text = "SCORE: " + points;
        txtTime.text = "TIME: " + (int)time;


        if (FindObjectOfType<PlayerScript>() == null)
        {
            if (PlayerPrefs.HasKey("BestScore"))
            {
                if (points > PlayerPrefs.GetInt("BestScore"))
                {
                    PlayerPrefs.SetInt("BestScore", points);
                }
            }
            else
            {
                PlayerPrefs.SetInt("BestScore", points);
            }
            if (PlayerPrefs.HasKey("BestTime"))
            {
                if ((int)time > PlayerPrefs.GetInt("BestTime"))
                {
                    PlayerPrefs.SetInt("BestTime", (int)time);
                }
            }
            else
            {
                PlayerPrefs.SetInt("BestTime", (int)time);
            }
            StartCoroutine(StartAgain());
        }
    }

    public IEnumerator StartAgain()
    {
        txtGameOver.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }
}
