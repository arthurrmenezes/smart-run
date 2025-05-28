using System.Text.Json.Serialization;

namespace SmartRun.Domain.BoundedContexts.TrainingContext.ENUMs;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LocationType
{
    GYM = 0,
    PARK = 1,
    TRACK = 2
}
