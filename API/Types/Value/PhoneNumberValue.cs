using System.Text.RegularExpressions;
using Fiicode25Auth.API.Exceptions;

namespace Fiicode25Auth.API.Types.Value;

public class PhoneNumberValue : IEquatable<PhoneNumberValue>
{
    public string Value { get; }
    
    private const string DefaultCountryCode = "40";
    
    public static PhoneNumberValue Create(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new PhoneNumberFormatException("Phone number cannot be empty");

        string cleaned = Regex.Replace(phoneNumber, @"[^\d+]", "");

        if (cleaned.StartsWith("+"))
        {
            if (!Regex.IsMatch(cleaned, @"^\+\d{7,15}$"))
                throw new PhoneNumberFormatException($"Invalid phone number format. E.164 requires a + followed by 7-15 digits. Number provided has {cleaned.Length - 1} digits.");
            
            return new PhoneNumberValue(cleaned);
        }
        else
        {
            if (cleaned.Length > 15 || cleaned.Length < 7)
                throw new PhoneNumberFormatException($"Invalid phone number format. Number without country code should be 7-15 digits. Number provided has {cleaned.Length} digits.");
            
            if (cleaned.StartsWith(DefaultCountryCode))
            {
                var withPlus = "+" + cleaned;
                if (withPlus.Length > 16)
                    throw new PhoneNumberFormatException($"Phone number is too long. E.164 allows a maximum of 15 digits after the +.");
                
                return new PhoneNumberValue(withPlus);
            }
            
            var formatted = "+" + DefaultCountryCode + cleaned;
            if (formatted.Length > 16)
                throw new PhoneNumberFormatException($"Phone number is too long. With country code (+{DefaultCountryCode}), it's larger than the 15 digit limit of E.164.");
            
            return new PhoneNumberValue(formatted);
        }
    }

    public static PhoneNumberValue FromE164(string validE164Number)
    {
        if (string.IsNullOrWhiteSpace(validE164Number))
            throw new PhoneNumberFormatException("Phone number cannot be empty");
        
        if (!Regex.IsMatch(validE164Number, @"^\+\d{7,15}$"))
            throw new PhoneNumberFormatException("Phone number must be E.164");
            
        return new PhoneNumberValue(validE164Number);
    }

    private PhoneNumberValue(string value)
    {
        Value = value;
    }

    public override string ToString() => Value;

    public bool Equals(PhoneNumberValue? other)
    {
        if (other is null)
            return false;
            
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is PhoneNumberValue other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(PhoneNumberValue? left, PhoneNumberValue? right)
    {
        if (left is null)
            return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(PhoneNumberValue? left, PhoneNumberValue? right)
    {
        return !(left == right);
    }
    
    public static implicit operator string(PhoneNumberValue phoneNumber) => phoneNumber.Value;
}
