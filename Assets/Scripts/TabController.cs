using System;
using Abstract;
using Desocialmedia.ScriptableObject;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Desocialmedia
{
    public class TabController : AbstractCustomButton
    {
        private readonly Subject<Unit> _onButtonUp = new Subject<Unit>();
        public IObservable<Unit> OnButtonUp() => _onButtonUp;
        
        [SerializeField] private UIColorType activeColorType;
        
        private UIColorScriptableObject _uIColorScriptableObject;
        private Color _inactiveColor;
        private Color _activeColor;

        private void Awake()
        {
            _uIColorScriptableObject = Resources.Load<UIColorScriptableObject>("UIColorScriptableObject");
            _inactiveColor = animationImage.color;
            _activeColor = _uIColorScriptableObject.GetColor(activeColorType);
        }

        private protected override void AbstractOnCustomButtonDown(PointerEventData eventData) { }
        private protected override void AbstractOnCustomButtonClick(PointerEventData eventData) { }

        private protected override void AbstractOnCustomButtonUp(PointerEventData eventData)
        {
            SetActiveTab();
            _onButtonUp.OnNext(Unit.Default);
        }

        public void SetActiveTab()
        {
            animationImage.color = _activeColor;
        }
        
        public void SetInactiveTab()
        {
            animationImage.color = _inactiveColor;
        }
        
    }
}