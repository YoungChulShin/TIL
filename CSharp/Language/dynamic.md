### Dynamic
배경
- MS에서 동작언어도 닷넷프레임워크와 호환이 되도록 CLR을 바탕으로 한 DLR(Dynamic Language Runtime)을 내놓았다
- 동적 언어인 루비, 파이썬도 대응이 가능하도록 IronRuby, IconPython 을 포팅
- 동적언어와 연동을 쉽게 할 수 있도록 dynamic 추가

사용 예시
   ```c#
   dynamic d = 5;
   int sum = d + 10;
   Console.WriteLine(sum);
   ```

특징
- 컴파일 시점에 타입을 결정하지 않고, 런타임 시점에 타입을 결정

### 리플렉션 개션


### 덕 타이핑 (duck typing)
- 일반적으로 객체지향 언어에서는 강력한 형식(Strong Type)이 적용되어 있어서 특정 속성이나 메서드를 호출하고 싶으면 반드시 그 형식을 기반으로 동작하게 된다.<br>
하지만 동적언에서 널리 사용되는 덕 타이핑은 강력한 형식을 기반으로 하지 않고 같은 이름의 속성이나 메서드가 공통으로 제공된다면 그것을 기능인 관점에서 동일한 객체라고 본다

예시
   ```c#
    public int DuckTypingCall(dynamic target, dynamic item)
    {
        return target.IndexOf(item);
    }

    public void DuckTest()
    {
        string txt = "test funfc";
        List<int> list = new List<int> { 1, 2, 3, 4, 5};

        Console.WriteLine(DuckTypingCall(txt, "f"));
        Console.WriteLine(DuckTypingCall(list, 2));
    }
   ```

### 동적언어 타입 연동
1. 패키지 추가
- 도구(Tools) -> 라이브러리 패키지 관리자(Library Package Manager) -> 패키지 관리자 콘솔(Package Manager Console)
- Install-Package IronPython

2. 코드 작성
   ```c#
   var scriptEngine = Python.CreateEngine();
            var scriptScope = scriptEngine.CreateScope();

            string code = @"
   def AddFunc(a, b): 
       print 'Addfunc called'              
       return (a + b) ";

            scriptEngine.Execute(code, scriptScope);
            dynamic addFunc = scriptScope.GetVariable("AddFunc");

            int result = addFunc(5, 10);
   ```