using UnityEngine;

namespace Desocialmedia
{
    public class AndroidNativePlugin
    {
        public string GetUsageStats()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                using var usageStatsPlugin = new AndroidJavaClass("com.desocialmedia.usagestatslibrary.UsageStatsHelper");
                { 
                    using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                    {
                        var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                        string response = usageStatsPlugin.CallStatic<string>("getUsageStats", currentActivity);
                        Debug.Log($"response {response}");
                    }
                }
            }

            return "";
        }
    }
}