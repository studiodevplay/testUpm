using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUnityDataSendBridge
{
    /// <summary>
	/// /test111
	/// </summary>
    private static MUnityDataSendBridge _instance = new MUnityDataSendBridge();
    private readonly AndroidJavaObject _mUnityDataReceiver;

    private MUnityDataSendBridge()
    {
        if (Application.platform != RuntimePlatform.Android)
            return;
        _mUnityDataReceiver = new AndroidJavaObject("com.mbridge.msdk.unity.MUnityDataReceiver");
    }

    public static MUnityDataSendBridge getInstance()
    {
        return _instance;
    }


    public void initialize(string appID, string appKey)
    {
        try
        {
            Debug.Log("appID:"+ appID+" appKey:"+ appKey);
            AndroidJavaObject applicationContext = getApplicationContext();
            if (applicationContext != null)
            {
                _mUnityDataReceiver.CallStatic("initialize", applicationContext, appID, appKey);
            }
            else
            {
                Debug.LogError("Failed to get application context.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Exception occurred while calling trackAdRevenue: " + ex.Message);
        }
    }

    public void trackAdRevenue(string trackAdJsonStr,string extraJsonStr)
    {
        
        try
        {
            Debug.Log("unity trackAdJsonStr:" + trackAdJsonStr + " extraJsonStr:" + extraJsonStr);
            AndroidJavaObject applicationContext = getApplicationContext();
            if (applicationContext != null)
            {
                _mUnityDataReceiver.CallStatic("trackAdRevenue", applicationContext, trackAdJsonStr, extraJsonStr);
            }
            else
            {
                Debug.LogError("Failed to get application context.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Exception occurred while calling trackAdRevenue: " + ex.Message);
        }
    }

    public void trackAdRevenue(string trackAdJsonStr)
    {
        trackAdRevenue(trackAdJsonStr,"");
    }


    private AndroidJavaObject getApplicationContext()
    {
        try
        {
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    return jo.Call<AndroidJavaObject>("getApplicationContext");
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Exception occurred while getting application context: " + ex.Message);
        }
        return null;
    }
}