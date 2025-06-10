using System.Globalization;

namespace SmartRun.Domain.ValueObjects;

public readonly struct FirstNameValueObject
{
    private readonly string? FirstName { get; }

    public const int MaxLength = 64;

    private FirstNameValueObject(string? firstName)
    {
        FirstName = firstName;
    }

    public static FirstNameValueObject Factory(string? firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty.");

        if (firstName.Length > MaxLength)
            throw new ArgumentException($"First name cannot exceed {MaxLength} characters.", nameof(firstName));

        if (firstName.Length < 1)
            throw new ArgumentException($"First name must be at least 1 character long.", nameof(firstName));

        string formattedFirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName.ToLower());

        return new FirstNameValueObject(formattedFirstName);
    }

    public override string ToString() => FirstName!;

    public static implicit operator string(FirstNameValueObject firstName) => firstName.FirstName!;
    public static implicit operator FirstNameValueObject(string firstName) => Factory(firstName);
}
