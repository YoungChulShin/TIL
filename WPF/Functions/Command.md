## Command 처리 예시

```xml
<Window.CommandBindings>
    <CommandBinding Command="Help"
                    CanExecute="CommandBinding_CanExecute"
                    Executed="CommandBinding_Executed"/>
</Window.CommandBindings>

<Button MinWidth="75" 
        Margin="10" 
        Command="Help"
        Content="{Binding RelativeSource={RelativeSource Mode=Self}, Path=Command.Text}" />
```

## 입력 행위로 명령어 실행하기
입력 처리
- InputBinding을 통해서 키 입력 처리 가능
    ```xml
    <Window.CommandBindings>
        <CommandBinding Command="Help" 
                        CanExecute="CommandBinding_CanExecute"
                        Executed="CommandBinding_Executed"/>
    </Window.CommandBindings>
    <Window.InputBindings>
        <KeyBinding Command="Help" Key="F2"/>
    </Window.InputBindings>
    ```

입력 취소
- Command에 NotACommand를 입력해서 처리
