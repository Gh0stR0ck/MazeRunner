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
    /// A tile
    /// </summary>
    [DataContract]
    public partial class MoveAction :  IEquatable<MoveAction>, IValidatableObject
    {
        /// <summary>
        /// What is the relative direction of this tile.
        /// </summary>
        /// <value>What is the relative direction of this tile.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DirectionEnum
        {
            
            /// <summary>
            /// Enum Up for value: Up
            /// </summary>
            [EnumMember(Value = "Up")]
            Up = 1,
            
            /// <summary>
            /// Enum Right for value: Right
            /// </summary>
            [EnumMember(Value = "Right")]
            Right = 2,
            
            /// <summary>
            /// Enum Down for value: Down
            /// </summary>
            [EnumMember(Value = "Down")]
            Down = 3,
            
            /// <summary>
            /// Enum Left for value: Left
            /// </summary>
            [EnumMember(Value = "Left")]
            Left = 4
        }

        /// <summary>
        /// What is the relative direction of this tile.
        /// </summary>
        /// <value>What is the relative direction of this tile.</value>
        [DataMember(Name="direction", EmitDefaultValue=false)]
        public DirectionEnum? Direction { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveAction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public MoveAction()
        {
        }
        

        /// <summary>
        /// Is this the tile where the maze begun.
        /// </summary>
        /// <value>Is this the tile where the maze begun.</value>
        [DataMember(Name="isStart", EmitDefaultValue=false)]
        public bool? IsStart { get; private set; }

        /// <summary>
        /// Can you exit the maze on this tile.
        /// </summary>
        /// <value>Can you exit the maze on this tile.</value>
        [DataMember(Name="allowsExit", EmitDefaultValue=false)]
        public bool? AllowsExit { get; private set; }

        /// <summary>
        /// Does this tile allow for score collection (moving score from your hand to your bag).
        /// </summary>
        /// <value>Does this tile allow for score collection (moving score from your hand to your bag).</value>
        [DataMember(Name="allowsScoreCollection", EmitDefaultValue=false)]
        public bool? AllowsScoreCollection { get; private set; }

        /// <summary>
        /// Have you visited this tile before.
        /// </summary>
        /// <value>Have you visited this tile before.</value>
        [DataMember(Name="hasBeenVisited", EmitDefaultValue=false)]
        public bool? HasBeenVisited { get; private set; }

        /// <summary>
        /// What reward is available on this tile.
        /// </summary>
        /// <value>What reward is available on this tile.</value>
        [DataMember(Name="rewardOnDestination", EmitDefaultValue=false)]
        public int? RewardOnDestination { get; private set; }

        /// <summary>
        /// The tag on this tile. NOTE: default tag is 0
        /// </summary>
        /// <value>The tag on this tile. NOTE: default tag is 0</value>
        [DataMember(Name="tagOnTile", EmitDefaultValue=false)]
        public long? TagOnTile { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MoveAction {\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  IsStart: ").Append(IsStart).Append("\n");
            sb.Append("  AllowsExit: ").Append(AllowsExit).Append("\n");
            sb.Append("  AllowsScoreCollection: ").Append(AllowsScoreCollection).Append("\n");
            sb.Append("  HasBeenVisited: ").Append(HasBeenVisited).Append("\n");
            sb.Append("  RewardOnDestination: ").Append(RewardOnDestination).Append("\n");
            sb.Append("  TagOnTile: ").Append(TagOnTile).Append("\n");
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
            return this.Equals(input as MoveAction);
        }

        /// <summary>
        /// Returns true if MoveAction instances are equal
        /// </summary>
        /// <param name="input">Instance of MoveAction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MoveAction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Direction == input.Direction ||
                    (this.Direction != null &&
                    this.Direction.Equals(input.Direction))
                ) && 
                (
                    this.IsStart == input.IsStart ||
                    (this.IsStart != null &&
                    this.IsStart.Equals(input.IsStart))
                ) && 
                (
                    this.AllowsExit == input.AllowsExit ||
                    (this.AllowsExit != null &&
                    this.AllowsExit.Equals(input.AllowsExit))
                ) && 
                (
                    this.AllowsScoreCollection == input.AllowsScoreCollection ||
                    (this.AllowsScoreCollection != null &&
                    this.AllowsScoreCollection.Equals(input.AllowsScoreCollection))
                ) && 
                (
                    this.HasBeenVisited == input.HasBeenVisited ||
                    (this.HasBeenVisited != null &&
                    this.HasBeenVisited.Equals(input.HasBeenVisited))
                ) && 
                (
                    this.RewardOnDestination == input.RewardOnDestination ||
                    (this.RewardOnDestination != null &&
                    this.RewardOnDestination.Equals(input.RewardOnDestination))
                ) && 
                (
                    this.TagOnTile == input.TagOnTile ||
                    (this.TagOnTile != null &&
                    this.TagOnTile.Equals(input.TagOnTile))
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
                if (this.Direction != null)
                    hashCode = hashCode * 59 + this.Direction.GetHashCode();
                if (this.IsStart != null)
                    hashCode = hashCode * 59 + this.IsStart.GetHashCode();
                if (this.AllowsExit != null)
                    hashCode = hashCode * 59 + this.AllowsExit.GetHashCode();
                if (this.AllowsScoreCollection != null)
                    hashCode = hashCode * 59 + this.AllowsScoreCollection.GetHashCode();
                if (this.HasBeenVisited != null)
                    hashCode = hashCode * 59 + this.HasBeenVisited.GetHashCode();
                if (this.RewardOnDestination != null)
                    hashCode = hashCode * 59 + this.RewardOnDestination.GetHashCode();
                if (this.TagOnTile != null)
                    hashCode = hashCode * 59 + this.TagOnTile.GetHashCode();
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
