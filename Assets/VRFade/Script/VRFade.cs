using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTJ
{
    [ExecuteInEditMode]
    public class VRFade : MonoBehaviour
    {
        static VRFade _instance;

        private MeshRenderer meshRenderer;
        private MaterialPropertyBlock propertyBlock;
        private int colorPropId;

        public static VRFade Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            Initialzie();
        }
        private void Initialzie()
        {
            _instance = this;
            meshRenderer = this.GetComponent<MeshRenderer>();
            propertyBlock = new MaterialPropertyBlock();
            colorPropId = Shader.PropertyToID("_Color");
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (_instance == null)
            {
                Initialzie();
            }
        }
#endif
        public void SetColor(Color color)
        {
            meshRenderer.enabled = (color.a > float.Epsilon);
            propertyBlock.SetColor(colorPropId, color);
            meshRenderer.SetPropertyBlock(propertyBlock);
        }
    
        private void OnDestroy()
        {
            _instance = null;
        }
        // Use this for initialization
    }
}
