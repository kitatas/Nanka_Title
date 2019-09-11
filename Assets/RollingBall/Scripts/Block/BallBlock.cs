﻿using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BallBlock : BaseBlock
{
    private bool _isMove;

    private void Start()
    {
        _isMove = false;

        this.OnCollisionEnter2DAsObservable()
            .Select(other => other.gameObject.GetComponent<IHittable>())
            .Where(hittable => hittable != null)
            .Subscribe(_ =>
            {
                _isMove = false;
                CorrectPosition();
            });
    }

    public override void Hit(Vector3 moveDirection)
    {
        base.Hit(moveDirection);

        Move(moveDirection);
    }

    private async void Move(Vector3 moveDirection)
    {
        _isMove = true;

        while (_isMove)
        {
            transform.position += 5f * Time.deltaTime * moveDirection;

            await Observable.TimerFrame(0);
        }
    }

    private void CorrectPosition()
    {
        var nextPosition = transform.RoundPosition();

        transform
            .DOMove(nextPosition, ConstantList.correctTime)
            .OnComplete(ActivatePlayerButton);
    }
}