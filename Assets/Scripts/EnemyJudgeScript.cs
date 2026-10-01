using UnityEngine;
using UnityEngine.InputSystem;

//public class PairDeleteScript : MonoBehaviour
//{    //１）変数関連
//    public Sprite imgBack; // 裏
//    public Sprite imgFront; // 表
//    public //GameManager gm; //GameManager
//    //public int pairId; // ペアID（同じ番号がペア）

//    //２）準備
//    private SpriteRenderer sr; //画像表示に関する
//    private bool isFront = false;//裏表判定（false=裏, true=表）

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        //３）実行
//        sr = GetComponent<SpriteRenderer>(); //（カードの）画像情報に関する
//                                             // ShowBack(); //最初は裏にセット⇒中身は４へ
//    }
//    // 最初にクリックした敵を記憶しておく変数
//    private GameObject firstClickedObject = null;

//    void Update()
//    {
//        // クリックした瞬間だけ検知
//        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
//        {
//            Vector2 mousePosition = Mouse.current.position.ReadValue();
//            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
//            RaycastHit2D hitSprite = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

//            if (hitSprite.collider != null)
//            {
//                GameObject currentTarget = hitSprite.transform.gameObject;

//                // タグが「Enemy」のオブジェクトを触ったときだけ処理
//                if (currentTarget.CompareTag("Enemy"))
//                {
//                    SelectEnemy(currentTarget);
//                }
//            }
//        }
//    }

////    void SelectEnemy(GameObject enemy)
////    {
////        // まだ1つ目を選択していない場合
////        if (firstClickedObject == null)
////        {
////            firstClickedObject = enemy;
////            Debug.Log("1つ目を選択しました: " + enemy.name);

////            // 【おすすめ】選択中だと分かりやすいように、少し透明にするなどの演出を入れると親切です
////            // enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
////        }
////        // 2つ目を選択した場合
////        else
////        {
////            // 同じオブジェクトを2回クリックした場合は選択をキャンセルする
////            if (firstClickedObject == enemy)
////            {
////                Debug.Log("選択がキャンセルされました");
////                // enemy.GetComponent<SpriteRenderer>().color = Color.white; // 色を元に戻す
////                firstClickedObject = null;
////                return;
////            }

////            // 【条件チェック】2つのオブジェクトの「名前」や「プレハブの元データ」が同じか判定
////            // ※Prefabから生成すると名前に「(Clone)」が付くため、Replaceで消して純粋な名前で比較しています
////            string firstName = firstClickedObject.name.Replace("(Clone)", "");
////            string secondName = enemy.name.Replace("(Clone)", "");

////            if (firstName == secondName)
////            {
////                Debug.Log("2つ揃いました！消去します。");

////                // 両方とも削除する
////                Destroy(firstClickedObject);
////                Destroy(enemy);
////            }
////            else
////            {
////                Debug.Log("違う種類なので揃いませんでした。選択をリセットします。");
////                // firstClickedObject.GetComponent<SpriteRenderer>().color = Color.white; // 色を元に戻す
////            }

////            // 次のペアを見つけるために、記憶をリセット
////            firstClickedObject = null;
////        }
////    }
////}

