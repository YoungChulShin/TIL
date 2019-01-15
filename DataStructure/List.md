### 리스트 종류
- 순차 리스트: 배열을 기반으로 구현된 리스트
- Linked List: 메모리의 동적 할당을 기반으로 구성된 리스트

### 리스트 ADT
void ListInit(List *plist);
- 리스트 초기화
- 가장먼저 호출되어야 한다

void LInsert(List *plist, LData data);
- 리스트에 데이터 저장

int LFisrt(List *plist, LData *pdata);
- 첫번째 데이터가 pdata가 가리키는 메모리에 저장
- 데이터의 참조를 위한 초기화가 진행된다
- 성공시 TRUE(1), 실패시 FALSE(0) 반환

int LNext(List *plist, LData *pdata);
- 참조된 데이터의 다음 데이터가 pdata가 가리키는 메모리에 저장
- 참조를 새로 시작하려면 LFirst를 호출해야 한다
- 참조 성공 시 TRUE(1), 실패시 FALSE(0) 반환

LData LRemove(List *plist);
- LFirst 또는 LNext함수의 마지막 반환 데이터를 삭제한다
- 삭제된 데이터는 반환된다

int LCount(List* plist);
- 리스트에 저장되어 있는 데이터의 수를 반환한다