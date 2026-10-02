
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManagerScript : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioClip titleBgmClip;
    [SerializeField] AudioClip gameBgmClip;
    [SerializeField] AudioClip resultBgmClip;

    [Header("効果音")]
    [SerializeField] AudioClip clickButtonClip;
    [SerializeField] AudioClip moleClickClip;
    [SerializeField] AudioClip missClip;
    [SerializeField] AudioClip trueClickClip;

    // BGMを再生するAudioSource
    AudioSource bgmSource;

    // 効果音を再生するAudioSource
    AudioSource seSource;


    //=============================================================================================
    void Awake()
    {
        // シーンが切り替わってもこのオブジェクトを破棄しない
        DontDestroyOnLoad(this.gameObject);

        // AudioSourceを取得
        AudioSource[] sources = GetComponents<AudioSource>();

        // 1つ目のAudioSourceをBGM用にする
        bgmSource = sources.Length > 0
            ? sources[0]
            : gameObject.AddComponent<AudioSource>();

        // 2つ目のAudioSourceを効果音用にする
        seSource = sources.Length > 1
            ? sources[1]
            : gameObject.AddComponent<AudioSource>();

        // BGMはループする
        bgmSource.loop = true;

        // 効果音はループしない
        seSource.loop = false;
    }


    //=============================================================================================
    void Start()
    {
        // 現在のシーンがタイトルならタイトルBGMを再生
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            PlayTitleBGM();
        }
    }


    //=============================================================================================
    void Update()
    {
        // 現在のシーンがゲーム本編ならゲームBGMに切り替える
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            PlayGameBGM();
        }

        // 現在のシーンがリザルトならリザルトBGMに切り替える
        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            PlayResultBGM();
        }
    }


    //=============================================================================================
    // タイトル用BGM再生
    public void PlayTitleBGM()
    {
        // BGMが設定されていなければ何もしない
        if (titleBgmClip == null)
        {
            return;
        }

        // 既にタイトルBGMなら何もしない
        if (bgmSource.clip == titleBgmClip)
        {
            return;
        }

        bgmSource.clip = titleBgmClip;
        bgmSource.Play();

        Debug.Log("タイトルBGM再生");
    }


    //=============================================================================================
    // ゲームシーン用BGM再生
    public void PlayGameBGM()
    {
        // BGMが設定されていなければ何もしない
        if (gameBgmClip == null)
        {
            return;
        }

        // 既にゲームBGMなら何もしない
        if (bgmSource.clip == gameBgmClip)
        {
            return;
        }

        bgmSource.clip = gameBgmClip;
        bgmSource.Play();

        Debug.Log("ゲームBGM再生");
    }


    //=============================================================================================
    // リザルトシーン用BGM再生
    public void PlayResultBGM()
    {
        // BGMが設定されていなければ何もしない
        if (resultBgmClip == null)
        {
            return;
        }

        // 既にリザルトBGMなら何もしない
        if (bgmSource.clip == resultBgmClip)
        {
            return;
        }

        bgmSource.clip = resultBgmClip;
        bgmSource.Play();

        Debug.Log("リザルトBGM再生");
    }


    //=============================================================================================
    // ボタンを押したときの効果音
    public void PlayClickButtonSound()
    {
        // 効果音が設定されていなければ何もしない
        if (clickButtonClip == null)
        {
            return;
        }

        seSource.PlayOneShot(clickButtonClip);

        Debug.Log("ボタンがクリックされました。");
    }


    //=============================================================================================
    // モグラを押したときの効果音
    public void PlayMoleClickSound()
    {
        // 効果音が設定されていなければ何もしない
        if (moleClickClip == null)
        {
            return;
        }

        seSource.PlayOneShot(moleClickClip);

        Debug.Log("モグラの穴をたたきました。");
    }


    //=============================================================================================
    // 不正解の効果音
    public void PlayMissSound()
    {
        // 効果音が設定されていなければ何もしない
        if (missClip == null)
        {
            return;
        }

        seSource.PlayOneShot(missClip);

        Debug.Log("間違えました。");
    }


    //=============================================================================================
    // 正解の効果音
    public void PlayTrueClickSound()
    {
        // 効果音が設定されていなければ何もしない
        if (trueClickClip == null)
        {
            return;
        }

        seSource.PlayOneShot(trueClickClip);

        Debug.Log("正解です。");
    }
}

