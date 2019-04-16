# 바이너리 리소스
## 리소스 정의
방법
1. 비주얼스튜디오에 파일 추가
2. 빌드작업(Build Action)을 선택
   - Resource: 위성 어셈블리나 일반 어셈블리에 리소스를 포함한다
   - Content: 리소스를 느슨한 파일로 남겨두지만, AssemlbyAssociatedContentFile 어트리뷰트를 통해서 파일의 상대경로와 파일명을 기록한다
   - ※ EmbeddedResource는 선택하지 않는다: WPF 이전부터 있던 값이며, 별도의 코딩이 없다면 XAML에서 접근 할 수 없다

## 리소스 접근
XAML에서 URI(uniform resource identifiers)를 통해서 가능
- 문자열 URI를 형전환 해주는 Converter가 존재
- 예시
   ```xml
     <StackPanel Orientation="Horizontal" Height="300">
        <Button ToolTip="Previous ...">
            <Image Width="200" Source="Resources/doitc언어입문.jpg" />
        </Button>
    </StackPanel>
   ```


# 로지컬 리소스
