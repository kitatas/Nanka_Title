﻿using DG.Tweening;
using UnityEngine;
using Zenject;

public class MenuButton : BaseButton
{
    [Inject] private readonly RectTransform _menuObj = default;
    [SerializeField] private GameObject menuImage = null;
    [SerializeField] private bool isActive = default;
    private float _originHeight;

    protected override void Awake()
    {
        base.Awake();

        _originHeight = _menuObj.localPosition.y;
    }

    protected override void OnPush()
    {
        base.OnPush();

        if (isActive)
        {
            menuImage.SetActive(true);

            _menuObj
                .DOLocalMoveY(0f, ConstantList.uiAnimationTime / 2f);
        }
        else
        {
            _menuObj
                .DOLocalMoveY(_originHeight, ConstantList.uiAnimationTime / 2f)
                .OnComplete(() => menuImage.SetActive(false));
        }
    }
}