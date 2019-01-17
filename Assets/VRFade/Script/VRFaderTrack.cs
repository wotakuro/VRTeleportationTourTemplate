using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UTJ
{
    [TrackColor(0.875f, 0.5944853f, 0.1737132f)]
    [TrackClipType(typeof(VRFaderClip))]
    public class VRFaderTrack : TrackAsset
    {
        public override void OnEnable()
        {
            base.OnEnable();
        }
        protected override Playable CreatePlayable(PlayableGraph graph, GameObject go, TimelineClip clip)
        {
            var playable = base.CreatePlayable(graph, go, clip);
#if UNITY_EDITOR
            VRFaderClip clipAsset = clip.asset as VRFaderClip;
            if (clipAsset != null)
            {
                clipAsset.SetTimelineClip(clip);
            }
#endif
            return playable;
        }
        protected override void UpdateDuration()
        {
            base.UpdateDuration();
        }
    }
}