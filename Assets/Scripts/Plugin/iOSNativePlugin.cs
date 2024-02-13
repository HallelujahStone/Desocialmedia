#if !UNITY_EDITOR && UNITY_IOS
using System.Runtime.InteropServices;

namespace Desocialmedia
{
    public class iOSNativePlugin : INativePluginCall
    {
        [DllImport("__Internal", EntryPoint = "showMessage")]
        static extern void iOSShowMessage(string message);
     
        public void ShowMessage(string message)
        {
            iOSShowMessage(message);
        }

        public void Dispose()
        {
            // 今回のサンプルでは必要なし
        }
    }
}
#endif
