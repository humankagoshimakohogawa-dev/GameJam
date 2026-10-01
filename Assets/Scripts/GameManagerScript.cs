using UnityEngine;

using System.Collections; // 

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //１）変数を準備
    private EnemyJudgeScript first, second; // 1枚目と2枚目
    private int matchedPairs = 0; // 揃ったペア数
    private int totalPairs = 2; 
    private bool gameClear = false; //ゲームクリアしたらtrue
    //private bool isLocking = false; //操作ロック用

    private bool isSetupCompleted = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ２）初期化処理
        first = null; //まだ何も入ってない（めくってない）
        second = null;
        matchedPairs = 0;
        gameClear = false;
      //  isLocking = false;
        isSetupCompleted = false;
        totalPairs = 0;

        Debug.Log("ゲームスタート！生成を待っています");
    }

    // Update is called once per frame
    void Update()
    {
        //３）クリアした時の処理
        // 1. まだクリアしていない  ←この直後にクリアするので、直前ではクリアしてない状態です
        // 2. 全部のペアが揃った
        // この2つが同時に成立したとき
        if (!isSetupCompleted)
        {
            CheckInstantiateCompletion();
            return; // 枚数が確定するまでは、下のクリア判定は走らせない
        }
        if (!gameClear && matchedPairs == totalPairs)
        {
            gameClear = true;
            Debug.Log(" 全部のモグラが消えました！クリア画面へ遷移します。");
            SceneManager.LoadScene("ResultScene"); // ←実際のシーン名に合わせてください
        }
        //if (!gameClear && matchedPairs == totalPairs)
        //{
        //    gameClear = true;
        //    Debug.Log("CLEAR!");
        //    SceneManager.LoadScene("ResultSceneScene");
        //}
        //
    }

    public void OnPairMatched()
    {
        matchedPairs++;
        Debug.Log("カウント増加！現在の進捗: {matchedPairs} / {totalPairs}");
    }
    // 生成スクリプトを外から監視して、終わったらペア数を自動計算する関数
    void CheckInstantiateCompletion()
    {
        // 画面内にある「MoguraInstantiateScript」を探す
         MoguraInstantiateScript instantiator =FindAnyObjectByType <MoguraInstantiateScript>();

        if (instantiator != null)
        {
            System.Reflection.FieldInfo field = typeof(MoguraInstantiateScript).GetField("moguras", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            // ヒエラルキー上に「Enemy」タグがついたカードが生成され始めているか確認

            if (field != null)
            {
                 GameObject[] mogurasArray = (GameObject[])field.GetValue(instantiator);
                bool allGenerated = true;
                if (mogurasArray != null && mogurasArray.Length > 0)
                {
                    foreach (GameObject m in mogurasArray)
                    {
                        if (m != null) // まだ生成されていないモグラが1つでも残っていれば、完了とみなさない
                        {
                            allGenerated = false;
                            break;
                        }
                    }
                }
                else
                {
                    allGenerated = false;
                }

                //  すべてのモグラが完全に生成されきった瞬間！
                if (allGenerated)
                {
                    // 画面上にある「Enemy」タグのついた完成品モグラを、このタイミングで一斉に数える
                    GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");

                    if (currentEnemies.Length > 0)
                    {
                        totalPairs = currentEnemies.Length / 2; // 正しい総ペア数がバッチリ入る
                        isSetupCompleted = true; // 監視モードを終了して、通常のクリア判定モードへ移行

                        Debug.Log($"【大成功】すべてのモグラ生成完了を検知！ 実際のモグラ: {currentEnemies.Length}枚 (総ペア数: {totalPairs})");
                    }
                }
            }
        }
    }
    

    //４）カードがめくられた処理
    public void OnCardOpened(EnemyJudgeScript cs)
    {
        //１枚目がめくられる
        if (first == null)
        {
            first = cs; //1枚目にめくったカードを記録
            return; // ここで関数を終わりにする
        }
        //もし２枚目だったら
        if (second == null)
        {
            second = cs; //2枚目にめくったカードを記録
           // StartCoroutine(Judgement());
        }
    }
    
}