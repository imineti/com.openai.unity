// Licensed under the MIT License. See LICENSE in the project root for license information.

using Newtonsoft.Json;

namespace OpenAI.Chat
{
    public sealed class Delta
    {
        [JsonConstructor]
        public Delta(
            [JsonProperty("role")] Role role,
            [JsonProperty("content")] string content)
        {
            Role = role;
            Content = content;
        }

        [JsonProperty("role")]
        public Role Role { get; }

        [JsonProperty("content")]
        public string Content { get; }

        public override string ToString() => Content;
    }
}