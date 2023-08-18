//
//  UnityInternalCallMintegral.m
//  Unity-iPhone
//
//  Created by iMengqing on 2023/8/9.
//

#import <Foundation/Foundation.h>
#import <MTGSDK/MTGTrackAdRevenue.h>
#import<MTGSDK/MTGSDK.h>
#if defined(__cplusplus)
extern "C" {
#endif



static NSString *const kMTG_Mediation_Admob = @"Admob";
static NSString *const kMTG_Mediation_IronSource = @"IronSource";
static NSString *const kMTG_Mediation_Max = @"Max";




static NSString *const kMTG_mediationName = @"mediationName";
static NSString *const kMTG_attributionPlatformName = @"attributionPlatformName";
static NSString *const kMTG_attributionUserID = @"attributionUserID";
static NSString *const kMTG_mBridge_Version=@"mBridge_Version";
static NSString *const kMTG_u_p_v=@"u_p_v";

///admob key
static NSString *const kMTG_Admob_adType = @"adType";
static NSString *const kMTG_Admob_adUnitID = @"adUnitID";
static NSString *const kMTG_Admob_loadedadapterResponseInfo = @"loadedadapterResponseInfo";
static NSString *const kMTG_Admob_AdapterClassName = @"AdapterClassName";
static NSString *const kMTG_Admob_AdUnitMapping = @"AdUnitMapping";
///admob  adValue key
static NSString *const kMTG_Admob_adValue = @"adValue";
static NSString *const kMTG_Admob_adValue_Precision = @"Precision";
static NSString *const kMTG_Admob_adValue_CurrencyCode = @"CurrencyCode";
static NSString *const kMTG_Admob_adValue_Value = @"Value";


//ironsource key
static NSString *const kMTG_IronSource_irinstanceid = @"irinstanceid";
static NSString *const kMTG_IronSource_ironSourceImpressionData = @"ironSourceImpressionData";
static NSString *const kMTG_IronSource_adUnit = @"adUnit";
static NSString *const kMTG_IronSource_adNetwork = @"adNetwork";
static NSString *const kMTG_IronSource_precision = @"precision";
static NSString *const kMTG_IronSource_revenue = @"revenue";
static NSString *const kMTG_IronSource_instanceId = @"instanceId";

//max key
static NSString *const kMTG_max_adInfo = @"adInfo";
static NSString *const kMTG_max_AdUnitIdentifier = @"AdUnitIdentifier";
static NSString *const kMTG_max_AdFormat = @"AdFormat";
static NSString *const kMTG_max_NetworkName = @"NetworkName";
static NSString *const kMTG_max_RevenuePrecision = @"RevenuePrecision";
static NSString *const kMTG_max_Revenue = @"Revenue";
static NSString *const kMTG_max_WaterfallInfo = @"WaterfallInfo";
static NSString *const kMTG_max_NetworkResponses = @"NetworkResponses";
static NSString *const kMTG_max_AdLoadState = @"AdLoadState";
static NSString *const kMTG_max_Credentials = @"Credentials";
static NSString *const kMTG_max_IsBidding = @"IsBidding";
static NSString *const kMTG_max_DspName = @"DspName";





static bool mtg_check_nsstring(NSString *arg) {
    if (!arg || ![arg isKindOfClass:[NSString class]]
        || ![arg respondsToSelector:@selector(length)] || arg.length == 0) {
        return false;
    }
    return true;
}

static bool mtg_check_dict(NSDictionary *arg) {
    if (!arg) {
        return false;
    }
    if (![arg isKindOfClass:NSDictionary.class]) {
        return false;
    }
    
    if (arg.allKeys.count == 0) {
        return false;
    }

    return true;
}

    void _initialize(char * appID,char * appKey){
        NSString*appid=[[NSString alloc] initWithUTF8String:appID];
        NSString*appkey=[[NSString alloc] initWithUTF8String:appKey];
        if(mtg_check_nsstring(appid)&&mtg_check_nsstring(appkey))
        [[MTGSDK sharedInstance] setAppID:appid ApiKey:appkey];
    
    }

    //游戏层访问SDK的接口
    void _trackAdRevenueWithAdRevenueModel(char * jsonpara)
    {
      
        if (jsonpara == NULL)
            return;
        NSString*string=[[NSString alloc] initWithUTF8String:jsonpara];
        
        NSData *jsonData = [string dataUsingEncoding:NSUTF8StringEncoding];
        NSDictionary *dics = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingMutableContainers error:NULL];
     
        
        MTGTrackAdRevenueCustomModel *customModel = [[MTGTrackAdRevenueCustomModel alloc]init];
       
        customModel.attributionPlatformName =  dics[kMTG_attributionPlatformName];
        customModel.attributionUserID = dics[kMTG_attributionUserID];
        NSString *mediationName = dics[kMTG_mediationName];
        if(mtg_check_nsstring(mediationName))
        {
            customModel.mediationName = mediationName;
           
            if ([mediationName isEqualToString:kMTG_Mediation_Admob]) {
                customModel.adType = dics[kMTG_Admob_adType];//@"Banner";
                customModel.mediationUnitId = dics[kMTG_Admob_adUnitID];
                NSDictionary *adapterResponseInfo = dics[kMTG_Admob_loadedadapterResponseInfo];
                if(mtg_check_dict(adapterResponseInfo)){
                  
                    customModel.adNetworkName =adapterResponseInfo[kMTG_Admob_AdapterClassName]; //self.bannerView.responseInfo.loadedAdNetworkResponseInfo.adNetworkClassName;
                    customModel.adNetworkUnitInfo =adapterResponseInfo[kMTG_Admob_AdUnitMapping]; //self.bannerView.responseInfo.loadedAdNetworkResponseInfo.adUnitMapping;
                    
                    customModel.allInfo = adapterResponseInfo;
                }
                 NSDictionary *adValue = dics[kMTG_Admob_adValue];
                if(mtg_check_dict(adValue)){
                  
                    customModel.precision = adValue[kMTG_Admob_adValue_Precision];//[NSString stringWithFormat:@"%ld",(long)value.precision];
                    customModel.currency = adValue[kMTG_Admob_adValue_CurrencyCode];//value.currencyCode;
                    customModel.revenue = @([adValue[kMTG_Admob_adValue_Value] doubleValue]);//value.value;
                }
                
                customModel.dspName = @"";
               
            }else if([mediationName isEqualToString:kMTG_Mediation_IronSource]){
// -----是不是instanceid
                customModel.mediationUnitId = dics[kMTG_IronSource_irinstanceid];
//  ------只能从ironSourceImpressionData中取
              
                NSDictionary *ironSourceImpressionData = dics[kMTG_IronSource_ironSourceImpressionData];
                if(mtg_check_dict(ironSourceImpressionData)){
                   
                    customModel.adType = ironSourceImpressionData[kMTG_IronSource_adUnit];//@"Banner";
                    customModel.adNetworkName =ironSourceImpressionData[kMTG_IronSource_adNetwork];// impressionData.ad_network;
                    customModel.precision  =ironSourceImpressionData[kMTG_IronSource_precision];//impressionData.precision;
                    customModel.revenue = ironSourceImpressionData[kMTG_IronSource_revenue];//impressionData.revenue;
                    customModel.adNetworkUnitInfo = @{@"instanceId":ironSourceImpressionData[kMTG_IronSource_instanceId]};
                    customModel.allInfo =ironSourceImpressionData;
                    customModel.dspName = @"";
                }
            }
            else if([mediationName isEqualToString:kMTG_Mediation_Max]){
                NSDictionary *adInfo = dics[kMTG_max_adInfo];
                if(mtg_check_dict(adInfo)){
                    customModel.mediationUnitId = adInfo[kMTG_max_AdUnitIdentifier];//ad.adUnitIdentifier;
                    customModel.adType = adInfo[kMTG_max_AdFormat];//ad.format.label;
                    customModel.adNetworkName = adInfo[kMTG_max_NetworkName];//ad.networkName;
                    customModel.precision = adInfo[kMTG_max_RevenuePrecision];//ad.revenuePrecision;
                    
                    customModel.revenue = @([adInfo[kMTG_max_Revenue] doubleValue]);//adInfo[@"Revenue"]

                    NSDictionary *WaterfallInfo =  adInfo[kMTG_max_WaterfallInfo];
                    if(mtg_check_dict(WaterfallInfo)){
                      
                        NSDictionary *NetworkResponses =  WaterfallInfo[@"NetworkResponses"];
                        if(mtg_check_dict(NetworkResponses)){
                       
                            if([NetworkResponses[kMTG_max_AdLoadState] isEqual:@1]){
                              
                    customModel.adNetworkUnitInfo = NetworkResponses[kMTG_max_Credentials];//info.credentials;
                                
                        
                    customModel.isBidding = [NetworkResponses[kMTG_max_IsBidding]boolValue] ;//info.isBidding;
                            }
                        }
                            
                    }

                    customModel.allInfo =adInfo;
                    customModel.dspName = adInfo[kMTG_max_DspName];//ad.DSPName;
                    
                }
              
                
            }
        }
       // customModel.dspId =@"";
      
        if(mtg_check_nsstring(dics[kMTG_mBridge_Version])){
            customModel.extraData = @{kMTG_u_p_v:dics[kMTG_mBridge_Version]};
        }
      
        [MTGTrackAdRevenue trackAdRevenueWithAdRevenueModel:customModel];

       
   
    
        
        
    }
    
}
