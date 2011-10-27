using System;
using System.Runtime.InteropServices;

namespace LibNative
{
	public static class Wrapper
	{
		// ***** Test 1 - Long operation, Test 2 - Long operation with callback *****

		public delegate void ProgressReporter(float progress, double processing_data);

		[DllImport("native", CallingConvention = CallingConvention.Cdecl)]
		public static extern double DoProcessSimple(double source_data);

		[DllImport("native", CallingConvention = CallingConvention.Cdecl)]
		public static extern double DoProcessWithCallback
		(
			double source_data,
			[MarshalAs(UnmanagedType.FunctionPtr)] ProgressReporter callback
		);
	
		// ***** Test 3 - Arrays *****
	
		[DllImport("native", CallingConvention = CallingConvention.Cdecl)]
		public static extern SizedDoubleArray AllocateArray(uint size);
	
		[DllImport("native", CallingConvention = CallingConvention.Cdecl)]
		public static extern void FreeArray(SizedDoubleArray array);


		[StructLayout(LayoutKind.Sequential)]
		public struct SizedDoubleArray
		{
			internal IntPtr Data;
			internal uint Size;
		}

		// Helpers

		public static double[] TakeArray(SizedDoubleArray array)
		{
			double[] managed_array = new double[array.Size];
			Marshal.Copy(array.Data, managed_array, 0, (int)array.Size);
			return managed_array;
		}	
		public static void GiveArray(SizedDoubleArray array, double[] managedArray)
		{
			if (managedArray.Length == array.Size)
			{
				Marshal.Copy(managedArray, 0, array.Data, managedArray.Length);
			}
			else
			{
				throw new IndexOutOfRangeException("array size mismatch: managedArray.Length = " + 
				                                   managedArray.Length + ", array.Size = " + array.Size);
			}
		}	
	}
}
