using System.Text.Json.Serialization;

namespace Loans.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LoanType
{
    NONE = 0,
    PERSONAL,
    GUARANTEED,
    CONSIGNMENT,
}


