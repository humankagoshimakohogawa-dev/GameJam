using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameManagerFScript GMF;
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

    //リザルトへ移行
    public void ToResult()
    {
        if (GMF.isGameCleare)
        {
            SceneManager.LoadScene("ResultScene");
        }

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
