using UnityEngine;
using UnityEngine.EventSystems;

public class MoguraStanderScript : MonoBehaviour, IPointerClickHandler
{
    [Header("使用するアニメコントローラー")]
    public Animator moguraAnimator;

    GameObject gameManager;
    GameManagerFScript gameManagerScript;

    // 自身が現在立っているかどうか
    public bool isStanding = false;

    // 自身の撃退が成功したかどうか
    public bool isKilling = false;

    // 自身の撃退が失敗したかどうか
    public bool isMiss = false;

    //=============================================================================================
    void Start()
    {
        // ゲームマネージャーのオブジェクトを取得
        gameManager = GameObject.Find("GameManager");

        // 所得したゲームマネージャーオブジェクトの持つスクリプトを参照して取得
        gameManagerScript = gameManager.GetComponent<GameManagerFScript>();
    }

    //=============================================================================================
    void Update()
    {
        // 自身の状態とアニメの切り替え条件を同期
        moguraAnimator.SetBool("isStanding", isStanding);
        moguraAnimator.SetBool("isKilling", isKilling);
        moguraAnimator.SetBool("isMiss", isMiss);
    }

    //=============================================================================================
    // クリックされたオブジェクトが何か検知
    public void OnPointerClick(PointerEventData eventData)
    {
        // 今自身が立っていないなら
        if(!isStanding)
        {
            // 0番が空いているなら0番へ
            if (gameManagerScript.standingMoguras[0] == null)
            {
                gameManagerScript.standingMoguras[0] = this.gameObject;
                isStanding = true;
                Debug.Log("一匹目格納");
            }
            // 空いていなかったら1番へ
            else if (gameManagerScript.standingMoguras[1] == null)
            {
                gameManagerScript.standingMoguras[1] = this.gameObject;
                isStanding = true;
                Debug.Log("二匹目格納");
            }
            // どちらも空いていなかったら何もしない
            else { return; }
        }
    }

}
