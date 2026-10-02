using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManagerScript : MonoBehaviour
{
    public static BGMManagerScript Instance { get; private set; }

    [Header("BGM")]
    [SerializeField] AudioClip titleBgmClip;
    [SerializeField] AudioClip gameBgmClip;
    [SerializeField] AudioClip resultBgmClip;

    [Header("効果音")]
    [SerializeField] AudioClip clickButtonClip;
    [SerializeField] AudioClip moleClickClip;
    [SerializeField] AudioClip missClip;
    [SerializeField] AudioClip trueClickClip;

    AudioSource bgmSource;
    AudioSource seSource;

    void Awake()
    {
        // シングルトン化（重複防止）
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        AudioSource[] sources = GetComponents<AudioSource>();

        bgmSource = sources.Length > 0 ? sources[0] : gameObject.AddComponent<AudioSource>();
        seSource = sources.Length > 1 ? sources[1] : gameObject.AddComponent<AudioSource>();

        bgmSource.loop = true;
        bgmSource.spatialBlend = 0f; // 2Dサウンド化

        seSource.loop = false;
        seSource.volume = 1.0f;       // 音量100%
        seSource.spatialBlend = 0f;  // 2Dサウンド化
    }

    void Start()
    {
        CheckAndPlaySceneBGM(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        CheckAndPlaySceneBGM(SceneManager.GetActiveScene().name);
    }

    private void CheckAndPlaySceneBGM(string sceneName)
    {
        if (sceneName == "TitleScene") PlayTitleBGM();
        else if (sceneName == "GameScene") PlayGameBGM();
        else if (sceneName == "ResultScene") PlayResultBGM();
    }

    public void PlayTitleBGM()
    {
        if (titleBgmClip == null || bgmSource.clip == titleBgmClip) return;
        bgmSource.clip = titleBgmClip;
        bgmSource.Play();
    }

    public void PlayGameBGM()
    {
        if (gameBgmClip == null || bgmSource.clip == gameBgmClip) return;
        bgmSource.clip = gameBgmClip;
        bgmSource.Play();
    }

    public void PlayResultBGM()
    {
        if (resultBgmClip == null || bgmSource.clip == resultBgmClip) return;
        bgmSource.clip = resultBgmClip;
        bgmSource.Play();
    }

    public void PlayClickButtonSound() => PlaySE(clickButtonClip, "ボタンがクリックされました。");
    public void PlayMoleClickSound() => PlaySE(moleClickClip, "モグラの穴をたたきました。");
    public void PlayMissSound() => PlaySE(missClip, "間違えました。");
    public void PlayTrueClickSound() => PlaySE(trueClickClip, "正解です。");

    private void PlaySE(AudioClip clip, string logMessage)
    {
        if (clip == null)
        {
            Debug.LogWarning("AudioClipがInspectorでセットされていません！");
            return;
        }
        seSource.PlayOneShot(clip);
        Debug.Log(logMessage);
    }
}
