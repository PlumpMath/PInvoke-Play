#ifndef SIZEDDOUBLEARRAY_H
#define SIZEDDOUBLEARRAY_H

/******************************************************

	Header for the SizedDoubleArray class

	This class describes a double array of known size,
	which has been allocated dynamically on the heap.

******************************************************/

#include <map>

using namespace std;

//
//  SizedDoubleArray
//

struct SizedDoubleArray
{
public:
	// Array content
	double* Data;
	
	// Array length
	unsigned int Size;

public:
	bool IsValid();
	SizedDoubleArray() {}
	SizedDoubleArray(unsigned int size);
	void Free();
};

// The global allocation map. 
// All allocated array descriptors are stored here.
static map<double*, SizedDoubleArray> allocatedData;

#endif
