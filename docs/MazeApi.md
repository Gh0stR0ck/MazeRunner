# IO.Swagger.Api.MazeApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CollectScore**](MazeApi.md#collectscore) | **POST** /api/maze/collectScore | 💰 Collect score from your hand to your bag.
[**ExitMaze**](MazeApi.md#exitmaze) | **POST** /api/maze/exit | 🚪 Exit the maze.
[**Move**](MazeApi.md#move) | **POST** /api/maze/move | Move in the supplied direction.
[**PossibleActions**](MazeApi.md#possibleactions) | **GET** /api/maze/possibleActions | 👀 Get the list of possible actions, from the tile where you are standing.
[**Tag**](MazeApi.md#tag) | **POST** /api/maze/tag | Tag the current tile with the given (non-negative) number


<a name="collectscore"></a>
# **CollectScore**
> PossibleActionsAndCurrentScore CollectScore ()

💰 Collect score from your hand to your bag.

Remember that when you exit a maze, only score in your bag will carry over and be awarded to your overall player score. Any score left in your hand will be lost.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CollectScoreExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // 💰 Collect score from your hand to your bag.
                PossibleActionsAndCurrentScore result = apiInstance.CollectScore();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.CollectScore: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="exitmaze"></a>
# **ExitMaze**
> void ExitMaze ()

🚪 Exit the maze.

Remember that when you exit a maze, only score in your bag will carry over and be awarded to your overall player score. Any score left in your hand will be lost.  Also, remember that you can only play the same maze once, so make sure you have collected as much score as you can.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ExitMazeExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // 🚪 Exit the maze.
                apiInstance.ExitMaze();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.ExitMaze: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="move"></a>
# **Move**
> PossibleActionsAndCurrentScore Move (string direction)

Move in the supplied direction.

You must have already entered a maze. This method will return 200 even if you could not move in this direction. If there is a \"wall\" in your way and you try to move there.. well, it's gonna hurt, but you will remain in the same place.. which.. technically.. is valid.. 🤷🏻‍

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MoveExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();
            var direction = direction_example;  // string | 

            try
            {
                // Move in the supplied direction.
                PossibleActionsAndCurrentScore result = apiInstance.Move(direction);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.Move: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **direction** | **string**|  | 

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="possibleactions"></a>
# **PossibleActions**
> PossibleActionsAndCurrentScore PossibleActions ()

👀 Get the list of possible actions, from the tile where you are standing.

You must have already entered a maze. Also, you shouldn't require this method that much, given than any action you perform on the maze will return this same information.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PossibleActionsExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();

            try
            {
                // 👀 Get the list of possible actions, from the tile where you are standing.
                PossibleActionsAndCurrentScore result = apiInstance.PossibleActions();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.PossibleActions: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="tag"></a>
# **Tag**
> PossibleActionsAndCurrentScore Tag (long? tagValue)

Tag the current tile with the given (non-negative) number

You must have already entered a maze. This method will return 200 even if you already tagged this tile. By tagging a tile \"again\" you will rewrite the previous tag.‍

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TagExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MazeApi();
            var tagValue = 789;  // long? | 

            try
            {
                // Tag the current tile with the given (non-negative) number
                PossibleActionsAndCurrentScore result = apiInstance.Tag(tagValue);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MazeApi.Tag: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tagValue** | **long?**|  | 

### Return type

[**PossibleActionsAndCurrentScore**](PossibleActionsAndCurrentScore.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

