using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Moveable target;

    private void OnEnable()
    {
        MoveWithMover();
        //MoveWithDOTween();
    }

    private void MoveWithMover()
    {
        target.MoveTo(new Vector3(10, 0, 0),
            () => target.MoveTo(new Vector3(0, 5, 0),
                () => target.MoveTo(new Vector3(1, 1, 1))));
    }

    private void MoveWithDOTween()
    {
        target.transform.DOMove(new Vector3(10, 10, 0), 2f)
            .OnComplete(() => target.transform.DOMoveY(0, 1f)
                .OnComplete(() => target.transform.DOMove(Vector3.zero, 2f)));
    }
}
