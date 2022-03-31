using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    private float spawnRate = 1.0f;
    private int score = 0;
    public bool isGameActive;
    public Button restartBtn;
    public GameObject ScreenTitle;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Item"), LayerMask.NameToLayer("Item"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(float difficulty)
    {
        isGameActive = true;
        spawnRate = difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        restartBtn.onClick.AddListener(RestartGame);
        ScreenTitle.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        restartBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
