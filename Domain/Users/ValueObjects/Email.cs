using System.Text.RegularExpressions;
using Domain.Base;

namespace Domain.Users.ValueObjects;

public sealed class Email : ValueObject<Email>
{
    public readonly string EmailAddress;

    private Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public static Result<Email> Create(string emailAddress)
    {
        emailAddress = emailAddress.Trim();

        if (string.IsNullOrWhiteSpace(emailAddress))
        {
            return Result.Failure<Email>("Email should not be empty");
        }

        if (emailAddress.Length >= 256)
        {
            return Result.Failure<Email>("Email is too long");
        }

        if (!IsEmailValid(emailAddress))
        {
            return Result.Failure<Email>($"Email {emailAddress} is not valid");
        }

        return Result.Success(new Email(emailAddress));
    }

    protected override bool EqualsCore(Email other)
    {
        return EmailAddress.Equals(other.EmailAddress, StringComparison.InvariantCultureIgnoreCase);
    }

    protected override int GetHashCodeCore()
    {
        return EmailAddress.GetHashCode();
    }

    public static explicit operator Email(string emailAddress)
    {
        return Create(emailAddress).Value;
    }

    public static implicit operator string(Email email)
    {
        return email.EmailAddress;
    }

    private static bool IsEmailValid(string emailAddress)
    {
        const string pattern = @"^(.+)@(.+)$";
        const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        var matchTimeout = TimeSpan.FromSeconds(2);

        var regex = new Regex(pattern, options, matchTimeout);
        return regex.IsMatch(emailAddress);
    }


}