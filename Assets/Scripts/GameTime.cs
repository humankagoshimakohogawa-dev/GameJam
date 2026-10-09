using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [Header("ŽžŠÔ•\Ž¦")]
    [SerializeField]
    private TMP_Text timeText;

    private float elapsedTime = 0f;

    private void Start()
    {
        elapsedTime = 0f;

        UpdateTimeText();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        if (timeText == null)
        {
            return;
        }

        timeText.text = "TIME : " + elapsedTime.ToString("F2");
    }
}
