using System.Collections.Generic;
using UnityEngine;

public class MoguraInstantiateScript : MonoBehaviour
{
    [Header("配置するモグラ")]
    [SerializeField] GameObject[] moguras;

    [Header("配置するポイント")]
    [SerializeField] Transform[] points;

    [Header("x座標ずらし機能用 基本位置から最大でこの数のぶんだけズレる")]
    [SerializeField] float difference_x;
    [Header("y座標ずらし機能用 基本位置から最大でこの数のぶんだけズレる")]
    [SerializeField] float difference_y;

    // ランダム生成した数を格納する配列
    int[] randomNumbers = new int[24];

    // 1～24までの数を格納するリスト　モグラランダム配置時の要素数指定に使用
    List<int> List = new List<int>();

    //=============================================================================================
    void Start()
    {
        // リストに0から23までの値を追加
        for (int i = 0; i < 24; ++i)
        {
            List.Add(i);
        }

        // 乱数生成
        Rundom();

        // 生成した乱数を使用してモグラを配置
        InstantiateMogura();
    }

    //=============================================================================================
    void Update()
    {
        
    }

    //=============================================================================================
    // 乱数生成
    void Rundom()
    {
        // リスト内のナンバーを使用して重複のない乱数を生成し、配列に格納
        for (int i = 0; List.Count > 0; ++i)
        {
            // リスト内のナンバーをランダムに指定するため、乱数を生成
            int index = Random.Range(0, List.Count);

            // 生成した乱数を使ってリスト内の数を指定、指定した数を配列0番から順に格納
            randomNumbers[i] = List[index];

            // 使用したナンバーはリストから除外　ナンバーが減るごとにリストの長さも短くなる
            List.RemoveAt(index);
        }
    }

    //=============================================================================================
    // モグラ配置
    void InstantiateMogura()
    {
        // ポイント上にモグラを配置
        for (int i = 0; i < 24; ++i)
        {
            // 指定したポイントにモグラを配置、どのモグラを配置するかはランダムに決定
            Instantiate(
                moguras[randomNumbers[i]],
                new Vector3(
                    points[i].transform.position.x + Random.Range(-difference_x, difference_x),
                    points[i].transform.position.y + Random.Range(-difference_x, difference_y),
                    0
                    ),
                transform.rotation
                    );
        }
    }
}
