# IO.Swagger.Api.PlayerApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Forget**](PlayerApi.md#forget) | **DELETE** /api/player/forget | 🙈 Forget your current progress.
[**Get**](PlayerApi.md#get) | **GET** /api/player | 👤 Obtain information about yourself.
[**Register**](PlayerApi.md#register) | **POST** /api/player/register | 📝 Register yourself here.


<a name="forget"></a>
# **Forget**
> void Forget ()

🙈 Forget your current progress.

👻 This allows you to re-register with a different name, and even repeat the mazes that you have played before.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ForgetExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new PlayerApi();

            try
            {
                // 🙈 Forget your current progress.
                apiInstance.Forget();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.Forget: " + e.Message );
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

<a name="get"></a>
# **Get**
> PlayerInfo Get ()

👤 Obtain information about yourself.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new PlayerApi();

            try
            {
                // 👤 Obtain information about yourself.
                PlayerInfo result = apiInstance.Get();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PlayerInfo**](PlayerInfo.md)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="register"></a>
# **Register**
> void Register (string name)

📝 Register yourself here.

You need to register to be able to start navigating through mazes.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegisterExample
    {
        public void main()
        {
            // Configure API key authorization: User token
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new PlayerApi();
            var name = name_example;  // string | The name you wish to represent you in the leader board.

            try
            {
                // 📝 Register yourself here.
                apiInstance.Register(name);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.Register: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**| The name you wish to represent you in the leader board. | 

### Return type

void (empty response body)

### Authorization

[User token](../README.md#User token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

