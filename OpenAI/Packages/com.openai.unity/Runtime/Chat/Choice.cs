// Licensed under the MIT License. See LICENSE in the project root for license information.

using Newtonsoft.Json;

namespace OpenAI.Chat
{
    public sealed class Choice
    {
        [JsonConstructor]
        public Choice(
            [JsonProperty("message")] Message message,
            [JsonProperty("delta")] Delta delta,
            [JsonProperty("finish_reason")] string finishReason,
            [JsonProperty("index")] int index)
        {
            Message = message;
            Delta = delta;
            FinishReason = finishReason;
            Index = index;
        }

        [JsonProperty("message")]
        public Message Message { get; internal set; }

        [JsonProperty("delta")]
        public Delta Delta { get; internal set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; internal set; }

        [JsonProperty("index")]
        public int Index { get; internal set; }

        public override string ToString() => Message?.Content ?? Delta?.Content ?? string.Empty;

        public static implicit operator string(Choice choice) => choice.ToString();

        internal void CopyFrom(Choice other)
        {
            if (other?.Message != null)
            {
                Message = other.Message;
            }

            if (other?.Delta != null)
            {
                if (Message == null)
                {
                    Message = new Message(other.Delta);
                }
                else
                {
                    Message.CopyFrom(other.Delta);
                }
            }

            if (!string.IsNullOrWhiteSpace(other?.FinishReason))
            {
                FinishReason = other.FinishReason;
            }

            Index = other?.Index ?? 0;
        }
    }
}
