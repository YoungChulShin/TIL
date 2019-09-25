# 전처리 지시문
`#include`

`#define`
- 매크로를 정의하는 지시문
- 매크로 상수: #define identifier token-list
   ```c++
   #define PI 3.141592
   double d = PI;
   ```
- 매크로 함수: #define identifier(parameter-list) token-list
   ```c++
   #define MULTIPLY(x, y) ((x) * (y))
   #define MULTIPLY2(x, y) x * y

   cout << MULTIPLY(1 + 1, 2 + 2) << endl;
   cout << MULTIPLY2(1 + 1, 2 + 2) << endl;	// 1 + 1 * 2 + 2 = 5
   ```

`#ifdef ~ #else ~ #endif`
- 조건부 컴파일 지시문
    ```c++
    #define PIPE_ORGAN

    #ifdef PIPE_ORGAN
        cout << "정의 되어 있음" << endl;
    #else
        cout << "정의 되어 있지 않음" << endl;
    #endif
    ```

`미리 정의된 매크로`
- `__FILE__`, `__LINE__`, `__FUNCTION__` 등 미리 정의된 매크로가 있다
    ```c++
    cout << __LINE__ << endl;

    #ifdef _M_X64
        cout << "64비트 프로세서" << endl;
    #else
        cout << "32비트 프로세서" << endl;
    #endif
    ```