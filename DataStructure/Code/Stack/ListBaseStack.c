#include <Stdio.h>
#include <stdlib.h>
#include "ListBaseStack.h"

void StackInit(Stack* stack)
{
	stack->head = NULL;
}

int IsEmpty(Stack* stack)
{
	return (stack->head == NULL) ? TRUE : FALSE;
}

void Push(Stack* stack, Data data)
{
	Node* newNode = (Node*)malloc(sizeof(Node));

	newNode->data = data;
	newNode->next = stack->head;

	stack->head = newNode;
}

Data Pop(Stack* stack)
{
	if (IsEmpty(stack))
	{
		printf("Empty data");
		exit(-1);
	}

	Data rData = stack->head->data;
	Node* rNode = stack->head;

	stack->head = stack->head->next;
	free(rNode);

	return rData;
}
Data Peek(Stack* stack)
{
	if (IsEmpty(stack))
	{
		printf("Empty data");
		exit(-1);
	}

	return stack->head->data;
}