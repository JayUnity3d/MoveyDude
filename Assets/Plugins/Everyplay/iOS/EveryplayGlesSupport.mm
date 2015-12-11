#define EVERYPLAY_GLES_WRAPPER
#import "EveryplayGlesSupport.h"
#import <Everyplay/Everyplay.h>

#if !defined(EVERYPLAY_CAPTURE_API_VERSION) || EVERYPLAY_CAPTURE_API_VERSION <= 1
#error "Everyplay SDK 1.7.6 or later required"
#endif
