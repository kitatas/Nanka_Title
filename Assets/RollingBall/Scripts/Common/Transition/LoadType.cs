﻿namespace RollingBall.Common.Transition
{
    public enum LoadType
    {
        Direct,    // タイトルシーンから直接
        Reload,    // ゲームシーンでのリロード
        Next,      // ゲームクリ後の次ステージ
        Title,     // ゲームシーンからタイトル
    }
}