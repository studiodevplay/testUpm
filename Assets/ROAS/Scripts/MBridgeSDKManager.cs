using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MBridgeSDKManager
{
#if UNITY_IOS || UNITY_IPHONE
    [DllImport("__Internal")]
    private static extern void _initialize(string appid,string appkey);

#endif
    public static void initialize(string appID, string appKey)
    {
#if UNITY_ANDROID
        MUnityDataSendBridge.getInstance().initialize(appID,appKey);
#elif UNITY_IOS || UNITY_IPHONE
        _initialize(appID, appKey);
#endif
    }
}
