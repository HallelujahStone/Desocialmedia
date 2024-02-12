using System;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Abstract
{
    public abstract class AbstractCustomButton : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
    {
        private readonly Subject<PointerEventData> _onPointerDown = new Subject<PointerEventData>();
        private readonly Subject<PointerEventData> _onPointerClick = new Subject<PointerEventData>();
        private readonly Subject<PointerEventData> _onPointerUp = new Subject<PointerEventData>();

        public IObservable<PointerEventData> OnCustomButtonDown() => _onPointerDown;
        public IObservable<PointerEventData> OnCustomButtonClick() => _onPointerClick;
        public IObservable<PointerEventData> OnCustomButtonUp() => _onPointerUp;

        [SerializeField] private protected Image animationImage;
        [SerializeField] private protected float reduceColorValueOnPressed = 0.3f;

        private protected virtual void Init() { }
        private protected abstract void AbstractOnCustomButtonDown(PointerEventData eventData);
        private protected abstract void AbstractOnCustomButtonClick(PointerEventData eventData);
        private protected abstract void AbstractOnCustomButtonUp(PointerEventData eventData);
        private Color _firstColor;
        private Color _darkenedColor;
        
        private const float SCALE_RATIO = 0.9f;
        private const float SCALE_DURATION = 0.15f;

        private void Start()
        {
            Init();
            
            _firstColor = animationImage.color;
            _darkenedColor = ReduceValue(_firstColor, reduceColorValueOnPressed);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _onPointerDown.OnNext(eventData);
            animationImage.color = _darkenedColor;
            transform.DOScale(SCALE_RATIO, SCALE_DURATION)
                .SetEase(Ease.InOutSine)
                .SetLink(gameObject);
            
            AbstractOnCustomButtonDown(eventData);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _onPointerClick.OnNext(eventData);
            AbstractOnCustomButtonClick(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _onPointerUp.OnNext(eventData);
            animationImage.color = _firstColor;
            transform.DOScale(1, SCALE_DURATION)
                .SetEase(Ease.InOutSine)
                .SetLink(gameObject);
            
            AbstractOnCustomButtonUp(eventData);
        }
        
        private Color ReduceValue(Color color, float reduction)
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);
            v *= (1 - reduction);
            return Color.HSVToRGB(h, s, v);
        }
    }
}