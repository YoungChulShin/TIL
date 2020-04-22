이미지 받기
- docker image pull

이미지 빌드
- `docker image build -t 이미지명[:태그명] Dockerfile의_경로`
    ```command
    docker image build -t example/echo:latest

    Status: Downloaded newer image for golang:1.9
    ---> ef89ef5c42a9
    Step 2/4 : RUN mkdir /echo
    ---> Running in 44eaf5871a03
    Removing intermediate container 44eaf5871a03
    ---> 61cbf67db436
    Step 3/4 : COPY main.go /echo
    ---> 63c391aa84b3
    Step 4/4 : CMD ["go", "run", "/echo/main.go"]
    ---> Running in c12b9df100b0
    Removing intermediate container c12b9df100b0
    ---> 9f9393bd7bfb
    Successfully built 9f9393bd7bfb
    ```

이미지 빌드 확인
- `docker image ls`

컨테이너 -> 이미지 생성
- docker commmit -a "생성자 정보" -m "이미지 메시지" 'container name' 'image name'/'tag name'
- 샘플 
   - docker commit -a 'ycshin' -m 'kafka study' testZookeeper03 zookeeper03/kafka_study