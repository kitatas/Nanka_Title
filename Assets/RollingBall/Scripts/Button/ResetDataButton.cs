﻿public sealed class ResetDataButton : BaseButton
{
    protected override void OnPush(ButtonType buttonType)
    {
        for (int i = 0; i < 10; i++)
        {
            var key = ConstantList.GetKeyName(i);
            ES3.Save<int>(key, 0);
        }

        var rankLoaders = FindObjectsOfType<RankLoader>();
        foreach (var rankLoader in rankLoaders)
        {
            rankLoader.LoadRank();
        }
    }
}