using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace UTJ
{
    [Serializable]
    public class VRFaderClip : PlayableAsset, ITimelineClipAsset
    {
        public VRFaderBehaviour template = new VRFaderBehaviour();

#if UNITY_EDITOR
        [NonSerialized]
        private TimelineClip clipBind;
        public void SetTimelineClip(TimelineClip clip)
        {
            clipBind = clip;
            ApplyClipDisplayName();
        }
        public void ApplyClipDisplayName()
        {
            string displayName = "";
            if (template.FadeType == VRFaderBehaviour.EFadeInOut.FadeIn)
            {
                displayName = "FadeIn";
            }
            else
            {
                displayName = "FadeOut";
            }
            if (clipBind != null)
            {
                clipBind.displayName = displayName;
            }
        }

#endif


        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<VRFaderBehaviour>.Create(graph, template);
            return playable;
        }
    }
}