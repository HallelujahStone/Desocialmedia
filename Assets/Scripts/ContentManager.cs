
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Desocialmedia
{
    public class ContentManager : SingletonMonoBehaviour<ContentManager>
    {
        [SerializeField] private CustomText[] contentHeaderTexts;
        [SerializeField] private string[] todayContentHeaderTexts;
        [SerializeField] private string[] totalContentHeaderTexts;
        [SerializeField] private SpentTimeController[] spentTimes;

        private int _screenTimeSecond;
        
        protected void Awake() 
        {
            SetSubscribe();
        }

        private void SetSubscribe()
        {
            TabManager.Instance.OnTabClick()
                .Subscribe(ChangeContent)
                .AddTo(gameObject);
            
#if UNITY_ANDROID
            PermissionManager.Instance.OnSpentTimeGotten()
                .Subscribe(SetSpentTime)
                .AddTo(gameObject);
#endif
        }

        private void ChangeContent(int index)
        {
            string[] texts;
            int[] times;
            switch (index)
            {
                case 0:
                    texts = todayContentHeaderTexts;
                    times = new[] {99*60, 138*60, 21*60};
                    SetText();
                    break;
                case 1:
                    texts = totalContentHeaderTexts;
                    times = new[] {_screenTimeSecond, 3255*60, 1043*60};
                    SetText();
                    break;
                case 2:
                    break;
            }

            void SetText()
            {
                for (int i = 0; i < texts.Length; i++)
                {
                    contentHeaderTexts[i].Text = texts[i];
                    contentHeaderTexts[i].UpdateCustomText();
                }

                for (int j = 0; j < times.Length; j++)
                {
                    spentTimes[j].SetSpentTime(times[j]);
                    spentTimes[j].UpdateAsObservable();
                }
            }
        }

        private void SetSpentTime(long spentTime)
        {
            spentTime /= 1000;
            _screenTimeSecond = (int)spentTime;
        }
    }
}