# IO.Swagger.Api.MazesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**All**](MazesApi.md#all) | **GET** /api/mazes/all | 📜 All the mazes that exist in the game.
[**Enter**](MazesApi.md#enter) | **POST** /api/mazes/enter | 🌟 Enter a maze.


<a name="all"></a>
# **All**
> List<MazeInfo> All ()

📜 All the mazes that exist in the game.

Even though you can only play a maze once, this method will return all the mazes. This is not laziness from the server side, this is to make it slightly more \"interesting\", because you need to keep track of the mazes you have already played on your implementation.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AllExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazesApi();

            try
            {
                // 📜 All the mazes that exist in the game.
                List&lt;MazeInfo&gt; result = apiInstance.All();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazesApi.All: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<MazeInfo>**](MazeInfo.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="enter"></a>
# **Enter**
> PossibleActionsAndCurrentScore Enter (string mazeName)

🌟 Enter a maze.

Keep in mind that you can only be playing one maze at a time. Invoking this method when you are already in a maze will result in a failure. Also, you can only play the same maze once. If you wish to play the same maze \"multiple times\", you need to request to forget your player data (via the player API).

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class EnterExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazesApi();
            var mazeName = mazeName_example;  // string | What maze do you wish to enter.

            try
            {
                // 🌟 Enter a maze.
                PossibleActionsAndCurrentScore result = apiInstance.Enter(mazeName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazesApi.Enter: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **mazeName** | **string**| What maze do you wish to enter. | 

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

