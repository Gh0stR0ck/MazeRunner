/* 
 * A-maze-ing API
 *
 * This document describes the API of the A-maze-ing evening server.    This API consists of three different endpoints, which are detailed below.   - To register yourself as a player use the Player endpoint.   - To get information about the available mazes and enter a specific maze use the Mazes endpoint.   - To navigate a maze use the Maze endpoint.
 *
 * OpenAPI spec version: v2
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// From the current tile where you stand, what actions are available on it and on the surrounding tiles.
    /// </summary>
    [DataContract]
    public partial class PossibleActionsAndCurrentScore :  IEquatable<PossibleActionsAndCurrentScore>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleActionsAndCurrentScore" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public PossibleActionsAndCurrentScore()
        {
        }
        
        /// <summary>
        /// The actions available on your surrounding tiles (lookahead of one tile).
        /// </summary>
        /// <value>The actions available on your surrounding tiles (lookahead of one tile).</value>
        [DataMember(Name="possibleMoveActions", EmitDefaultValue=false)]
        public List<MoveAction> PossibleMoveActions { get; private set; }

        /// <summary>
        /// In the tile where you are standing, is it possible to collect score (from hand to bag).
        /// </summary>
        /// <value>In the tile where you are standing, is it possible to collect score (from hand to bag).</value>
        [DataMember(Name="canCollectScoreHere", EmitDefaultValue=false)]
        public bool? CanCollectScoreHere { get; private set; }

        /// <summary>
        /// In the tile where you are standing, is it possible to exit the maze. Remember you will lose any score in hand  and only be rewarded with the score you have in your bag.
        /// </summary>
        /// <value>In the tile where you are standing, is it possible to exit the maze. Remember you will lose any score in hand  and only be rewarded with the score you have in your bag.</value>
        [DataMember(Name="canExitMazeHere", EmitDefaultValue=false)]
        public bool? CanExitMazeHere { get; private set; }

        /// <summary>
        /// What is the score you currently have in your hand. Find a score collection point and issue a collect  score command to move this score into your bag. Score in your hand is not awarded when you exit a maze.
        /// </summary>
        /// <value>What is the score you currently have in your hand. Find a score collection point and issue a collect  score command to move this score into your bag. Score in your hand is not awarded when you exit a maze.</value>
        [DataMember(Name="currentScoreInHand", EmitDefaultValue=false)]
        public int? CurrentScoreInHand { get; private set; }

        /// <summary>
        /// What is the score currently in your bag. When you exit the maze this score will be rewarded to your total  overall score.
        /// </summary>
        /// <value>What is the score currently in your bag. When you exit the maze this score will be rewarded to your total  overall score.</value>
        [DataMember(Name="currentScoreInBag", EmitDefaultValue=false)]
        public int? CurrentScoreInBag { get; private set; }

        /// <summary>
        /// The tag on the current tile
        /// </summary>
        /// <value>The tag on the current tile</value>
        [DataMember(Name="tagOnCurrentTile", EmitDefaultValue=false)]
        public long? TagOnCurrentTile { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PossibleActionsAndCurrentScore {\n");
            sb.Append("  PossibleMoveActions: ").Append(PossibleMoveActions).Append("\n");
            sb.Append("  CanCollectScoreHere: ").Append(CanCollectScoreHere).Append("\n");
            sb.Append("  CanExitMazeHere: ").Append(CanExitMazeHere).Append("\n");
            sb.Append("  CurrentScoreInHand: ").Append(CurrentScoreInHand).Append("\n");
            sb.Append("  CurrentScoreInBag: ").Append(CurrentScoreInBag).Append("\n");
            sb.Append("  TagOnCurrentTile: ").Append(TagOnCurrentTile).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PossibleActionsAndCurrentScore);
        }

        /// <summary>
        /// Returns true if PossibleActionsAndCurrentScore instances are equal
        /// </summary>
        /// <param name="input">Instance of PossibleActionsAndCurrentScore to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PossibleActionsAndCurrentScore input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PossibleMoveActions == input.PossibleMoveActions ||
                    this.PossibleMoveActions != null &&
                    this.PossibleMoveActions.SequenceEqual(input.PossibleMoveActions)
                ) && 
                (
                    this.CanCollectScoreHere == input.CanCollectScoreHere ||
                    (this.CanCollectScoreHere != null &&
                    this.CanCollectScoreHere.Equals(input.CanCollectScoreHere))
                ) && 
                (
                    this.CanExitMazeHere == input.CanExitMazeHere ||
                    (this.CanExitMazeHere != null &&
                    this.CanExitMazeHere.Equals(input.CanExitMazeHere))
                ) && 
                (
                    this.CurrentScoreInHand == input.CurrentScoreInHand ||
                    (this.CurrentScoreInHand != null &&
                    this.CurrentScoreInHand.Equals(input.CurrentScoreInHand))
                ) && 
                (
                    this.CurrentScoreInBag == input.CurrentScoreInBag ||
                    (this.CurrentScoreInBag != null &&
                    this.CurrentScoreInBag.Equals(input.CurrentScoreInBag))
                ) && 
                (
                    this.TagOnCurrentTile == input.TagOnCurrentTile ||
                    (this.TagOnCurrentTile != null &&
                    this.TagOnCurrentTile.Equals(input.TagOnCurrentTile))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.PossibleMoveActions != null)
                    hashCode = hashCode * 59 + this.PossibleMoveActions.GetHashCode();
                if (this.CanCollectScoreHere != null)
                    hashCode = hashCode * 59 + this.CanCollectScoreHere.GetHashCode();
                if (this.CanExitMazeHere != null)
                    hashCode = hashCode * 59 + this.CanExitMazeHere.GetHashCode();
                if (this.CurrentScoreInHand != null)
                    hashCode = hashCode * 59 + this.CurrentScoreInHand.GetHashCode();
                if (this.CurrentScoreInBag != null)
                    hashCode = hashCode * 59 + this.CurrentScoreInBag.GetHashCode();
                if (this.TagOnCurrentTile != null)
                    hashCode = hashCode * 59 + this.TagOnCurrentTile.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}