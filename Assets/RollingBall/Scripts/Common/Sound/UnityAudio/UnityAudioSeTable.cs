﻿using RollingBall.Common.Sound.SE;
using UnityEngine;

namespace RollingBall.Common.Sound.UnityAudio
{
    [CreateAssetMenu(fileName = "SeTable", menuName = "DataTable/SeTable")]
    public sealed class UnityAudioSeTable : ScriptableObject
    {
        [SerializeField] private AudioClip decisionClip = default;
        [SerializeField] private AudioClip cancelClip = default;
        [SerializeField] private AudioClip hitClip = default;
        [SerializeField] private AudioClip clearClip = default;

        public AudioClip[] GetSeList()
        {
            var seCount = System.Enum.GetValues(typeof(SeType)).Length;
            var seList = new AudioClip[seCount];
            seList[(int) SeType.Decision] = decisionClip;
            seList[(int) SeType.Cancel] = cancelClip;
            seList[(int) SeType.Hit] = hitClip;
            seList[(int) SeType.Clear] = clearClip;

            return seList;
        }
    }
}