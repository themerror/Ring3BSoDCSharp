# Ring3BSoDCSharp
This is a ring3 program that causes BSoD.
It uses the following two functions: 

`RtlAdjustPrivilege` and `NtRaiseHardError`.

They are defined as follows:
```csharp
[DllImport("ntdll.dll")]
private static extern uint RtlAdjustPrivilege(
    int Privilege,
    bool bEnablePrivilege,
    bool IsThreadPrivilege,
    out bool PreviousValue
);
```
```csharp
[DllImport("ntdll.dll")]
private static extern uint NtRaiseHardError(
    uint ErrorStatus,
    NumberOfParameters,
    uint UnicodeStringParameterMask,
    IntPtr Parameters,
    uint ValidResponseOption,
    out uint Response
);
```
For more information, please see: [Analysis of the variety of ways and principles of R3 blue screen](https://www.anquanke.com/post/id/254815#:~:text=%C2%A0-,0x02%20Ring3%E8%93%9D%E5%B1%8F%E7%9A%84%E6%96%B9%E5%BC%8F,-%E7%AE%80%E5%8D%95%E7%9A%84%E5%8F%AF%E4%BB%A5 "Analysis of the variety of ways and principles of R3 blue screen") (In Chinese).
