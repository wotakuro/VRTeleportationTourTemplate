using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace UTJ
{
    [Serializable]
    public class PositionLockClip : PlayableAsset, ITimelineClipAsset
    {
        private PositionLockBehaviour template = new PositionLockBehaviour();
        [SerializeField] public ExposedReference<GameObject> sourceGameObject;

#if UNITY_EDITOR
        [NonSerialized]
        private TimelineClip clipBind;
        public void SetTimelineClip(TimelineClip clip)
        {
            clipBind = clip;
        }
        public void ApplyClipDisplayName(string str)
        {
            if (clipBind != null)
            {
                clipBind.displayName = "PositionLock:" +str;
            }
        }

#endif


        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            GameObject sourceObject = sourceGameObject.Resolve(graph.GetResolver());
            var playable = ScriptPlayable<PositionLockBehaviour>.Create(graph, template);
            if (sourceObject != null)
            {
                playable.GetBehaviour().sourceTransform = sourceObject.transform;
            }

#if UNITY_EDITOR
            if (sourceObject != null)
            {
                ApplyClipDisplayName(sourceObject.name);
            }
            else
            {
                ApplyClipDisplayName("None");
            }
#endif
            return playable;
        }
    }
}