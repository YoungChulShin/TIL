## Package
Microsoft.Windows.Shell

## 기능
Provides Windows Chrome and Taskbar integration facilities

윈도우에 크롬창 같은 드래그와 사이즈 조정 기능을 제공

## 예시
```xml
 <WindowChrome.WindowChrome>
    <WindowChrome ResizeBorderThickness="{Binding ResizeBorderThickness}" 
                    CaptionHeight="{Binding TitleHeight}"
                    CornerRadius="0"
                    GlassFrameThickness="0"
                    />
</WindowChrome.WindowChrome>
```
### ResizeBorderThickness
창 크기를 조절할 수 있는 두께

### TitleHeight
타이틀 창 높이