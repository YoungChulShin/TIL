//#include "ArrayBaseStack.h"
//
//void StackInit(Stack *pstack)
//{
//	pstack->topIndex = -1;
//}
//
//int IsEmpty(Stack* pstack)
//{
//	return (pstack->topIndex == -1) ? TRUE : FALSE;
//}
//
//void Push(Stack* pstack, Data data)
//{
//	if (pstack->topIndex == STACK_LEN)
//	{
//		// ¿¡·¯?
//		return;
//	}
//
//	pstack->topIndex += 1;
//	pstack->stackArr[pstack->topIndex] = data;
//}
//Data Pop(Stack* pstack)
//{
//	if (IsEmpty(pstack) == TRUE)
//	{
//		printf("Stack memory Error");
//		exit(-1);
//	}
//
//	int rIdx = pstack->topIndex;
//	pstack->topIndex -= 1;
//
//	return pstack->stackArr[rIdx];
//}
//Data Peek(Stack* pstack)
//{
//	if (IsEmpty(pstack) == TRUE)
//	{
//		printf("Stack memory Error");
//		exit(-1);
//	}
//
//	return pstack->stackArr[pstack->topIndex];
//}