using UnityEngine;
using UnityEngine.SceneManagement;// <- SceneManagerを使うために必要

public class ResultManager : MonoBehaviour
{
    private void Start()
    {
        // カーソルを表示して、ロックを解除する
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ReturnScene()
    {

        SceneManager.LoadScene("TitleScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("CheckScene");//仮Testなので実際は変えてください
    }
}
