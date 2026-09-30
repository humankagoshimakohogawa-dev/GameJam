using UnityEngine;

public class RandomScript : MonoBehaviour
{
    [Header("モグラを配置できる位置")]
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    [SerializeField] Transform point3;
    [SerializeField] Transform point4;
    [SerializeField] Transform point5;
    [SerializeField] Transform point6;
    [SerializeField] Transform point7;
    [SerializeField] Transform point8;
    [SerializeField] Transform point9;
    [SerializeField] Transform point10;
    [SerializeField] Transform point11;
    [SerializeField] Transform point12;
    [SerializeField] Transform point13;
    [SerializeField] Transform point14;
    [SerializeField] Transform point15;
    [SerializeField] Transform point16;
    [SerializeField] Transform point17;
    [SerializeField] Transform point18;
    [SerializeField] Transform point19;
    [SerializeField] Transform point20;
    [SerializeField] Transform point21;
    [SerializeField] Transform point22;
    [SerializeField] Transform point23;
    [SerializeField] Transform point24;

    //=============================================================================================
    void Start()
    {

    }

    //=============================================================================================
    void Update()
    {
        // 配置できるポイントを配列で管理
        Transform[] points = new Transform[25];
        points[1] = point1;
        points[2] = point2;
        points[3] = point3;
        points[4] = point4;
        points[5] = point5;
        points[6] = point6;
        points[7] = point7;
        points[8] = point8;
        points[9] = point9;
        points[10] = point10;
        points[11] = point11;
        points[12] = point12;
        points[13] = point13;
        points[14] = point14;
        points[15] = point15;
        points[16] = point16;
        points[17] = point17;
        points[18] = point18;
        points[19] = point19;
        points[20] = point20;
        points[21] = point21;
        points[22] = point22;
        points[23] = point23;
        points[24] = point24;

        // ポイントがゲーム上に存在しているならループ
        while (points != null)
        {
            // どのポイントに配置するかをランダムに決定
            int point_Number = Random.Range(1, 25);

            // もし、既に破棄されているポイントが割り当てられたら、ループを抜けて再抽選
            if (points[point_Number] == null) { break; }

            // 決まった位置にモグラを配置
            // pos = points[point_Number];

            // 使用したポイントは破棄
            Destroy(points[point_Number]);
        }

    }
}
