using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using DG.Tweening;
using UnityEngine;

public class NailManager : MonoBehaviour
{
    public NailController nailController;
    public Action onMove;
    public WoodManager woodManager;

    private void Start()
    {
        nailController.upPosition = transform.localPosition.y + Settings.Nail_MoveUp;
        nailController.downPosition = transform.localPosition.y;
    }

    private void OnMouseDown()
    {
        if (nailController.stateNail == StateNail.Down)
        {
            MoveUp();
            return;
        }

        MoveDown();
    }

    #region Move Nail head

    public void MoveUp()
    {
        if (GameManager.Instance.gameController.nailCurrent != null)
        {
            GameManager.Instance.gameController.nailCurrent.MoveDown();
        }

        GameManager.Instance.gameController.nailCurrent = this;
        nailController.stateNail = StateNail.Up;
        GameManager.Instance.gameController.tweenMoveNail = this.nailController.headNail
            .DOLocalMoveY(nailController.upPosition, Settings.Nail_TimeMoveToHead).OnComplete((
                () => { }));
        onMove?.Invoke();
    }

    public void MoveDown()
    {
        nailController.stateNail = StateNail.Down;
        GameManager.Instance.gameController.tweenMoveNail = this.nailController.headNail
            .DOLocalMoveY(nailController.downPosition, Settings.Nail_TimeMoveToHead).OnComplete((
                () => { }));
        onMove?.Invoke();
    }

    #endregion

    #region Move to destination

    public void MoveToDestination(Vector2 Destination)
    {
        GameManager.Instance.UpdateStateGame(StateGame.Move);
        GameManager.Instance.gameController.tweenMoveNail =
            this.nailController.parentNail.DOMove(Destination, Settings.Nail_TimeMoveToDestination).SetEase(Ease.Linear)
                .OnStart((() => { woodManager.woodController.listJoint[0].enabled = false; })).OnComplete((
                    () =>
                    {
                        GameManager.Instance.UpdateStateGame(StateGame.Empty);
                        MoveDown();
                    }));
    }

    #endregion
}
