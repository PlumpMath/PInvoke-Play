#include <unistd.h>
#include <stdio.h>

#include "native.h"

//
//  Native progress reporter. 
//  Just prints out the current progress and current data-in-processing
//
void native_progress_reporter(float progress, double processing_data)
{
	printf("[Native] Progress: %.0f%%, Processing Data: %.3f\n", progress * 100, processing_data);
	fflush(stdout);
}

//
//  Exported function. Launches processing with the default native progress reporter
//
double DoProcessSimple(double source_data)
{
	return DoProcessWithCallback(source_data, &native_progress_reporter);
}

//
//  Exported function. Launches processing with a custom progress reporter callback
//
double DoProcessWithCallback(double source_data, ProgressReporter* callback)
{
	double processing_data = source_data;
	for (int i = 0; i < 5; i++)
	{
		// Emulating a long work
		sleep(1);
		// Working actually
		processing_data /= 2;

		// Launching the callback
		(*callback)(((float)(i + 1)) / 5, processing_data);
	}
	return processing_data;
}

SizedDoubleArray AllocateArray(unsigned int size)
{
	return SizedDoubleArray(size);
}


bool FreeArray(SizedDoubleArray array)
{
	array.Free();
}
