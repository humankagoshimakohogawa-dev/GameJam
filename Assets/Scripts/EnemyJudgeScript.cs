using UnityEngine;
using UnityEngine.InputSystem;

//public class EnemyJudgeScript : MonoBehaviour
//{
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
//using UnityEngine;
//// Input Systemを使用するために追加
//using UnityEngine.InputSystem; 

public class TouchDeleteScript : MonoBehaviour
{
    GameObject clickedGameObject;

    void Start()
    {
        // スタート時の初期化処理（必要であれば）
    }

    void Update()
    {
        // 【新】左クリック（または画面タップ）が押されているか判定
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            // 【新】現在のマウス位置（スクリーン座標）を取得
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            // カメラからマウス位置に向けてRay（光線）を作成
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // 2Dのレイキャストを飛ばす
            RaycastHit2D hitSprite = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            // 何かの2Dコライダーに当たったか判定
            if (hitSprite.collider != null)
            {
                clickedGameObject = hitSprite.transform.gameObject;

                // タグが「Enemy」なら削除する
                if (clickedGameObject.CompareTag("Enemy"))
                {
                    Destroy(clickedGameObject);
                }
            }
        }
    }
}
