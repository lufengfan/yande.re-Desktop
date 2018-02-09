using Launcher.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Yandere;
using Yandere.ComponentModel;

namespace Launcher
{
    public static class LauncherTheme
    {
        internal sealed class ResourceKeyClass : ResourceKey
        {
            internal string key;

            public override Assembly Assembly => null;

            public ResourceKeyClass(string key) =>
                this.key = key ?? throw new ArgumentNullException(nameof(key));

            public override string ToString() => this.key;
        }

        private static ValueBox<Brush> borderBrushBox = new ValueBox<Brush>(null);
        public static Brush BorderBrush
        {
            get => borderBrushBox.Value;
            private set
            {
                if (!borderBrushBox.HasValue || borderBrushBox.Value != value)
                {
                    borderBrushBox.Value = value;
                    notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }
        public static string BorderBrushKey { get; } = new ResourceKeyClass(nameof(BorderBrush)).key;

        private static ValueBox<double> blurRadiusBox = new ValueBox<double>(10D);
        public static double BlurRadius
        {
            get => blurRadiusBox.Value;
            private set
            {
                if (!blurRadiusBox.HasValue || blurRadiusBox.Value != value)
                {
                    blurRadiusBox.Value = value;
                    notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }
        public static string BlurRadiusKey { get; } = new ResourceKeyClass(nameof(BlurRadius)).key;

        private static ValueBox<Color> dropShadowColorBox = new ValueBox<Color>(Colors.Transparent);
        public static Color DropShadowColor
        {
            get => dropShadowColorBox.Value;
            private set
            {
                if (!dropShadowColorBox.HasValue || dropShadowColorBox.Value != value)
                {
                    dropShadowColorBox.Value = value;
                    notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }
        public static string DropShadowColorKey { get; } = new ResourceKeyClass(nameof(DropShadowColor)).key;

        private static ValueBox<ItemsViewType> postThumbShowStyleBox = new ValueBox<ItemsViewType>(ItemsViewType.Grid);
        public static ItemsViewType PostThumbShowStyle
        {
            get => postThumbShowStyleBox.Value;
            private set
            {
                if (!postThumbShowStyleBox.HasValue || postThumbShowStyleBox.Value != value)
                {
                    postThumbShowStyleBox.Value = value;
                    notifyPropertyChanged.OnPropertyChanged();
                }
            }
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;
        private static NotifyPropertyChanged notifyPropertyChanged;

        static LauncherTheme()
        {
            notifyPropertyChanged = new NotifyPropertyChanged(null);
            notifyPropertyChanged.PropertyChanged += (sender, e) => StaticPropertyChanged?.Invoke(sender, e);

            LauncherTheme.LoadTheme(new Uri("pack://application:,,,/Launcher;component/Themes/Default.xaml"));
        }

        public static void LoadTheme(ResourceDictionary dictionary)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            bool TryGetValue(object key, out object value)
            {
                if (dictionary.Contains(key))
                {
                    value = dictionary[key];
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }

            object _value;
            if (TryGetValue(nameof(BorderBrush), out _value))
                BorderBrush = (Brush)_value;
            if (TryGetValue(nameof(BlurRadius), out _value))
                BlurRadius = (double)_value;
            if (TryGetValue(nameof(DropShadowColor), out _value))
                DropShadowColor = (Color)_value;
        }

        public static void LoadTheme(Uri themeUri)
        {
            ResourceDictionary dictionary = new ResourceDictionary() { Source = themeUri };
            LoadTheme(dictionary);
        }
    }
}
