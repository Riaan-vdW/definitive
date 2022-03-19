using System.Reflection;

namespace Share;

/// <summary>
/// Enum Extension
/// </summary>
public static class Enums
{
    /// <summary>
    /// Get the Enum Description
    /// </summary>
    /// <param name="enumValue">Enum Value</param>
    /// <returns>Description</returns>
    public static string Description(this Enum enumValue)
    {
        string desc = "";

        try
        {
            var descAtt = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<EnumDescriptionAttribute>()?
                .Description;

            desc = descAtt ?? enumValue.ToString().ToSplitCamelCase();
        }
        catch { }

        return desc;
    }

    /// <summary>
    /// Get the Enum Code
    /// </summary>
    /// <param name="enumValue">Enum Value</param>
    /// <returns>Code</returns>
    public static string Code(this Enum enumValue)
    {
        string desc = "";

        try
        {
            var code = enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<EnumCodeAttribute>()?
                        .Code;

            desc = code ?? string.Empty;
        }
        catch { }

        return desc;
    }

    /// <summary>
    /// Get Enum Guid
    /// </summary>
    /// <param name="enumValue">Enum Value</param>
    /// <returns>Guid</returns>
    public static Guid Guid(this Enum enumValue)
    {
        Guid guid = System.Guid.Empty;

        try
        {
            var guidValue = enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<EnumGuidAttribute>()?
                    .Guid;

            if (guidValue != null)
            {
                guid = guidValue.Value;
            }
        }
        catch { }

        return guid;
    }

    /// <summary>
    /// Parse Enum from Code
    /// </summary>
    /// <typeparam name="T">Enum Type</typeparam>
    /// <param name="code">Code</param>
    /// <returns>Enum of type T</returns>
    public static T ParseFromCode<T>(string code) where T : Enum
    {
        var enumType = typeof(T);
        var enums = Enum.GetValues(enumType)
                .Cast<int>()
                .Select(e => Enum.ToObject(enumType, e))
                .Select(s => (Enum)s)
                .Where(w => w.Code().Equals(code, StringComparison.CurrentCultureIgnoreCase))
                .Select(s => s.ToString())
                .ToList();

        if (enums.Count > 1)
            throw new Exception("Could not parse enum, to many matching Codes");

        if (enums.Count == 0)
            throw new Exception("Could not parse enum from Code");

        var enumName = enums.First();
        return (T)Enum.Parse(enumType, enumName);
    }

    /// <summary>
    /// Parse enum from Guid
    /// </summary>
    /// <typeparam name="T">Enum Type</typeparam>
    /// <param name="guid">Guid</param>
    /// <returns>Enum of type T</returns>
    public static T ParseFromGuid<T>(Guid guid) where T : Enum
    {
        var enumType = typeof(T);
        var enums = Enum.GetValues(enumType)
                .Cast<int>()
                .Select(e => Enum.ToObject(enumType, e))
                .Select(s => (Enum)s)
                .Where(w => w.Guid() == guid)
                .Select(s => s.ToString())
                .ToList();

        if (enums.Count > 1)
            throw new Exception("Could not parse enum, to many matching Guids");

        if (enums.Count == 0)
            throw new Exception("Could not parse enum from Guid");

        var enumName = enums.First();
        return (T)Enum.Parse(enumType, enumName);
    }

    /// <summary>
    /// Parse enum form Description
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="description"></param>
    /// <returns></returns>
    public static T ParseFromDescription<T>(string description) where T : Enum
    {
        var enumType = typeof(T);
        var enums = Enum.GetValues(enumType)
                .Cast<int>()
                .Select(e => Enum.ToObject(enumType, e))
                .Select(s => (Enum)s)
                .Where(w => w.Description() == description)
                .Select(s => s.ToString())
                .ToList();

        if (enums.Count > 1)
            throw new Exception("Could not parse enum, to many matching Descriptions");

        if (enums.Count == 0)
            throw new Exception("Could not parse enum from Description");

        var enumName = enums.First();
        return (T)Enum.Parse(enumType, enumName);
    }

    /// <summary>
    /// List all enum items
    /// </summary>
    /// <returns>List of enum items</returns>
    public static IReadOnlyList<EnumItem<T>> ToList<T>()
    {
        var tmpEnum = default(T)!;
        if (tmpEnum != null && tmpEnum.GetType().IsEnum)
        {
            var enumType = typeof(T);

            return Enum.GetValues(enumType)
                .Cast<int>()
                .Select(e => new { value = Enum.ToObject(enumType, e) })
                .Select(s => (Enum)s.value)
                .Select(s => new EnumItem<T>((T)(object)s, s.ToString(), s.Description(), s.Code(), s.Guid()))
                .OrderBy(o => o.Value)
                .ToList();
        }
        else
        {
            return new List<EnumItem<T>>();
        }
    }
}