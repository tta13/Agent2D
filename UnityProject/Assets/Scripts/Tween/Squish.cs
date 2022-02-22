using DG.Tweening;
using UnityEngine;

public class Squish : MonoBehaviour
{
    [SerializeField] private Vector2 scalePercentage;
    [SerializeField] private float duration = 2f;

    private float _duration
    {
        get
        {
            return duration;
        }
    }
    private Vector3 _originalScale = Vector3.zero;

    private void OnEnable()
    {
        _originalScale = transform.localScale;
        DoSquish();
    }

    private void OnDisable()
    {
        if(_originalScale != Vector3.zero)
        {
            transform.localScale = _originalScale;
        }
    }

    private void DoSquish()
    {
        var durationOfEachTween = _duration / 2f;
        var initialScale = new Vector3(transform.localScale.x * (1f + scalePercentage.x),
            transform.localScale.y * (1f - scalePercentage.y),
            transform.localScale.z);
        var endScale = new Vector3(transform.localScale.x * (1f - scalePercentage.x),
            transform.localScale.y * (1f + scalePercentage.y),
            transform.localScale.z);
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(initialScale, durationOfEachTween))
            .Append(transform.DOScale(endScale, durationOfEachTween))
            .Append(transform.DOScale(_originalScale, .1f))
            .SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        transform?.DOKill();
    }
}
