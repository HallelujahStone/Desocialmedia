using UnityEngine;

namespace Desocialmedia.ScriptableObject
{
    public enum UIColorType
    {
        PureWhite,
        Black,
        Gray,
        WhiteGray,
        Blue,
    }
    
    [CreateAssetMenu(fileName = "UIColorScriptableObject", menuName = "ScriptableObject/UIColorScriptableObject", order = 1)]
    public class UIColorScriptableObject : UnityEngine.ScriptableObject
    {
        [System.Serializable]
        public struct UIColorEntry
        {
            public UIColorType Type;
            public Color Color;
        }

        public UIColorEntry[] Entries;

        public Color GetColor(UIColorType uiColorType)
        {
            foreach (var entry in Entries)
            {
                if (entry.Type == uiColorType)
                    return entry.Color;
            }
            
            return Color.black;
        }
    }
}