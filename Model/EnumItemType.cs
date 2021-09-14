using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using static csharp.Utils.ListExtensions;

namespace csharp.Model
{
    public enum EnumItemType
    {
        [Description("Aged Brie")]
        AGED_BRIE,
        [Description("Backstage passes")]
        BACKSTAGE_PASSES,
        [Description("Sulfuras")]
        SULFURAS,
        [Description("Default")]
        SIMPLE
    }

    public static class EnumUtils
    {
        public static EnumItemType ToEnum(string Name)
        {
            return Enum.GetValues(typeof(EnumItemType))
                .Cast<EnumItemType?>()
                .ToList()
                .Where(o => Name.ToUpper().Contains(GetEnumDescription((EnumItemType)o).ToUpper()))
                .FirstOrDefault()
                .IfDefaultGiveMe(EnumItemType.SIMPLE).Value;
        }

        private static string GetEnumDescription(EnumItemType EnumItemType)
        {
            return (EnumItemType.GetType()
                                .GetTypeInfo()
                                .GetMember(EnumItemType.ToString())
                                .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                .SingleOrDefault()
                                as DescriptionAttribute)
                                .Description;
        }
    } 
}