using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace UTJ
{
    [Serializable]
    public class PositionLockBehaviour : PlayableBehaviour
    {
        [NonSerialized]
        public Transform sourceTransform;


        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if(sourceTransform == null) { return; }
            var originGmo = playerData as GameObject;
            if( originGmo == null) { return; }
            var originalTransform = originGmo.transform as Transform;

            originalTransform.position = sourceTransform.position;
            originalTransform.rotation = sourceTransform.rotation;

        }
    }
}