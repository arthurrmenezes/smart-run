using System.Text.RegularExpressions;

namespace SmartRun.Domain.ValueObjects;

public readonly struct EmailValueObject
{
    public readonly string? Email { get; }
    public const int MaxLength = 255;

    private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    private EmailValueObject(string email)
    {
        Email = email;
    }

    public static EmailValueObject Factory(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email), "Email cannot be null or empty.");

        if (email.Length > MaxLength)
            throw new ArgumentException($"Email cannot exceed {MaxLength} characters.", nameof(email));

        if (!_emailRegex.IsMatch(email))
            throw new ArgumentException("Email format is invalid.", nameof(email));

        return new EmailValueObject(email.ToLower());
    }

    public override string ToString() => Email!;

    public static implicit operator string(EmailValueObject email) => email.Email!;
    public static implicit operator EmailValueObject(string email) => Factory(email);
}
