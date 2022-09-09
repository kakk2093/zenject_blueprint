using UnityEngine;
using UnityEngine.UI;

public class FrameRateCounter : MonoBehaviour
{
    [Header("References")]
    [SerializeField, Tooltip("The text field displaying the frame rate.")]
    private Text _textField;

    [Header("Frame Rate")]
    [SerializeField, Tooltip("The delay in seconds between updates of the displayed frame rate.")]
    private float _pollingTime = 0.5f;

    private float _time;
    private int _frameCount;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        // Update time.
        _time += Time.deltaTime;

        // Count this frame.
        _frameCount++;

        if (_time >= _pollingTime)
        {
            // Update frame rate.
            int frameRate = Mathf.RoundToInt((float)_frameCount / _time);
            _textField.text = frameRate.ToString();

            // Reset time and frame frame count.
            _time -= _pollingTime;
            _frameCount = 0;
        }
    }
}
