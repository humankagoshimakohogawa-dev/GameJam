using UnityEngine;

using System.Collections; // 

 
public class GameManager : MonoBehaviour
{
    //１）変数を準備
    private EnemyJudgeScript first, second; // 1枚目と2枚目
    private int matchedPairs = 0; // 揃ったペア数
    private int totalPairs = 2; 
    private bool gameClear = false; //ゲームクリアしたらtrue

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ２）初期化処理
        first = null; //まだ何も入ってない（めくってない）
        second = null;
        matchedPairs = 0;

        Debug.Log("ゲームスタート！");
    }

    // Update is called once per frame
    void Update()
    {
        //３）クリアした時の処理
        // 1. まだクリアしていない  ←この直後にクリアするので、直前ではクリアしてない状態です
        // 2. 全部のペアが揃った
        // この2つが同時に成立したとき
        if (!gameClear && matchedPairs == totalPairs)
        {
            gameClear = true;
            Debug.Log("CLEAR!");
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

            //７）判定処理へ...
            //コルーチンは 作業を途中で止めたり、待ったりしながら進められる特別な関数
            //StartCoroutine(Judgement());
        }
    }

    ////５）判定の関数
    //IEnumerator Judgement()
    //{
    //    //コルーチンの処理を 0.3 秒だけ中断して、時間が経ったら続きから再開する
    //    yield return new WaitForSeconds(0.3f);

    //    //ペアが成立した場合
    //    if (first.pairId == second.pairId)
    //    {
    //        first.ShowFront();
    //        second.ShowFront();
    //        matchedPairs++; //１加算
    //    }
    //    else
    //    {
    //        //さらに0.5秒中断
    //        yield return new WaitForSeconds(0.5f);
    //        first.ShowBack();
    //        second.ShowBack();
    //    }
    //    first = null;
    //    second = null;
    //}
}