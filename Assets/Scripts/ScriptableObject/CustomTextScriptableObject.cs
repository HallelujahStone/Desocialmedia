using TMPro;
using UnityEngine;

namespace Desocialmedia.ScriptableObject
{
    public enum FontSizeType
    {
        Small,
        Medium,
        Large,
        
        ExtraSmall,
        
    }
    
    [CreateAssetMenu(fileName = "CustomTextScriptableObject", menuName = "ScriptableObject/CustomTextScriptableObject", order = 1)]
    public class CustomTextScriptableObject : UnityEngine.ScriptableObject
    {
        public TMP_FontAsset FontAsset;
        
        [System.Serializable]
        public struct TextSizeEntry
        {
            public FontSizeType type;
            public int size;
        }
        public TextSizeEntry[] Entries;

        public int GetFontSize(FontSizeType fontSizeType)
        {
            foreach (var entry in Entries)
            {
                if (entry.type == fontSizeType)
                    return entry.size;
            }

            return 0;
        }
    }
}