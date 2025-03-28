namespace SysAdminMvc.Entities.ValueObjects;

public class Email
{
    public string Value { get; private set; }

    private Email(string value)
    {
        Value = value;
    }

    private Email()
    {
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value));

        if (!value.Contains("@"))
            throw new ArgumentException("Invalid email format");

        return new Email(value);
    }
}