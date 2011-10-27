#include "native.h"
#include "SizedDoubleArray.h"

#include <map>
using namespace std;

SizedDoubleArray::SizedDoubleArray(unsigned int size)
{
	Data = new double[size];
	Size = size;
	
	allocatedData.insert(
		pair<double*, SizedDoubleArray>(
			Data, *this
		)
	);
}

void SizedDoubleArray::Free()
{
	if (IsValid())
	{
		delete[] Data;
		allocatedData.erase(Data);
	}
}

bool SizedDoubleArray::IsValid()
{
	return allocatedData.find(Data) != allocatedData.end();
}
