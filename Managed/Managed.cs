using System;

class Managed
{
	static void managed_progress_reporter(float progress, double processing_data)
	{
		Console.WriteLine("[Managed] Progress: " + (progress * 100).ToString("0") + 
		                  ", Processing data: " + processing_data.ToString("0.000"));
	}

	static int Main()
	{
		double source_data = 123;	// Emulating some source data
		
		// Long operation and callback
		
		Console.WriteLine("[Managed] Test 1: Launching DoProcessSimple()");
		double result = LibNative.Wrapper.DoProcessSimple(source_data);
		Console.WriteLine("[Managed] DoProcessSimple returned: " + result.ToString("0.000"));
		
		Console.WriteLine("[Managed] Test 2: Launching DoProcessWithCallback()");
		result = LibNative.Wrapper.DoProcessWithCallback(source_data, managed_progress_reporter);
		Console.WriteLine("[Managed] DoProcessWithCallback returned: " + result.ToString("0.000"));
	
		// Arrays
	
		Console.WriteLine("[Managed] Test 3: Launching AllocateArray()");
		LibNative.Wrapper.SizedDoubleArray array = LibNative.Wrapper.AllocateArray(1024 * 1024);
		Console.WriteLine("[Managed] Taking array to managed memory...");
		double[] taken_array = LibNative.Wrapper.TakeArray(array);
		Console.WriteLine("[Managed] The array length is " + taken_array.Length);
		taken_array[3] = 123.45;
		Console.WriteLine("[Managed] Giving array back to unmanaged memory...");
		LibNative.Wrapper.GiveArray(array, taken_array);
		
		Console.WriteLine("[Managed] Launching FreeArray()");
		LibNative.Wrapper.FreeArray(array);
		
		return 0;
	}
}
