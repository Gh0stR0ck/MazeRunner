# IO.Swagger.Model.PlayerInfo
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PlayerId** | **string** | The public unique identifier of a player. | [optional] 
**Name** | **string** | The name a player has chosen to represent her. | [optional] 
**IsInMaze** | **bool?** | An indication of whether a player is currently playing a maze or not. | [optional] 
**Maze** | **string** | The name of the maze the player is currently playing. Might be null if player  is not currently playing a maze. | [optional] 
**HasFoundEasterEgg** | **bool?** | Wink wink. | [optional] 
**MazeScoreInHand** | **int?** | How much score the player has in her hand. Only available if player is playing a maze. | [optional] 
**MazeScoreInBag** | **int?** | How much score the player has in her bag. Only available if player is playing a maze. | [optional] 
**PlayerScore** | **int?** | The accumulated score across all played mazes. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

