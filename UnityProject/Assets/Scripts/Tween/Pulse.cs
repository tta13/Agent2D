using UnityEngine;
using DG.Tweening;

public class Pulse : MonoBehaviour
{
    [SerializeField] private Vector2 goalScale = Vector2.one;
    [SerializeField] private float duration = 2f;

    private void Start()
    {
        DoPulse();
    }

    private void DoPulse()
    {
        var originalScale = transform.localScale;
        var durationOfEachTween = duration / 2f;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(goalScale, durationOfEachTween))
            .Append(transform.DOScale(originalScale, durationOfEachTween))
            .SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        transform?.DOKill();
    }
}
