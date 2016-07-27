
##테스트 페이지
- [Link](http://kaki104.tistory.com/511)


##LUIS
MS에서 제공하는 자연어 처리 서비스
페이지 링크: [Link](https://www.luis.ai/applicationlist)

App(FaceBook or Skype)에서 메시지를 보내면 BotFrameWork를 통해서 Azure내에 있는 App Service로 넘겨지고, 여기서 Luis와 연동하여 메시지를 가져온다. 

LUID는 Intend라는 기본적으로 정의되어 있는 메시지 셋이 있다.
>{ <br>
>  "query": "set alarm 7am",<br>
>  "intents": [<br>
>    {<br>
>      "intent": "builtin.intent.alarm.set_alarm"<br>
>    }<br>
>  ],<br>
>  "entities": [ <br>
>    {<br>
>      "entity": "7am",<br> 
>      "type": "builtin.alarm.start_time",<br>
>      "resolution": {<br>
>        "resolution_type": "builtin.datetime.time",<br>
>        "time": "T07"<br>
>      }<br>
>    }<br>
>  ]<br>
>}<br>


##Example Message - 1
- 알름 설정: turn on my wake up alarm 6am
- 결과 값
{
  "type": "message",
  "timestamp": "2016-07-27T12:43:17.4437571Z",
  "from": {
    "id": "56800324",
    "name": "Bot1"
  },
  "conversation": {
    "id": "8a684db8",
    "name": "Conv1"
  },
  "recipient": {
    "id": "2c1c7fa3",
    "name": "User1"
  },
  "text": "alarm [wake up at 2016. 7. 27. 오전 6:00:00] created",
  "replyToId": "697b8fc9a84a4ec0abb8ef4d882dbb91"
}

##Example Message - 2
- 알람 설정: what time is my wake up alarm set for? 
- 결과 값
{
  "type": "message",
  "timestamp": "2016-07-27T12:44:26.1933012Z",
  "from": {
    "id": "56800324",
    "name": "Bot1"
  },
  "conversation": {
    "id": "8a684db8",
    "name": "Conv1"
  },
  "recipient": {
    "id": "2c1c7fa3",
    "name": "User1"
  },
  "text": "found alarm [wake up at 2016. 7. 27. 오전 6:00:00]",
  "replyToId": "a5e01865b7cd4f73ad1c96613ec7267c"
}

