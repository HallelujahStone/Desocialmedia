using System;

namespace Desocialmedia
{
    public interface INativePluginCall : IDisposable
    {
        void ShowMessage(string message);
    }
}