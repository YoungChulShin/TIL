##UI Control에서 변경한 값이 업데이트가 되지 않을 때. <br>
UWP를 개발하다보면 Control(ex: TextBlock, ListView)에 Data를 업데이트 해야 할 때가 있다.<br> 
그런데 runtime에서 단순히 Control의 속성에 값만 대입하면, 해당 값은 변경되지만 UI는 변경되지 않는 경우가 있다. <br>
이때는 Class에 'INotifyPropertyChanged' interface를 호출 받아서 구현해 주어야 한다. <br>
'INotifyPropertyChanged' Interface는 프로그램에게 property 값이 변경되었을 때, 이 변경사항을 알려주는 역할을 한다. <br><br>
이 Interface는 'PropertyChanged' 라는 이벤트를 구현해야 한다.<br>

>public event PropertyChangedEventHandler PropertyChanged;<br>
>private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")<br>
>{<br>
>    if (PropertyChanged != null)<br>
>    {<br>
>        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));<br>
>    }<br>
>}<br>
