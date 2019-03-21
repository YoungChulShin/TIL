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
   - master로 변경하면 dev branch에서 변경한 내용은 반영되어 있지 않아야 한다
3. merge 수행
   ```console
   $ git merge <branch name>
   ```

## Branch 삭제
```console
$ git branch -d <branch name>
```

## Branch 충돌
Merge 이후에 충돌이 발생하면 아래 2가지의 방법으로 해결이 가능하다

### 1. 변경 사항을 수정하고 추가 Commit
- non fast-forward 병합
- merge 중에 발생한 에러는 변경 사항에 반영되어 있다. 여기서 잘못된 부분을 수정하고 Add -> Commit 하는 방법
- 아래와 그림 같이 Flow가 생성
!["Flow](https://backlog.com/git-tutorial/kr/img/post/stepup/capture_stepup2_7_2.png)

### 2. rebase로 병합
rebase 명령어를 이용해서 flow를 하나의 줄기로 만들고 병합하는 방식
1. 변경 사항을 커밋할 branch 로 이동
2. rebase할 branch 설정
   ```console
   $ git rebase master
   ```
3. 충돌 사항이 있으면 충돌 내용이 파일에 반영
4. 충돌 내용을 수정
5. 변경 사항을 add -> rebase 로 진행
   ```console
   $ git add test.txt
   $ git rebase --continue
   ```
6. master branch로 이동해서 병합
   ```console
   $ git merge issue3
   ```
