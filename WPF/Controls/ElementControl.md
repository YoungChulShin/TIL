
# 엘리먼티의 크기 및 위치 관리 

### 컨트롤의 파생
System.Windows.Controls.Panel
- 다수의 자식 컨트롤을 지원하는 부모 엘리먼트

System.Windows.UIElement
- 화면 배치 과정에 포함되는 모든 컨트롤

## 크기 조정
RenderSize
- 화면 배치 완료 이후에 최종 크기
ActualHeight, ActualWidth
- RenderSize의 Width, Height와 동일

Margin
- FrameworkElement 클래스를 상속한 엘리먼트

Padding
- Controls 클래스를 상속한 엘리먼트
- Label은 Default 값이 5

## 위치 조정
Stretch 정렬과 명시적인 크기를 비교하면 명시적인 크기가 우선순위가 더 높다

FlowDirection
- 컨텐츠의 정렬 방향을 설정

## 형태 변경
FrameworkElement 클래스를 상속받은 엘리먼트의 경우 아래 2개의 프로퍼티가 존재
- LayoutTransform: 화면배치전에 변환이 적용. UI가 겹치지 않는다
- RenderTransform: 화면배치후에 변환이 적용. UI가 겹칠 수 있다
   - RenderTransformOrigin: 회전 좌표 값
      - 0,0: 좌측 상단
      - 0,1: 좌측 하단
      - 1,1: 우측 하단

    ```xml
    <Path.LayoutTransform>
        <TransformGroup>
            <RotateTransform Angle="180"/>
        </TransformGroup>
    </Path.LayoutTransform>
    ```

변경 종류
- Rotate Transform
   - CenterX와 Y를 기준으로 특정 Angle만큼 Element를 회전
   - 적용이 되는 Control에 RenderTransformOrigin 값을 통해서 설정하는 것이 더 좋다 (상대적인 좌표 설정이 가능하기 때문)
   - 버튼의 경우 내부 Text를 조정하고 싶으면, 내부에 TextBlock을 선언하고 RenderTransform 값을 설정하면 텍스트만 회전 가능하다
- ScaleTransform
   - 특정 비율로 엘리먼트의 사이즈를 늘릴 때
- SkewTransform
   - 기울임 설정
- TranslateTransform
   - X, Y 좌표를 기준으로 엘리먼트 이동
- MatrixTransform
- TransformGroup
   - TransformGroup에 각 형태 변경을 선언하면서 복잡적으로 기능을 적용할 수 있다

