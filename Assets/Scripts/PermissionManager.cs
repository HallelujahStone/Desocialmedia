using System;
using UniRx;
using System.Collections;

#if UNITY_ANDROID
using UnityEngine;
using UnityEngine.Android;
#endif

namespace Desocialmedia
{
    public class PermissionManager : SingletonMonoBehaviour<PermissionManager>
    {
        private readonly Subject<long> _onSpentTimeGotten = new Subject<long>();
        public IObservable<long> OnSpentTimeGotten() => _onSpentTimeGotten;
            
        private bool _isRequesting;
        
        private IEnumerator Start()
        {
            Debug.Log("PermissionManager Start");
            
#if UNITY_ANDROID
            Debug.Log("Tried to get the screen time");
            
            AndroidNativePlugin nativePlugin = new AndroidNativePlugin();
            _onSpentTimeGotten.OnNext(nativePlugin.GetUsageStats());
            
            // string permission = "android.permission.PACKAGE_USAGE_STATS";
            // if (Permission.HasUserAuthorizedPermission(permission))
            // {
            //     yield return null;
            //     Debug.Log("Tried to get the screen time");
            //     
            //     AndroidNativePlugin nativePlugin = new AndroidNativePlugin();
            //     _onSpentTimeGotten.OnNext(nativePlugin.GetUsageStats());
            // }
            // else
            // {
            //     Debug.Log("Required the permission");
            //     
            //     yield return RequestUserPermission(permission);
            // }
#endif
            
            yield break;
        }
        
#if UNITY_ANDROID
        private IEnumerator RequestUserPermission(string permission)
        {
            _isRequesting = true;
            Permission.RequestUserPermission(permission);
            // Androidでは「今後表示しない」をチェックされた状態だとダイアログは表示されないが、フォーカスイベントは通常通り発生する模様。
            // したがってタイムアウト処理は本来必要ないが、万が一の保険のために一応やっとく。

            // アプリフォーカスが戻るまで待機する
            float timeElapsed = 0;
            while (_isRequesting)
            {
                if (timeElapsed > 0.5f)
                {
                    _isRequesting = false;
                    yield break;
                }
                timeElapsed += Time.deltaTime;

                yield return null;
            }
            yield break;
        }
#endif
        
    }
}