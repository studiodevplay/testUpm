using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserBuildSettings : MonoBehaviour
{
    private const string MTG_iOS = "Mintegral / iOS Ad Mediation/";
    private const string MTG_Android = "Mintegral / Android Ad Mediation/";
   
    private const string ironsource ="ironSource";
    private const string admob = "AdMob";
    private const string max = "MAX";


    private static bool isiOSorAndroid()
    {
        
        return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
    }
   
   
    private static void ShowTips(string title, string content)
    {
        // 展示提示信息.
        EditorUtility.DisplayDialog(title, content, "OK");
    }

    private static void ShowPlayerTips4notiOS()
    {

#if !(UNITY_IPHONE || UNITY_IOS)
        ShowTips("提示", "当前平台非iOS,请切换为iOS后重试");
#endif
    }
    private static void ShowPlayerTips4notAndroid()
    {
#if !UNITY_ANDROID
        ShowTips("提示", "当前平台非Android,请切换Android平台后重试");

#endif
    }

    [MenuItem(MTG_iOS+ ironsource)]
    public static void iOS_ironsource()
    {
        ShowPlayerTips4notiOS();
#if UNITY_IPHONE || UNITY_IOS
        string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

        Debug.Log("old " + str);
        str = str.Replace(ironsource, null);


        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,
                ironsource + ";" + str);
        Debug.Log("new " + PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS));

#endif
    }

    [MenuItem(MTG_iOS + admob)]
    public static void iOS_admob()
    {
        ShowPlayerTips4notiOS();
#if UNITY_IPHONE || UNITY_IOS
        string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

        Debug.Log("old " + str);
        str = str.Replace(admob, null);

        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,
               admob + ";" + str);
        Debug.Log("new " + PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS));

 

#endif
    }

    [MenuItem(MTG_iOS + max)]
    public static void iOS_max()
    {
        ShowPlayerTips4notiOS();
#if UNITY_IPHONE || UNITY_IOS
        string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

        Debug.Log("old " + str);
        str = str.Replace(max, null);

        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,
               max + ";" + str);
        Debug.Log("new " + PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS));



#endif
    }
    [MenuItem(MTG_Android + ironsource)]
    public static void Android_ironsource()
    {
        ShowPlayerTips4notAndroid();


#if UNITY_ANDROID
        string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
        Debug.Log("old " + str);
        str = str.Replace(ironsource, null);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,
               ironsource + ";" + str);
        Debug.Log("new " + PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android));

#endif
    }

    [MenuItem(MTG_Android + admob)]
    public static void Android_admob()
    {
        ShowPlayerTips4notAndroid();
#if UNITY_ANDROID

        string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

        Debug.Log("old " + str);
        str = str.Replace(admob, null);

        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,
               admob + ";" + str);
        Debug.Log("new " + PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android));

#endif
    }
    [MenuItem(MTG_Android + max)]
    public static void Android_max()
    {
        ShowPlayerTips4notAndroid();
#if UNITY_ANDROID

        string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

        Debug.Log("old " + str);
        str = str.Replace(max, null);

        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,
                max + ";" + str);
        Debug.Log("new " + PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android));

#endif
    }

}
