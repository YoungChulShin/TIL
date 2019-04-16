# C#에서 C++ Dll을 읽어와서 처리하는 방법

### C++ 코드
```c++
__declspec(dllexport) int __stdcall fnWin32Project1(Win32Callback callback, int value)
{
    callback(value, L"test is good");
    return 42;
}

typedef void(__stdcall *Win32Callback)(int value1, const wchar_t *text1);
```

### C# 코드
DLL 정보
- Win32Project1.dll

함수 정보
- 리턴: int
- 함수 이름: fnWin32Project1
- 파라미터
   - Win32Callback 콜백 함수
   - int 값
- Win32Callback 함수
   - 리턴: void
   - 파라미터
      - int 값
      - wchar_t 문자열


예제 코드
```c#
// 1. Callback Delegate 설정
//public delegate void Win32Callback(int value1, string text1);
public delegate void Win32Callback(int value1, [MarshalAs(UnmanagedType.LPWStr)] string text1);

// 2. DLL 불러오기
[DllImport("Win32Project1.dll")]
static extern int fnWin32Project1(Win32Callback callback, int value);

// 3. Delegate 변수 설정
public static Win32Callback MyCallback;

static void Main(string[] args)
{
    // 4. Delegate의 변수 설정 (Delegate가 Native에 호출된 이후에 GC에 의해서 처리되는 이슈 방지)
    MyCallback = MyCallbackFunction;

    // 5. 함수 호출
    var result = fnWin32Project1(MyCallback, 5);

    // 6. 결과 확인
    Console.WriteLine(result);
}

public static void MyCallbackFunction(int value1, string text1)
{
    Console.WriteLine(value1 + " : " + text1);
}
```


### 참고 링크
- [C#에서 C/C++ 함수로 콜백 함수를 전달하는 예제 코드](https://www.sysnet.pe.kr/2/0/11099)


# Marshal
## Unmanaged Type
|Type|Description|
|--|--|
|AnsiBStr|BSTR 타입의 ANSI 문자열|
|BStr|BSTR 타입의 Unicode 문자열|
|TBStr|윈도우98에서는 AnsiBSTR, 이후 NT 운영체제는 BStr|
|HString|Windows Runtime의 문자열 표현|
|LPStr|char* 타입의 ANSI 문자열|
|LPWStr|wchar* 타입의 Unitcode 문자열|
|LPTStr|윈도우98에서는 LPStr, 이후 NT 운영체제는 LPWStr|