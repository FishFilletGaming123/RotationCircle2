using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public static GameManager instance;
    public TextMeshProUGUI[] scoreText;

    private int score;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
          
    }

    void Update()
    {
        foreach (TextMeshProUGUI text in scoreText)
        {
            text.text = score.ToString();
        }
    }

    // Update is called once per frame
    public void AddScore()
    {
        score++;
        Debug.Log(score);
    }

    public void DeathScreen()
    {
        GameOverUI.SetActive(true);
    }
    public void RetryGame()
    {
        score = 0;
        GameOverUI.SetActive(false);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }

}
