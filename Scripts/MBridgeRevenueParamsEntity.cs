using System.Collections;
using System.Collections.Generic;
#if AdMob
using GoogleMobileAds.Api;
#endif

using UnityEngine;


public class MBridgeRevenueParamsEntity
{

    public const string ATTRIBUTION_PLATFORM_APPSFLYER = "AppsFlyer";
    public const string ATTRIBUTION_PLATFORM_ADJUST = "Adjust";
    public const string ATTRIBUTION_PLATFORM_TENJIN = "Tenjin";
    public const string ATTRIBUTION_PLATFORM_SINGULAR = "Singular";
    public const string ATTRIBUTION_PLATFORM_KOCHAVA = "Kochava";
    public const string ATTRIBUTION_PLATFORM_BRANCH = "Branch";
    public const string ATTRIBUTION_PLATFORM_REYUN = "Reyun";
    public const string ATTRIBUTION_PLATFORM_SOLAR_ENGINE = "SolarEngine";
    public const string ATTRIBUTION_PLATFORM_APP_METRICA = "AppMetrica";
    public const string ATTRIBUTION_PLATFORM_MY_TRACKER = "MyTracker";
    public const string ATTRIBUTION_PLATFORM_ADBRIX = "Adbrix";
    public const string ATTRIBUTION_PLATFORM_APSALAR = "Apsalar";
    public const string ATTRIBUTION_PLATFORM_DATA_EYE = "DataEye";
    public const string ATTRIBUTION_PLATFORM_FOX = "Fox";
    public const string ATTRIBUTION_PLATFORM_TALKING_DATA = "TalkingData";
    public const string ATTRIBUTION_PLATFORM_UMENG = "Umeng";
    public const string ATTRIBUTION_PLATFORM_AIRVRIDGE = "Airbridge";
    public const string ATTRIBUTION_PLATFORM_JUST_TRACK = "JustTrack";

    //第三方归因平台名字，取值有AppsFlyer，Adjust和Tenjin
    public string attributionPlatformName = "";
    //第三方归因平台，用户激活应用时生成的id
    public string attributionPlatformUserId = "";

    #region admob
#if AdMob
    public AdValue adValue = null;
    public ResponseInfo responseInfo = null;
    public string adUnitID = "";
    public admobAdType adType = admobAdType.None;

    public void SetAdmobAdValue(AdValue advalue)
    {
        this.adValue = advalue;
    }

    public void SetAdmobAdType(admobAdType adtype)
    {
        this.adType = adtype;
    }

    public void SetAdmobAdUnitid(string adunitid)
    {
        this.adUnitID = adunitid;
    }

    public void SetAdmobResponseInfo(ResponseInfo responseinfo)
    {
        this.responseInfo = responseinfo;
    }
#endif
    #endregion

    #region max

#if MAX
    public MaxSdkBase.AdInfo AdInfo=null;

    public void SetMaxAdInfo(MaxSdkBase.AdInfo adInfo)
    {
        this.AdInfo = adInfo;
    }
#endif

    #endregion


    #region ironsource

#if ironSource
    public string instanceid="";

    public IronSourceImpressionData ironSourceImpressionData=null;

    public void SetIronSourceInstanceid(string instanceid)
    {
        this.instanceid = instanceid;
    }
    public void SetIronSourceImpressionData( IronSourceImpressionData data)
    {
        this.ironSourceImpressionData = data;
    }
#endif
    #endregion

    public MBridgeRevenueParamsEntity(string attributionPlatformName, string attributionPlatformUserId)
    {
        this.attributionPlatformName = attributionPlatformName;
        this.attributionPlatformUserId = attributionPlatformUserId;
    }

}

public enum admobAdType
{
    // Rewarded|Banner|Interstitial|Native|AppOpen.

    Rewarded,
    Banner,
    Interstitial,
    Native,
    AppOpen,
    None
}
