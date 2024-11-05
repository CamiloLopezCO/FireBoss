using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;


    private void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
