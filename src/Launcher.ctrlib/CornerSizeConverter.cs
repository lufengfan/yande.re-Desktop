using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    /// <summary>
    /// 提供在 <see cref="CornerSize"/> 与其他类型之间来回转换功能的转换器。
    /// </summary>
    public class CornerSizeConverter : TypeConverter
    {
        /// <summary>
        /// 初始化 <see cref="CornerSizeConverter"/> 类的新实例。
        /// </summary>
        public CornerSizeConverter() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            switch (Type.GetTypeCode(sourceType))
            {
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                case TypeCode.String:
                    return true;
                case TypeCode.Object:
                    if (sourceType == typeof(Size)) return true;
                    else return false;
                default: return false;
            }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
                throw this.GetConvertFromException(value);
            else if (value is string)
                return CornerSizeConverter.FromString((string)value, culture);
            else
            {
                double d = Convert.ToDouble(value, culture);
                return new CornerSize(new Size(d, d));
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (destinationType == null) throw new ArgumentNullException(nameof(destinationType));

            if (!(value is CornerSize)) throw new ArgumentException($"意外的转换源类型： {{{value.GetType()}}} （应为 {{{typeof(CornerSize)}}} 。）", nameof(value));

            CornerSize cs = (CornerSize)value;
            if (destinationType == typeof(string))
                return CornerSizeConverter.ToString(cs, culture);
            else if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo constructor = typeof(CornerSize)
                    .GetConstructor(new Type[]
                    {
                        typeof(Size),
                        typeof(Size),
                        typeof(Size),
                        typeof(Size)
                    });

                return new InstanceDescriptor(constructor, new object[]
                {
                    cs.TopLeft,
                    cs.TopRight,
                    cs.BottomRight,
                    cs.BottomLeft
                });
            }
            else
                throw new ArgumentException($"无法自类型 {{{typeof(CornerSize)}}} 转换为类型 {{{destinationType}}} 。");
        }

        internal static CornerSize FromString(string s, CultureInfo cultureInfo)
        {
            Regex specialCornerSizeRegex = new Regex($@"^\s*(?<Size>\S+?)\s*(?<Position>[tb][lr]|(top|bottom)(left|right))\s*(?<TransformType>[rm]|rotate|mirror)?\s*$", RegexOptions.IgnoreCase);
            Match specialCornerSizeMatch = specialCornerSizeRegex.Match(s);
            if (specialCornerSizeMatch.Success)
            {
                try
                {
                    Size size = Size.Parse(specialCornerSizeMatch.Groups["Size"].Value);

                    Group gTransformType = specialCornerSizeMatch.Groups["TransformType"];
                    bool isRotate = gTransformType.Success &&
                        (gTransformType.Value.ToLower() == "rotate" || gTransformType.Value.ToLower() == "r");
                    if (isRotate)
                    {
                        Size sizeTransformed = new Size(size.Height, size.Width);

                        switch (specialCornerSizeMatch.Groups["Position"].Value.ToLower())
                        {
                            case "tl": case "topleft":
                            case "br": case "bottomright":
                                return new CornerSize(size, sizeTransformed, size, sizeTransformed);
                            case "tr": case "topright":
                            case "bl": case "bottomleft":
                                return new CornerSize(sizeTransformed, size, sizeTransformed, size);
                            default:
                                System.Diagnostics.Trace.Assert(true, "未添加支持的位置条件。");
                                break;
                        }
                    }
                    else
                        return new CornerSize(size);
                }
                catch (Exception) { }
            }

            string[] ss = s.Split().Where(_s => _s != string.Empty).ToArray();
            
            FormatException formatException = new FormatException($"错误的 {nameof(CornerSize)} 格式。");
            Size parseSource(string source, bool isExactSize = false)
            {
                try
                {
                    return Size.Parse(source);
                }
                catch (Exception) { }

                if (!isExactSize && double.TryParse(source, out double d))
                    return new Size(d, d);
                else
                    throw formatException;
            }
            if (ss.Length == 1)
                return new CornerSize(parseSource(ss[0]));
            else if (ss.Length == 4)
                return new CornerSize(
                    parseSource(ss[0], true),
                    parseSource(ss[1], true),
                    parseSource(ss[2], true),
                    parseSource(ss[3], true)
                );
            else
                throw formatException;
        }

        internal static string ToString(CornerSize cornerSize, CultureInfo cultureInfo)
        {
            char numericListSeparator = ' ';
            return string.Join(numericListSeparator.ToString(),
                new[]
                {
                    cornerSize.TopLeft,
                    cornerSize.TopRight,
                    cornerSize.BottomRight,
                    cornerSize.BottomLeft
                }
                    .Select(size => size.ToString())
            );
        }
    }
}
