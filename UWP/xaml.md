##프레임
- 프레임에는 기본적으로 루트 프레임이 있고, 내부적으로 Page내에서 Frame을 생성할 수 있다. 
- 루트 프레임을 유지하면서 페이지를 이동하면서 내부적으로 선언한 페이지에서 이동을 해야 한다. 
- 페이지 이동
    1. 특정 페이지 이동
        - 'FrameName'.Nagivate(typeof(targetFrame));
    2. 앞으로 이동
        - 'FrameName'.GoFoward()
        - CanGoFoward 속성을 이용해서 이동 가능 확인 후 이동하면 된다. 
    3. 뒤로 이동
        - 'FrameName'.GoBack()
        - CanGoBack 속성을 이용해서 이동 가능한 지 확인 후 이동하면 된다.



##XAML 컨트롤
###TextBlock
- 텍스트 표시를 할 때 사용
###HyperLinkButton
- 하이퍼 링크 표시
- NagivateUri 속성을 이용해서 웹페이지로도 이동할 수 있다. 
###TextBox
- Winform의 텍스트 박스

