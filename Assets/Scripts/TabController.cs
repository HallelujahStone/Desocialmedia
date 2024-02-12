using Abstract;
using Desocialmedia.ScriptableObject;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Desocialmedia
{
    public class TabController : AbstractCustomButton
    {
        [SerializeField] private UIColorType activeColorType;
        
        private bool _isActive;
        private UIColorScriptableObject _uIColorScriptableObject;
        private Color _inactiveColor;
        private Color _activeColor;

        private void Awake()
        {
            _uIColorScriptableObject = Resources.Load<UIColorScriptableObject>("UIColorScriptableObject");
            _activeColor = _uIColorScriptableObject.GetColor(activeColorType);
            _inactiveColor = animationImage.color;
        }

        private protected override void AbstractOnCustomButtonDown(PointerEventData eventData) { }
        private protected override void AbstractOnCustomButtonClick(PointerEventData eventData) { }

        private protected override void AbstractOnCustomButtonUp(PointerEventData eventData)
        {
            _isActive = !_isActive;
            animationImage.color = _isActive ? _activeColor : _inactiveColor;
        }
    }
}