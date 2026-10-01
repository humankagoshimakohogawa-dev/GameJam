using UnityEngine;

public class MoguraInstantiateScript : MonoBehaviour
{
    [Header("配置するモグラ")]
    [SerializeField] GameObject[] moguras;

    [Header("配置するポイント")]
    [SerializeField] Transform[] points;

    //=============================================================================================
    void Start()
    {
        
    }

    //=============================================================================================
    void Update()
    {
        // ポイント上にモグラを配置
        for (int i = 0; i < 24; ++i)
        {
            if (moguras[i] == null) { break; }

            Instantiate(moguras[i], new Vector3(points[i].transform.position.x, points[i].transform.position.y, 0), transform.rotation);

            moguras[i] = null;
        }
    }
}
