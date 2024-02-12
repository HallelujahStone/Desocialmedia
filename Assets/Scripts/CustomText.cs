using Desocialmedia.ScriptableObject;
using TMPro;
using UnityEngine;

namespace Desocialmedia
{
    public class CustomText : TextMeshProUGUI
    {
        public FontSizeType FontSizeType;
        public UIColorType UIColorType;
        public string Text;
        
        private CustomTextScriptableObject _customTextScriptableObject;
        private UIColorScriptableObject _uIColorScriptableObject;

        protected override void Awake()
        {
            base.Awake();
            
            LoadFields();
            UpdateCustomText();
        }

        public void LoadFields()
        {
            _customTextScriptableObject = Resources.Load<CustomTextScriptableObject>("CustomTextScriptableObject");
            _uIColorScriptableObject = Resources.Load<UIColorScriptableObject>("UIColorScriptableObject");
        }
        
        public void UpdateCustomText()
        {
            text = Text;
            font = _customTextScriptableObject.FontAsset;

            fontSize = _customTextScriptableObject.GetFontSize(FontSizeType);
            color = _uIColorScriptableObject.GetColor(UIColorType);
        }
    }
}