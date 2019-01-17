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
            var originalTransform = playerData as Transform;
            if (originalTransform != null && sourceTransform != null)
            {
                originalTransform.position = sourceTransform.position;
                originalTransform.rotation = sourceTransform.rotation;
            }

        }
    }
}