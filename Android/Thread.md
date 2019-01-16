### ANR
정의 
- Application Not Responsing
- 액티비티가 화면에 출력된 상황에서 사용자 이벤트에 5초 이내에 반응하지 못하면 시스템에서 강제로 종료

### ANR 문제 해결
방법
- 별도의 Thread를 만들어서 오래 걸리는 작업은 해당 Thread에서 진행

### Thread 사용
1. Thread 클래스를 상속
   ```java
   // 선언
   class MyThread extends Thread {
       public void run() {

       }
   }

   // 사용
   MyThread thread = new MyThread();
   thread.start();
   ```
2. Runnable Interface 구현
   ```java
   // 선언
   class MyThread implements Runnable {
       public void run() {

       }
   }

   // 사용
   MyThread runnable = new MyThread();
   Thread thread = new Thread(runnable);
   thread.start();
   ```
3. 기타
   - sleep: 실행 중인 스레드를 Sleep Pool로 보내어 지정 시간동안 대기 상태로 변경
   - wait: 스레드가 여러개 존재하면서 서로 간의 작업을 차례로 또는 일정한 순서에 따라 진행하고 싶을 때 사용.<br>
   스스로 수행 상태가 될 수는 없으며, 다른 스레드에서 notify를 이용해서 깨워줘야 한다

### Handler
배경
- 개발자 스레드에서 UI스레드의 뷰에 접근하면 런타임 에러 발생

활용
1. post를 이용해서 호출
2. sendMessage를 이용해서 호출

예제 코드
```java
    Handler handler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            if (msg.what == 1) {
                textView.setText(String.valueOf(msg.arg1));
            } else if (msg.what == 2) {
                textView.setText((String)msg.obj);
            }
        }
    };

    class MyThread extends Thread {
        public void run() {
            try {
                int count = 10;
                while(loopFlag) {
                    Thread.sleep(1000);
                    if (isRun) {
                        count--;
                        Message message = new Message();
                        message.what = 1;
                        message.arg1 = count;
                        handler.sendMessage(message);
                        if (count == 0) {
                            message = new Message();
                            message.what = 2;
                            message.obj = "Finished";
                            handler.sendMessage(message);
                            loopFlag = false;
                        }
                    }
                }
            } catch (Exception e) {

            } finally {
                loopFlag = true;
                isFirst = true;
            }
        }
    }
```

### Async Task
선언
- 추상클래스 이므로 상속: extends AsyncTask<Void, Integer, String> 
   - Void: doInBackground의 파라미터 형
   - Integer: doInBackground에서 onProgressUpdate를 호출할 때 넘겨주는 값
   - String: doInBackground의 리턴 값. onPostExecute의 파라미터 형식

함수
- doInBackground: 스레드에 의해서 처리될 내용
- onProgressUpdate: 함수에 의해서 처리되는 중간 값을 처리
- onPostExecute: 최종 완료 이후에 한번 호출


속성
- isRun : 동작 여부
- execute: 실행

코드

    ```java
    @Override
    public void onClick(View v) {
        if (v == startView) {
            if (isFirst) {
                asyncTask = new MyAsyncTask();
                asyncTask.isRun = true;
                asyncTask.execute();
                isFirst = false;
            } else {
                asyncTask.isRun = true;
            }
        } else {
            asyncTask.isRun = false;
        }
    }

    class MyAsyncTask extends AsyncTask<Void, Integer, String> {
        boolean loopFlag = true;
        boolean isRun;

        @Override
        protected String doInBackground(Void... voids) {
            int count = 10;
            while(loopFlag) {
                SystemClock.sleep(1000);
                if (isRun) {
                    count--;
                    publishProgress(count);
                    if (count == 0) {
                        loopFlag = false;
                    }
                }
            }

            isFirst = true;
            return "Finished";
        }

        @Override
        protected void onProgressUpdate(Integer... values) {
            textView.setText(values[0].toString());
        }

        @Override
        protected void onPostExecute(String s) {
            textView.setText(s);
        }
    }
    ```

### Looper
정의
- Handler의 경우는 UI Thread의 MessageQue에 메시지를 넣어주는 역할
- 메시지를 가져와서 handleMessage()에 전달하는 역할은 Looper가 진행
- Thread 클래스들 사이에서 데이터를 주고 받을 때 Looper를 매뉴얼로 구성

함수
- Looper.prepare(): 메시지 큐를 준비
- Looper.loop(): Lopper를 구동
- quit(): Looper를 종료
   - Looper는 무한루프를 도는 작업이기 때문에 꼭 종료를 해주어야 한다
      ```java
      oneThread.oneHandler.getLooper().quit();
      // oneTread: Thread 변수
      // oneHandler: Handler 변수
      ```

예시 코드
   ```java
   class OneThread extends Thread {
        Handler oneHandler;
        @Override
        public void run() {
            Looper.prepare();
            oneHandler = new Handler(){
                @Override
                public void handleMessage(Message msg) {
                    SystemClock.sleep(1000);
                    final int data = msg.arg1;
                    if (msg.what == 0) {
                        handler.post(new Runnable() {
                            @Override
                            public void run() {
                                evenDatas.add("even : " + data);
                                evenAdapter.notifyDataSetChanged();
                            }
                        });
                    } else if (msg.what == 1) {
                        handler.post(new Runnable() {
                            @Override
                            public void run() {
                                oddDatas.add("odd : " + data);
                                oddAdapter.notifyDataSetChanged();
                            }
                        });
                    }
                }
            };
            Looper.loop();
        }
    }

    class TwoThread extends Thread {
        @Override
        public void run() {
            Random random = new Random();
            for (int i = 0; i < 10; i++) {
                SystemClock.sleep(100);
                int data = random.nextInt(10);
                Message message = new Message();
                if (data % 2 == 0) {
                    message.what = 0;
                }else {
                    message.what = 1;
                }

                message.arg1 = data;
                message.arg2 = i;
                oneThread.oneHandler.sendMessage(message);
            }

            Log.d("shin", "Two thread stop");
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        oneThread.oneHandler.getLooper().quit();
    }
   ```

## 개인 정리
### Thread 처리
Thread 구현
1. Thread를 직접 구현 후 start하는 방법
2. Runnable interface를 구현한 클래스를 Thread의 파라미터로 넘겨주는 방법

프로그램 Thread에서 UI Thread로 데이터를 보내는 방법
1. Handler를 만들어서 post
   - View 작업을 하는 Class를 생성 (Runnable을 implements)
   - Runnable을 구현하는 Thread 클래스를 생성
      - 이 클래스에서 Handler로 post하는데, post의 인자가 View 작업을 하는 클래스
   - Runnable을 가져오는 쓰레드 생성 및 시작
   -
2. Handler를 만들어서 sendMessage
   - Thread Class를 만들고 로직 구현
   - 로직에서 UI Thread로 보내고 싶은 값을 Message로 구현
   - handler에 sendMessage로 메시지 전달
   - Handler를 구현한는 쪽에서 handleMessage 구현

### Async Task 구현
구현
1. AsyncTask 클래스 생성 및 로직 구현
   - 데이터 처리는 AyncTask 내에 있는 Event처리 함수에서 대응
2. AsyncTask start 로 시작

