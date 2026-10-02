using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManagerScript : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioClip titleBgmClip;
    [SerializeField] AudioClip gameBgmClip;
    [SerializeField] AudioClip resultBgmClip;
    [SerializeField] AudioClip clickButtonClip;
    [SerializeField] AudioClip moleClickClip;
    [SerializeField] AudioClip missClip;
    [SerializeField] AudioClip trueClickClip;

    AudioSource bgmSource;

    //=============================================================================================
    void Awake()
    {
        // シーンが切り替わってもこのオブジェクトを破棄しない
        DontDestroyOnLoad(this.gameObject);

        // AudioSource型の配列 sourcesを宣言
        // AudioSourceの内容を取得してsourcesに入れる
        AudioSource[] sources = GetComponents<AudioSource>();

        // 三項演算子
        // 変数名 = 条件式 ? trueだった場合の値 : falseだった場合の値

        // bgmSourceに、sourcesの長さ(Length)が0より大きいならsourcesの0番を与える  そうでなければゲームオブジェクトにAudioSourceのコンポーネントを追加
        bgmSource = sources.Length > 0 ? sources[0] : gameObject.AddComponent<AudioSource>();

        // bgmのループ再生をtrueに
        bgmSource.loop = true;

    }

    //=============================================================================================
    void Start()
    {
        // 現在のシーンがタイトルならタイトル用BGMを再生
        if (SceneManager.GetActiveScene().name == "TitleScene")
        { PlayTitleBGM(); }

    }

    //=============================================================================================
    void Update()
    {
        // 現在のシーンがゲーム本編なら再生するBGMをゲーム本編用に切り替え
        if (SceneManager.GetActiveScene().name == "GameScene")
        { PlayGameBGM(); }

        // 現在のシーンがリザルトなら再生するBGMをリザルト用に切り替え
        if (SceneManager.GetActiveScene().name == "ResultScene")
        { PlayResultBGM(); }
    }

    //=======================================================================================================================
    // タイトル用BGM再生
    public void PlayTitleBGM()
    {
        // titleBgmClipに何も格納されていなかったら処理を実行しない
        if (titleBgmClip == null) { return; }

        bgmSource.clip = titleBgmClip;

        bgmSource.Play();

        Debug.Log("タイトルBGM再生");
    }

    //=======================================================================================================================
    // ゲームシーン用BGM再生
    public void PlayGameBGM()
    {
        // titleBgmClipに何も格納されていない、または既にゲーム用bgmが格納されているなら処理を実行しない
        if (gameBgmClip == null || bgmSource.clip == gameBgmClip) { return; }

        bgmSource.clip = gameBgmClip;

        bgmSource.Play();

        Debug.Log("ゲームBGM再生");
    }

    //=======================================================================================================================
    // リザルトシーン用BGM再生
    public void PlayResultBGM()
    {
        // resultBgmClipに何も格納されていない、または既にリザルト用bgmが格納されているなら処理を実行しない
        if (resultBgmClip == null || bgmSource.clip == resultBgmClip) { return; }

        bgmSource.clip = resultBgmClip;

        bgmSource.Play();

        Debug.Log("リザルトBGM再生");
    }

    public void PlayClickButtonBGM()
    {
        // resultBgmClipに何も格納されていない、または既にリザルト用bgmが格納されているなら処理を実行しない
        if (clickButtonClip == null || bgmSource.clip == clickButtonClip) { return; }

        bgmSource.clip = clickButtonClip;

        bgmSource.Play();

        Debug.Log("ボタンがクリックされました。");
    }

    public void PlayMoleClickBGM()
    {
        // resultBgmClipに何も格納されていない、または既にリザルト用bgmが格納されているなら処理を実行しない
        if (moleClickClip == null || bgmSource.clip == moleClickClip) { return; }

        bgmSource.clip = moleClickClip;

        bgmSource.Play();

        Debug.Log("モグラの穴をたたきました。");
    }
    public void PlayMissBGM()
    {
        // resultBgmClipに何も格納されていない、または既にリザルト用bgmが格納されているなら処理を実行しない
        if (missClip == null || bgmSource.clip == missClip) { return; }

        bgmSource.clip = missClip;

        bgmSource.Play();

        Debug.Log("間違えました。");
    }

    public void PlayTrueClickBGM()
    {
        // resultBgmClipに何も格納されていない、または既にリザルト用bgmが格納されているなら処理を実行しない
        if (trueClickClip == null || bgmSource.clip == trueClickClip) { return; }

        bgmSource.clip = trueClickClip;

        bgmSource.Play();

        Debug.Log("正解です。");
    }
}
