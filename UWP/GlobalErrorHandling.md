##UWP App에서 Global Error Handling
- C#프로그램에서 Erro에 대해서 Handling을 해 주지 않으면, 프로그램 실행 중에 종료되는 문제가 발생한다. 
- 일반적으로는 catch를 만들어서 Exception에 대해서 Handling해 주지만, 이러한 문제를 놓쳤을 때 모든 Error를 최종적으로 Control해 줄 수 있는 코드를 추가해서 프로그램이 종료되는 것을 막아준다. 

##해결 방법
- 프로젝트에 있는 app.cs 파일에서 비 정상적인 에러가 발생했을 때, 처리해 주는 코드를 추가한다. 
- 수정 파일: App.cs
- 수정 위치: 생성자 안에 처리하는 코드를 넣어준다. 
- 소스 예제
    >public App()<br>
    >{<br>
    >this.UnhandledException += (sender, e) =><br>
    >e.Handled = true<br>
    >__// Innput Handle Code Here__<br>
    >}<br>
