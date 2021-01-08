## 설정
환경 설정 다시하기
- `p10k configure`를 입력하면 다시 설정 가능

Git branch가 잘려서 표시될 때
1. `~/.p10k.zsh` 파일 열기
2. `(( $#where > 32 )) && where[13,-13]="…"` 구분을 찾아서 주석 처리

## 참고 사이트
https://subicura.com/2017/11/22/mac-os-development-environment-setup.html