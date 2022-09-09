using System.Collections;
using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private float _scaleTime;

    private void ScaleObject()
    {
        StartCoroutine(ScaleCorutine(_scaleTime));
    }

    private IEnumerator ScaleCorutine(float time)
    {
        Vector3 originalScale = _model.transform.localScale;
        Vector3 desireScale = new Vector3(1.0f, 1.0f, 1.0f);

        float currentTime = 0.0f;

        yield return new WaitForSeconds(0.2f);

        while (currentTime <= time)
        {
            _model.transform.localScale = Vector3.Lerp(originalScale, desireScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }


    }
}
