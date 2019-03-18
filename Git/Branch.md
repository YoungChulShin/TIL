## Branch 리스트 보기
```console
$ git branch
```

## Branch 생성
```console
$ git branch <branch name>
```

## Branch 전환
```console
$ git checkout <branch name>
```
-b 옵션을 넣으면 branch 작성과 체크아웃을 동시에 진행

## Branch 병합
dev branch에서 작업한 내용을 master branch에서 병합한다고 할때 아래와 같이 진행

1. dev branch에서 변경 사항을 커밋
2. master branch로 전환
3. merge 수행
   ```console
   $ git merge <branch name>
   ```

## Branch 삭제
```console
$ git branch -d <branch name>
```

