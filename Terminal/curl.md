

## 기본 정보
홈페이지: https://curl.se/

기본 설명: command line tool and library for transferring data with URLs (since 1998)

## 사용법
옵션
- -d, --data: POST에서 데이터 전송
- -H, --header: Header 설정
- -x, --request: 요청 내용. 예: GET, POST

요청 샘플
~~~bash
// GET 요청
curl -d "key1=value1&key2=value2" \
-H "Content-Type: application/x-www-form-urlencoded" \
-X GET http://localhost:8000/data

// POST 요청
curl -d "key1=value1&key2=value2" \
-H "Content-Type: application/x-www-form-urlencoded" \
-X POST http://localhost:8000/data

// Post - Json 요청
curl -d '{"key1":"value1", "key2":"value2"}' \
-H "Content-Type: application/json" \
-X POST http://localhost:8000/data
~~~