using System.Net;
using System.Security;

namespace Share;

/// <summary>
/// Secure String Extension
/// </summary>
public static class SecureStringExtension
{
    /// <summary>
    /// Convert string to secure string
    /// </summary>
    /// <param name="input">Input</param>
    /// <returns>Secure String</returns>
    public static SecureString ToSecureString(this string input)
    {
        var credential = new NetworkCredential("", input);
        return credential.SecurePassword;
    }

    /// <summary>
    /// Convert secure string to plain string
    /// </summary>
    /// <param name="secureInput">Secure Input</param>
    /// <returns>Plain String</returns>
    public static string ToUnsecureString(this SecureString secureInput)
    {
        var credential = new NetworkCredential("", secureInput);
        return credential.Password;
    }
}