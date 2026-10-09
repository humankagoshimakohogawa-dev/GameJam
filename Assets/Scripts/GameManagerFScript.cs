using System.Collections.Generic;
using UnityEngine;

public class GameManagerFScript : MonoBehaviour
{
    [Header("ゲームクリア条件がそろっているか否か")]
    public bool isGameCleare = false;

    [Header("シーン上のモグラの数を数えるためのリスト")]
    public List<int> mogurasList = new List<int>();

    [Header("シーン上のモグラの数を格納する変数")]
    public int mogurasCount = 0;

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
    }

    //=============================================================================================
    void CountMoguras()
    {
        // 数が0になったらゲームクリア判定をtrueに
        if (mogurasCount == 0)
        {
            isGameCleare = true;
        }
        
    }

    //=============================================================================================
    void KillMogura()
    {
        // 立っているモグラがお互いに同じタグを持っていたら
        if (standingMoguras[0].gameObject.tag == standingMoguras[1].gameObject.tag)
        {
            // モグラのスクリプトを参照し、立ちフラグはfalseに、撃退フラグはtrueに
            MoguraStanderScript moguraStanderScript0 = standingMoguras[0].GetComponent<MoguraStanderScript>();
            moguraStanderScript0.isStanding = false;
            moguraStanderScript0.isKilling = true;
            // 立ちモグラ確認配列内のモグラのオブジェクトを1秒待ってから破棄
            Destroy(standingMoguras[0].gameObject, 1);
            // モグラの数を-1
            --mogurasCount;

            MoguraStanderScript moguraStanderScript1 = standingMoguras[1].GetComponent<MoguraStanderScript>();
            moguraStanderScript1.isStanding = false;
            moguraStanderScript1.isKilling = true;
            Destroy(standingMoguras[1].gameObject, 1);
            --mogurasCount;

        }
        else if (standingMoguras[0].gameObject.tag != standingMoguras[1].gameObject.tag)
        {
            // そうでなければフラグをfalseにし、立ちモグラ確認配列も再び空に
            MoguraStanderScript moguraStanderScript0 = standingMoguras[0].GetComponent<MoguraStanderScript>();
            moguraStanderScript0.isStanding = false;
            moguraStanderScript0.isMiss = true;
            standingMoguras[0] = null;

            MoguraStanderScript moguraStanderScript1 = standingMoguras[1].GetComponent<MoguraStanderScript>();
            moguraStanderScript1.isStanding = false;
            moguraStanderScript1.isMiss = true;
            standingMoguras[1] = null;
        }
    }
}
