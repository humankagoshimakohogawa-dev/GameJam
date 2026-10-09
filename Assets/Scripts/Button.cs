using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // ゲーム開始
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    // もう一度遊ぶ
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void ruleScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ruleScene");
    }

    // タイトルに戻る
    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    // ゲーム終了
    public void ExitGame()
    {
        Application.Quit();
    }
}
