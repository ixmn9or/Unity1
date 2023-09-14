using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Spawner sp;

    int score = 0;
    bool isGameOver = false;

    public static GameManager instance;

    public TMP_Text comboText;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverText;

    public int combo;
    public void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (combo > 0)
        {
            comboText.text = "x" + combo.ToString();
        }
        else
        {
            comboText.text = "x1";
        }
    }

    public void IncreaseScore(int amount)
    {
        
        combo += 1;
        if (combo >= 2)
        {
            score += amount * combo;
        }
        else
        {
            score += amount;
        }
        if (score == 300)
        {
            sp.hard = true;
        }
        scoreText.text = "Score: " + score;
    }

    public void InitiateGameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void PauseBtn()
    {
        Time.timeScale = 0f;
    }

    public void ContinueBtn()
    {
        Time.timeScale = 1f;
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
