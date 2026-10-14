using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerFScript : MonoBehaviour
{
    [Header("現在残っているモグラの数")]
    public int mogurasCount = 24;

    [Header("ゲームクリア条件がそろっているか否か")]
    public bool isGameCleare = false;

    [Header("現在立っているモグラを格納")]
    public GameObject[] standingMoguras = new GameObject[2];

    //=============================================================================================
    void Start()
    {
        mogurasCount = 24;
    }

    //=============================================================================================
    void Update()
    {
        // シーン上のモグラの数を数える
        CountMoguras();

        // モグラが二匹立ったら、モグラ破棄処理を実行
        if (standingMoguras[0] != null && standingMoguras[1] != null) { Invoke("KillMogura", 1); }

        //ゲームをクリアしたら1秒後にリザルトシーンに遷移
        if (isGameCleare == true)
        {
            Invoke("ToResult", 1.0f);
            //Debug.Log("ToResult");
        }
    }

    //=============================================================================================
    void CountMoguras()
    {
        // 数が0になったらゲームクリア判定をtrueに
        if (mogurasCount <= 0)
        {
            isGameCleare = true;
            //Debug.Log("clear");
        }

    }

    //=============================================================================================
    void KillMogura()
    {
        if (standingMoguras[0] == null || standingMoguras[1] == null) { return; }

            // 立っているモグラがお互いに同じタグを持っていたら
            if (standingMoguras[0].gameObject.tag == standingMoguras[1].gameObject.tag)
        {
            // モグラのスクリプトを参照し、撃退フラグをtrueに
            MoguraStanderScript moguraStanderScript0 = standingMoguras[0].GetComponent<MoguraStanderScript>();
            moguraStanderScript0.isKilling = true;
            // 立ちモグラ確認配列内のモグラのオブジェクトを1秒待ってから破棄
            Destroy(standingMoguras[0].gameObject, 1.5f);
            standingMoguras[0] = null;
            --mogurasCount;

            MoguraStanderScript moguraStanderScript1 = standingMoguras[1].GetComponent<MoguraStanderScript>();
            moguraStanderScript1.isKilling = true;
            Destroy(standingMoguras[1].gameObject, 1.5f);
            standingMoguras[1] = null;
            --mogurasCount;
        }
        else if (standingMoguras[0].gameObject.tag != standingMoguras[1].gameObject.tag)
        {
            // そうでなければ立ちフラグをfalseにし、立ちモグラ確認配列も再び空に
            MoguraStanderScript moguraStanderScript0 = standingMoguras[0].GetComponent<MoguraStanderScript>();
            moguraStanderScript0.isStanding = false;
            standingMoguras[0] = null;

            MoguraStanderScript moguraStanderScript1 = standingMoguras[1].GetComponent<MoguraStanderScript>();
            moguraStanderScript1.isStanding = false;
            standingMoguras[1] = null;
        }
    }

    //=============================================================================================
    void ToResult()
    {
        SceneManager.LoadScene("ResultScene");
    }

}
