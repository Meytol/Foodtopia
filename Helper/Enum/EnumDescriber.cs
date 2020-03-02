using System.ComponentModel;

namespace Common.Helper.Enum
{
    public static class EnumDescriber
    {
        public static string Text(this System.Enum x)
        {
            var type = x.GetType();
            var memberInfos = type.GetMember(x.ToString());
            var attributes = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }
    }
}