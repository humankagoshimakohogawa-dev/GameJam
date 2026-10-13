using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [Header("今回の結果とランキングを表示するText")]
    public TMP_Text killTime;

    // ランキングに保存する記録の数
    const int RANKING_COUNT = 3;

    // 今回のクリア時間
    float nowScore;

    // ベストタイムを保存する配列
    float[] bestScore = new float[RANKING_COUNT];

    void Start()
    {
        // 今回のクリア時間を取得
        nowScore = PlayerPrefs.GetFloat("nowScore", 0.0f);

        // 過去のベストタイムを読み込む
        for (int i = 0; i < RANKING_COUNT; i++)
        {
            bestScore[i] = PlayerPrefs.GetFloat("Score" + (i + 1), 0.0f);
        }

        // 今回の記録をランキングに追加
        if (nowScore > 0)
        {
            for (int i = 0; i < RANKING_COUNT; i++)
            {
                // 記録がない場合、または今回の時間が短い場合
                if (bestScore[i] == 0 || nowScore < bestScore[i])
                {
                    // 下位の記録を一つずつ後ろへ移動
                    for (int j = RANKING_COUNT - 1; j > i; j--)
                    {
                        bestScore[j] = bestScore[j - 1];
                    }

                    // 今回の記録を挿入
                    bestScore[i] = nowScore;
                    break;
                }
            }
        }

        // ランキングを保存
        for (int i = 0; i < RANKING_COUNT; i++)
        {
            PlayerPrefs.SetFloat("Score" + (i + 1), bestScore[i]);
        }

        PlayerPrefs.Save();

        // 今回の記録とランキングを文字列にする
        string resultText = "クリア時間\n"
            + nowScore.ToString("F2") + "秒\n\n"
            + "ベストタイムランキング\n";

        for (int i = 0; i < RANKING_COUNT; i++)
        {
            if (bestScore[i] > 0)
            {
                resultText += (i + 1) + " : "
                    + bestScore[i].ToString("F2") + "秒\n";
            }
            else
            {
                resultText += (i + 1) + " : ---\n";
            }
        }

        // 画面に表示
        killTime.text = resultText;

        Debug.Log(resultText);
    }
}
