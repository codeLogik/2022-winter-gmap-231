using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyInBoard : MonoBehaviour
{
    // Variables for setting up from editor
    [SerializeField] private RectTransform _targetRectTransform;
    [SerializeField] private float _endScale = 1f;
    [SerializeField] private float _endPosition = 0f;

    private Sequence _sequence;

    public void FlyIn()
    {
        // Use DOTween to move the rect transform in to the canvas, then scale it after that is complete.
        _targetRectTransform.DOLocalMoveX(endValue: _endPosition, duration: 2f, snapping: false)
            .OnComplete(Scale);
    }

    private void Scale()
    {
        // Use DOTween to scale the rect transform.
        _targetRectTransform.DOScale(endValue: _endScale, duration: 0.5f);
    }

    // Use a DOTween sequence to have the rect transform fly in, but in a way that is easily reqindable.
    public void SequenceFlyIn()
    {
        // Create a sequence that can be rewinded.
        _sequence = DOTween.Sequence().SetAutoKill(false);

        // Append in the two tweens that we were doing above, but with an elastic ease.
        _sequence.Append(
            _targetRectTransform.DOLocalMoveX(endValue: _endPosition, duration: 2f, snapping: false).SetEase(Ease.InElastic));
        _sequence.Append(_targetRectTransform.DOScale(endValue: _endScale, duration: 0.5f));
    }

    public void Rewind() => _sequence.Rewind();
}
