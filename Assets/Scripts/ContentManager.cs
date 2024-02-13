
using UnityEngine;
using UniRx;

namespace Desocialmedia
{
    public class ContentManager : SingletonMonoBehaviour<ContentManager>
    {
        [SerializeField] private CustomText[] contentHeaderTexts;
        [SerializeField] private string[] todayContentHeaderTexts;
        [SerializeField] private string[] totalContentHeaderTexts;
        [SerializeField] private SpentTimeController[] spentTimes;

        private void Start()
        {
            SetSubscribe();
            
            // NOTE: 動作確認用
            // iOSNativePlugin nativePlugin = new iOSNativePlugin();
            // nativePlugin.ShowMessage("Hello World!");
            
        }

        private void SetSubscribe()
        {
            TabManager.Instance.OnTabClick()
                .Subscribe(ChangeContent)
                .AddTo(gameObject);
            
#if UNITY_ANDROID
            PermissionManager.Instance.OnSpentTimeGotten()
                .Subscribe(spentTimes[0].SetSpentTime)
                .AddTo(gameObject);
#endif
        }

        private void ChangeContent(int index)
        {
            string[] texts;
            switch (index)
            {
                case 0:
                    texts = todayContentHeaderTexts;
                    SetText();
                    
                    break;
                case 1:
                    texts = totalContentHeaderTexts;
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
            }
        }
    }
}