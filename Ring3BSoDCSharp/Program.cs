using System.Runtime.InteropServices;

namespace Ring3BsoDCSharp
{
	public class Program
	{
		[DllImport("ntdll.dll")]
		private static extern uint RtlAdjustPrivilege(
			int Privilege,
			bool bEnablePrivilege,
			bool IsThreadPrivilege,
			out bool PreviousValue
		);

		[DllImport("ntdll.dll")]
		private static extern uint NtRaiseHardError(
			uint ErrorStatus,
			uint NumberOfParameters,
			uint UnicodeStringParameterMask,
			IntPtr Parameters,
			uint ValidResponseOption,
			out uint Response
		);

		private static uint STATUS_ASSERTION_FAILURE = 0xC0000420;

		private static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.Write("Enter the stop code(eg. 0xC0000420):");
			bool isValid = uint.TryParse(Console.ReadLine(), out uint errorCode);
			Console.WriteLine("Adjusting privileges");
			RtlAdjustPrivilege(19, true, false, out bool previousValue);
			Console.WriteLine("Triggering BSOD");
			if (!isValid)
				NtRaiseHardError(STATUS_ASSERTION_FAILURE, 0, 0, (IntPtr)0, 6, out uint oul);
			else
				NtRaiseHardError(errorCode, 0, 0, (IntPtr)0, 6, out uint oul);
		}
	}
}