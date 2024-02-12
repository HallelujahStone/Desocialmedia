using Desocialmedia.ScriptableObject;
using TMPro;
using UnityEditor;

namespace Desocialmedia
{
    [CustomEditor(typeof(CustomText))]
    public class CustomTextEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CustomText script = (CustomText)target;

            EditorGUI.BeginChangeCheck();
            
            script.Text = EditorGUILayout.TextField("Text", script.Text);
            script.FontSizeType = (FontSizeType) EditorGUILayout.EnumPopup("Font Size Data", script.FontSizeType);
            script.UIColorType = (UIColorType) EditorGUILayout.EnumPopup("UI Color  Type", script.UIColorType);
            script.alignment = (TextAlignmentOptions) EditorGUILayout.EnumPopup("Alignment", script.alignment);
            script.fontStyle = (FontStyles) EditorGUILayout.EnumPopup("FontStyle", script.fontStyle);

            if (EditorGUI.EndChangeCheck())
            {
                script.LoadFields();
                script.UpdateCustomText();
                EditorUtility.SetDirty(script);
            }
        }
    }
    
}
