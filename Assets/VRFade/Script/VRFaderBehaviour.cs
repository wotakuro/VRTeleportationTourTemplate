using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace UTJ
{
    [Serializable]
    public class VRFaderBehaviour : PlayableBehaviour
    {
        public enum EFadeInOut
        {
            FadeIn,
            FadeOut
        }

        public Color color = Color.black;
        public EFadeInOut FadeType = EFadeInOut.FadeIn;


        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
        }
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);

            Color tmpColor = color;
            if (FadeType == EFadeInOut.FadeIn)
            {
                tmpColor.a = 1.0f - (float)(playable.GetTime() / playable.GetDuration());
            }
            else { 
                tmpColor.a = (float)(playable.GetTime() / playable.GetDuration());
            }
            tmpColor.a *= color.a;
            if (VRFade.Instance != null)
            {
                VRFade.Instance.SetColor(tmpColor);
            }
        }
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            base.OnBehaviourPause(playable, info);

            Color tmpColor = color;
            if (FadeType == EFadeInOut.FadeIn)
            {
                tmpColor.a = 0.0f;
                if (VRFade.Instance != null)
                {
                    VRFade.Instance.SetColor(tmpColor);
                }
            }
        }
    }
}