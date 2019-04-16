
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

