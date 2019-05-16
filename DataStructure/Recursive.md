### 참고 자료
열혈 자료구조

---

### 탈출조건
모든 재귀는 탈출 조건이 있어야한다. 그렇지 않으면 무한루프에 빠지게 된다. 
```c
void Recursive(int num)
{
    // 재귀의 탈출 조건
    if (num <= 0)
    {
        return;
    }

    // 재귀 호출
    printf("Recursive call! %d\n", num);
    Recursive(num - 1);
}
```
