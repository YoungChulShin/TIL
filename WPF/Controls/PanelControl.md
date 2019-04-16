## 패널
### Canvas
- Left, Right, Top, Bottom을 기준으로 위치를 설정
- 2개의 코너에 동시에 도킹을 할 수는 없다
   - Left, Right를 동시에 사용하면 Right는 무시된다
   - Top, Bottom을 동시에 사용하면 Bottom은 무시된다

### StackPanel
- 자식 항목을 배치를 위한 별도의 첨부 프로퍼티가 없고, Orientation만 존재

### WrapPanel
- StackPanel과 유사하나 추가되는 엘리먼트가 충분한 공간이 없을 경우에는 누적되는 방향으로 행이나 열을 바꿔서 Wraping한다
- ItemHeight와 ItemWidth로 컨트롤의 크기를 조정

### DockPanel
- 모든 방향으로 여러개의 엘리먼트도 등록 가능하다

### Grid
- 개발 단계에서 Grid의 점선을 보고자하면 ShowGridLines 속성을 이용한다
- Grid의 길이는 절대값,Auto,* 등을 사용해서 표현할 수 있다. 이는 GridLengthConverter가 값을 변경해주기 때문이다. Code Behind에서는 GridLength를 이용해서 설정할 수 있다. 

### Z-Order 설정
ZIndex 프로퍼티를 통해서 엘리먼트가 패널에서 보여주는 순서를 지정한다
