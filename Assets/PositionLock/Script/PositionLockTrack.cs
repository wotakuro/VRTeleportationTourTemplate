using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UTJ
{
    [TrackColor(0.875f, 0.5944853f, 0.1737132f)]
    [TrackClipType(typeof(PositionLockClip))]
    [TrackBindingType(typeof(Transform))]
    public class PositionLockTrack : TrackAsset
    {
        public override void OnEnable()
        {
            base.OnEnable();
        }
        protected override Playable CreatePlayable(PlayableGraph graph, GameObject go, TimelineClip clip)
        {
            var playable = base.CreatePlayable(graph, go, clip);
#if UNITY_EDITOR
            PositionLockClip clipAsset = clip.asset as PositionLockClip;
            if (clipAsset != null)
            {
                clipAsset.SetTimelineClip(clip);
            }
#endif
            return playable;
        }

        /*
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            Transform trackBinding = director.GetGenericBinding(this) as Transform;
            if (trackBinding != null)
            {
                var serializedObject = new UnityEditor.SerializedObject(trackBinding);
                var iterator = serializedObject.GetIterator();
                while (iterator.NextVisible(true))
                {
                    if (iterator.hasVisibleChildren)
                        continue;

                    driver.AddFromName<Transform>(trackBinding.gameObject, iterator.propertyPath);
                }
            }
#endif
            base.GatherProperties(director, driver);
        }
        */

    }
}