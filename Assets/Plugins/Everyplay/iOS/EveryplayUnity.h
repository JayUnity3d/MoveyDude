#import <Foundation/Foundation.h>
#import <Everyplay/Everyplay.h>

#if UNITY_VERSION >= 430
#import "AppDelegateListener.h"
@interface EveryplayUnity : NSObject<EveryplayDelegate, AppDelegateListener> {
#else
@interface EveryplayUnity : NSObject<EveryplayDelegate> {
#endif
    BOOL displayLinkPaused;
    UIInterfaceOrientation currentOrientation;
}

+ (EveryplayUnity *)sharedInstance;

@end

// This isn't defined by default for Unity generated Xcode projects
//#define DEBUG 1

// Conditional debug
#if DEBUG
#define EveryplayLog(fmt, ...) NSLog((@"[#%.3d] %s " fmt), __LINE__, __PRETTY_FUNCTION__,##__VA_ARGS__)
#else
#define EveryplayLog(...)
#endif

// EveryplayALog always displays output regardless of the DEBUG setting
#ifndef EveryplayALog
#define EveryplayALog(fmt, ...)   NSLog((@"[#%.3d] %s " fmt), __LINE__, __PRETTY_FUNCTION__,##__VA_ARGS__)
#endif

#define ELOG EveryplayLog(@"")
