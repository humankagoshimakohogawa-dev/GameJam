using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
   public void ToRule()
    {
        SceneManager.LoadScene("RuleScene");
        Debug.Log("ルール説明へ");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("スタートゲーム");
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        Debug.Log("タイトルへ戻る");
    }
}
