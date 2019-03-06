## 간단한 RESTful Service 구현
```c#
private static async void MakeGetResponse(string uri)
{
    var restClient = new HttpClient();
    var getReqeust = await restClient.GetStringAsync(uri);

    Console.WriteLine(getReqeust);
}

private static async void MakePostResponse(string uri)
{
    var restClient = new HttpClient();
    var postRequest = await restClient.PostAsync(uri, new StringContent("test"));

    var responseContent = await postRequest.Content.ReadAsStringAsync();

    Console.WriteLine(responseContent);
}
```