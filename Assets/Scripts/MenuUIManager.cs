using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;

    void Start()
    {
        GameManager.Instance.LoadPreviousHighScore();
        if (GameManager.Instance.previousHighScore == null) return;
        titleText.text = $"Best Score : {GameManager.Instance.previousHighScore.playerName} : {GameManager.Instance.previousHighScore.score}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }

    public void UpdatePlayerName(string value)
    {
        GameManager.Instance.playerName = value;
    }
}
