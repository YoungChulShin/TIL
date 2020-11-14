## Windows Terminal 셋업
### 단축키
화면 가로 분할
- 키: `Alt` + `Shift` + `+`

화면 세로 분할
- 키: `Alt` + `Shift` + `-`

화면 크기 조정
- 키: `Alt` + `Shift` + `화살표` 

분할 화면 이동
- 키: `Alt` + `화살표` 

### Git Bash 추가
Profile
```yaml
{
    "tabTitle": "Git Bash",
    "acrylicOpacity": 0.75,
    "closeOnExit": true,
    "colorScheme": "GitBash",
    "commandline": "C:/Program Files/Git/bin/bash.exe --login",
    "cursorColor": "#FFFFFF",
    "cursorShape": "bar",
    "fontFace": "Consolas",
    "fontSize": 12,
    "guid": "{14ad203f-52cc-4110-90d6-d96e0f41b64d}",
    "historySize": 9001,
    "icon": "%PROGRAMFILES%\\Git\\mingw64\\share\\git\\git-for-windows.ico",
    "name": "Git Bash",
    "padding": "0, 0, 0, 0",
    "startingDirectory": "%USERPROFILE%",
    "snapOnInput": true,
    "useAcrylic": false
},
```

Scheme
```yaml
{
    "background": "#000000",
    "black": "#0C0C0C",
    "blue": "#6060ff",
    "brightBlack": "#767676",
    "brightBlue": "#3B78FF",
    "brightCyan": "#61D6D6",
    "brightGreen": "#16C60C",
    "brightPurple": "#B4009E",
    "brightRed": "#E74856",
    "brightWhite": "#F2F2F2",
    "brightYellow": "#F9F1A5",
    "cyan": "#3A96DD",
    "foreground": "#bfbfbf",
    "green": "#00a400",
    "name": "GitBash",
    "purple": "#bf00bf",
    "red": "#bf0000",
    "white": "#ffffff",
    "yellow": "#bfbf00",
    "grey": "#bfbfbf"
}
```