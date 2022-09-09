using System.Collections;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public void Slowmotion()
    {
        StartCoroutine(SlowmotionCorutine());
    }

    IEnumerator SlowmotionCorutine()
    {
        var sec = 2f;
        var duration = 0.4f;
        var targetScaleTime = 0.1f;
        var currentTime = 1f;

        for (float t = 0f; t < duration; t += Time.unscaledDeltaTime)
        {
            Time.timeScale = Mathf.Lerp(currentTime, targetScaleTime, t / duration);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            yield return null;
        }

        Time.timeScale = targetScaleTime;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        for (float t = 0f; t < sec; t += Time.unscaledDeltaTime)
            yield return null;

        for (float t = 0f; t < duration; t += Time.unscaledDeltaTime)
        {
            Time.timeScale = Mathf.Lerp(targetScaleTime, 1f, t / duration);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            yield return null;
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
