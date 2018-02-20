using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Yandere.ComponentModel;
using Yandere.Data;

namespace Launcher.Pages
{
    internal sealed class IsTagUsedConverterParameter : DependencyObject, INotifyPropertyChanged
    {
        #region OriginalTags
        public static readonly DependencyProperty OriginalTagsProperty =
            DependencyProperty.Register(
                nameof(IsTagUsedConverterParameter.OriginalTags), typeof(string), typeof(IsTagUsedConverterParameter),
                new PropertyMetadata(
                    string.Empty,
                    null,
                    IsTagUsedConverterParameter.OriginalTagsCoerceValue
                )
            );

        private static object OriginalTagsCoerceValue(DependencyObject d, object baseValue) => (baseValue as string) ?? string.Empty;

        public string OriginalTags
        {
            get => (string)this.GetValue(IsTagUsedConverterParameter.OriginalTagsProperty);
            set => this.SetValue(IsTagUsedConverterParameter.OriginalTagsProperty, value);
        }
        #endregion

        #region Tag
        public static readonly DependencyProperty TagProperty =
            DependencyProperty.Register(nameof(IsTagUsedConverterParameter.Tag), typeof(YandereTag), typeof(IsTagUsedConverterParameter), new PropertyMetadata(null));

        public YandereTag Tag
        {
            get => (YandereTag)this.GetValue(IsTagUsedConverterParameter.TagProperty);
            set => this.SetValue(IsTagUsedConverterParameter.TagProperty, value);
        }
        #endregion

        #region Other
        public static readonly DependencyProperty OtherProperty =
            DependencyProperty.Register(nameof(IsTagUsedConverterParameter.Other), typeof(object), typeof(IsTagUsedConverterParameter), new PropertyMetadata(null));

        public object Other
        {
            get => (object)this.GetValue(IsTagUsedConverterParameter.OtherProperty);
            set => this.SetValue(IsTagUsedConverterParameter.OtherProperty, value);
        }
        #endregion

        public IsTagUsedConverterParameter()
        {
            this.notifyPropertyChanged = new NotifyPropertyChanged(this);
        }

        private NotifyPropertyChanged notifyPropertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.notifyPropertyChanged.PropertyChanged += value;
            remove => this.notifyPropertyChanged.PropertyChanged -= value;
        }
    }

    internal class IsTagUsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is IsTagUsedConverterParameter param)
            {
                string tags = (string)value;
                if (YandereTagCollection.TryParse(tags, out YandereTagCollection collection) && param.Tag != null)
                    return collection.Contains(param.Tag);
            }
            
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is IsTagUsedConverterParameter param)
            {
                bool isUsed = (bool)value;
                if (YandereTagCollection.TryParse(param.OriginalTags, out YandereTagCollection collection) && param.Tag != null)
                {
                    if (isUsed)
                        collection.Add(param.Tag);
                    else
                        collection.Remove(param.Tag);

                    return collection.ToString();
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
