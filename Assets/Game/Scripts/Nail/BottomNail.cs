using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using DG.Tweening;
using Ring;
using UnityEngine;

public class BottomNail : MonoBehaviour
{
    public NailManager nailManager;
    [ReadOnly] public float upPosition;
    [ReadOnly] public float downPosition;

    private void Start()
    {
        upPosition = transform.localPosition.y + Settings.NailBottom_MoveUp;
        downPosition = transform.localPosition.y;
        nailManager.onMove += MoveObject;
    }

    private void MoveObject()
    {
        transform.DOKill();

        transform.DOLocalMoveY(nailManager.nailController.stateNail == StateNail.Up ? upPosition : downPosition,
            Settings.Nail_TimeMoveToHead);
    }
}
