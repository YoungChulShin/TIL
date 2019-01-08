## 파일
### 파일 관련 함수 및 클래스
- File: 파일 및 디렉터리를 지칭하는 클래스
- FileInputStream: 바이트 데이터를 읽기 위한 함수
- FileOutputStream: 바이트 데이터를 쓰기 위한 함수
- FileReader: 문자열 데이터를 읽기 위한 함수
- FileWriter: 문자열 데이터를 쓰기 위한 함수


### 저장 공간
- 내부 저장 공간: getFileDir()
- 외부 저장 공간: Envvironment.getExtraStorgaeDirectory().getAbsolutePath() + "My Path"

## SharedPreference
### 정의
- 앱의 데이터를 영속적으로 저장하기 위한 클래스
- key-value 구조

### 관련 함수
- getPreference
- getSharedPreference
- PreferenceManger.getDefaultSharedPreference