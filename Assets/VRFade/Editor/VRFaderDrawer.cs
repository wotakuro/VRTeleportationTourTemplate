using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace UTJ
{
    [CustomPropertyDrawer(typeof(VRFaderBehaviour))]
    public class VRFaderDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int fieldCount = 2;
            return fieldCount * EditorGUIUtility.singleLineHeight;
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty colorProp = property.FindPropertyRelative("color");
            Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(singleFieldRect, colorProp);

            SerializedProperty fadeInOutProp = property.FindPropertyRelative("FadeType");
            Rect fadetype = new Rect(position.x, position.y + singleFieldRect.height, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(fadetype, fadeInOutProp);

        }
    }
}
