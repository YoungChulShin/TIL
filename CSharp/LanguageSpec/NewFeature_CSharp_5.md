##C# 5.0 
- 닷넷프레임워크 5.0 
- 윈도우 8이전 버젼에서는 별도로 설치를 해 주어야 한다. 

##호출자 정보
- 호출자 정보를 표시할 수 있는 매크로 상수를 C# 코드에서 사용이 가능하다. 

1. CallerMemberName: 호출자 정보가 명시된 메서드를 호출한 측의 메서드 이름
2. CallerFilePath: 호출자 정보가 명시된 메서드를 호출한 측의 소스코드 파일 경로
3. CallerLineNumber: 호출자 정보가 명시된 메서드를 호출한 측의 소스코드 라인 번호

- 사용 예시
    >static void LogMessage(string text, **[CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0**)