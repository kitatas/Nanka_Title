using RollingBall.Common;
using UnityEngine;

namespace RollingBall.Title
{
    public sealed class RankLoader : MonoBehaviour
    {
        [SerializeField] private RankButton[] rankButtons = default;

        private void Start()
        {
            var clearData = ES3.Load(Const.CLEAR_RANK_KEY, GetDefaultClearData());
            for (int i = 0; i < rankButtons.Length; i++)
            {
                if (i > 0)
                {
                    if (clearData[i - 1] > 0 && clearData[i] == -1)
                    {
                        clearData[i] = 0;
                    }
                }

                rankButtons[i].ShowRank(clearData[i]);
            }
        }

        public void ResetClearRank()
        {
            var clearData = GetDefaultClearData();
            ES3.Save(Const.CLEAR_RANK_KEY, clearData);

            for (int i = 0; i < rankButtons.Length; i++)
            {
                rankButtons[i].ShowRank(clearData[i]);
            }
        }

        private static int[] GetDefaultClearData()
        {
            var clearData = new int[Const.MAX_STAGE_COUNT];
            clearData[0] = 0;
            for (int i = 1; i < clearData.Length; i++)
            {
                clearData[i] = -1;
            }

            return clearData;
        }
    }
}