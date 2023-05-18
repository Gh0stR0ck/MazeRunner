# IO.Swagger.Model.PossibleActionsAndCurrentScore
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PossibleMoveActions** | [**List&lt;MoveAction&gt;**](MoveAction.md) | The actions available on your surrounding tiles (lookahead of one tile). | [optional] 
**CanCollectScoreHere** | **bool?** | In the tile where you are standing, is it possible to collect score (from hand to bag). | [optional] 
**CanExitMazeHere** | **bool?** | In the tile where you are standing, is it possible to exit the maze. Remember you will lose any score in hand  and only be rewarded with the score you have in your bag. | [optional] 
**CurrentScoreInHand** | **int?** | What is the score you currently have in your hand. Find a score collection point and issue a collect  score command to move this score into your bag. Score in your hand is not awarded when you exit a maze. | [optional] 
**CurrentScoreInBag** | **int?** | What is the score currently in your bag. When you exit the maze this score will be rewarded to your total  overall score. | [optional] 
**TagOnCurrentTile** | **long?** | The tag on the current tile | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

