## 트리 종류
### 의사결정 트리(Decision Tree)
- 의사 결정을 위해서 Node를 내려가면서 범위를 좁혀가는 트리
### 서브 트리(Sub Tree)
- 큰 트리는 작은 트리로 구성된다
- 큰 트리에 속하는 작은 트리를 서브 트리
### 이진 트리(Binary Tree)
- 루트 노드를 중심으로 두 개의 서브 트리로 나뉘어지고, 나뉘어진 두 서브 트리도 모둔 이진트리이다
- 노드가 위치할 수 있는 곳에 노드가 존재하지 않는다면 공집합(Empty Set) 노드가 존재하는 것으로 간주한다
### 포화 이진 트리(Full Binary Tree)
- 모든 레벨이 꽉 찬 이진 트리
- 노드를 추가하려면 레벨을 늘려야 한다
### 완전 이진 트리(Complete Binary Tree)
- 포화 이진 트리처럼 모든 레벨이 꽉 찬 상태는 아니지만, 차곡차곡 빈 틈 없이 노드가 채워진 이진 트리


## ADT
BTreeNode* MakeBTreeNode(void);
- 이진트리의 노드를 생성하여 그 주소 값을 반환한다

BTData GetData(BTreeNode* bt);
- 노드에 저장된 데이터를 반환한다

void SetData(BTreeNode* bt, BTData data);
- 노드에 데이터를 저장한다

BTreeNode* GetLeftSubTree(BTreeNode* bt);
- 왼쪽 서브 트리의 주소 값을 반환한다

BTreeNode* GetRightSubTree(BTreeNode* bt);
- 오른쪽 서브 트리의 주소 값을 반환한다

void MakeLeftSubTree(BTreeNode* main, BTreeNode* sub);
- 왼쪽 서브 트리를 연결한다

void MakeRightSubTree(BTreeNode* main, BTreeNode* sub);
- 오른쪽 서브 트리를 연결한다

## 이진 트리의 순회(Traversal)
### 방법
- 전위 순회(Preorder Traversal) : 루트 노드를 먼저
- 중위 순회(Inorder Traversal) : 루트 노드를 중간에
- 후위 순회(Postorder Traversal) : 루트 노드를 마지막에 

### 샘플 코드
[Link](Code\Tree\BinaryTree2.c)

## 수식 트리(Expression Tree)
정의
- 이진트리를 이용해서 수식을 표현해 놓은 것을 수식트리라고 한다
