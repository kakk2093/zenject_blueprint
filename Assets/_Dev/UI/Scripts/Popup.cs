using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [Header("Open/Close Settings")]
    [SerializeField] private GameObject _body;
    [SerializeField] private float _openDelay;
    [SerializeField] private float _closeDelay;
    [SerializeField] private float _closeAnimDuration;
    [SerializeField] private Animator[] _animators;
    [SerializeField] private Button _closePopupButton;

    private const string AnimatorOpenPopupBoolKey = "IsOpen";

    private Coroutine _openCloseCoroutine;

    private void Awake()
    {
        _body.SetActive(false);
        _closePopupButton?.onClick.AddListener(OnClosePopupButtonClick);
    }

    public void OpenPopup()
    {

        gameObject.SetActive(true);

        if (!gameObject.activeInHierarchy)
            return;

        if (_openCloseCoroutine != null)
            StopCoroutine(_openCloseCoroutine);
        _openCloseCoroutine = StartCoroutine(OpenCoroutine());
    }

    public void ClosePopup()
    {

        if (!gameObject.activeInHierarchy)
            return;

        if (_openCloseCoroutine != null)
            StopCoroutine(_openCloseCoroutine);
        _openCloseCoroutine = StartCoroutine(CloseCoroutine());
    }

    private void OnClosePopupButtonClick()
    {
        Debug.Log("button clic");
        ClosePopup();
    }

    private IEnumerator CloseCoroutine()
    {
        yield return new WaitForSeconds(_closeDelay);

        foreach (var animator in _animators)
        {
            if (animator.gameObject.activeInHierarchy)
                animator.SetBool(AnimatorOpenPopupBoolKey, false);
        }

        yield return new WaitForSeconds(_closeAnimDuration);
        _body.SetActive(false);
        gameObject.SetActive(false);
    }

    private IEnumerator OpenCoroutine()
    {
        yield return new WaitForSeconds(_openDelay);

        _body.SetActive(true);
        foreach (var animator in _animators)
        {
            if (animator.gameObject.activeInHierarchy)
                animator.SetBool(AnimatorOpenPopupBoolKey, true);
        }
    }
}