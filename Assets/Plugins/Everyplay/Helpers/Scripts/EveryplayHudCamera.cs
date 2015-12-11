#if (UNITY_ANDROID) && !UNITY_EDITOR
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5)
#define EVERYPLAY_NATIVE_PLUGIN
#endif
#endif

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class EveryplayHudCamera : MonoBehaviour
{
    protected const int EPSR = 0x45505352;

#if EVERYPLAY_NATIVE_PLUGIN && UNITY_ANDROID
    void Awake()
    {
        EveryplayUnityPluginInterfaceInitialize();
    }

#endif

    void OnPreRender()
    {
#if EVERYPLAY_NATIVE_PLUGIN
        GL.IssuePluginEvent(EPSR);
#else
        Everyplay.SnapshotRenderbuffer();
#endif
    }

#if EVERYPLAY_NATIVE_PLUGIN && UNITY_ANDROID
    [DllImport("everyplay")]
    private static extern void EveryplayUnityPluginInterfaceInitialize();
#endif
}
