## 정의
- 먼저 들어간 것이 먼저 나오는 구조 (LIFO, Last In First Out)

## ADT
- Init
   ```c
   void StackInit(Stack* pstack);
   ```
- IsEmpty
   ```c
   int IsEmpty(Stack* pstack);
   ```
- push
   ```c
   void Push(Stack* pstack, Data data);
   ```
- pop
   ```c
   void Pop(Stack* pstack);
   ```
- peek
   ```c
   Data Peek(Stack* pstack);
   ```