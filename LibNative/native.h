#ifndef NATIVE_H
#define NATIVE_H

/******************************************************

	The main header for LibNative library.

	All the exported functions are declared here.

******************************************************/

#include "SizedDoubleArray.h"

// Progress reporter function type
typedef void ProgressReporter(float progress, double processing_data);

// Exported functions
extern "C" double DoProcessSimple(double source_data);
extern "C" double DoProcessWithCallback(double source_data, ProgressReporter* callback);

extern "C" SizedDoubleArray AllocateArray(unsigned int size);
extern "C" bool FreeArray(SizedDoubleArray array);

#endif
