using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    public class ThemeResourceDictionary : ResourceDictionary
    {
        private Uri _themeUri;
        public Uri ThemeUr
        {
            get => this._themeUri;
            set
            {
                if (this._themeUri != value)
                {
                    if (value == null)
                    {
                        this.MergedDictionaries.Remove(this._themeResources);
                        this._themeResources = null;
                    }
                    else
                    {
                        ResourceDictionary dictionary = new ResourceDictionary() { Source = value };
                        this.MergedDictionaries.Add(dictionary);
                        this._themeResources = dictionary;
                    }

                    this._themeUri = value;
                }
            }
        }

        private ResourceDictionary _themeResources;
        public ResourceDictionary ThemeResources
        {
            get => this._themeResources;
            set
            {
                if (this._themeResources != value)
                {
                    this.MergedDictionaries.Remove(this._themeResources);

                    if (value == null)
                        this._themeUri = null;
                    else
                    {
                        this.MergedDictionaries.Add(value);
                        this._themeUri = value.Source;
                    }

                    this._themeResources = value;
                }
            }
        }

        public ThemeResourceDictionary() : base() { }

        public ThemeResourceDictionary(Uri defaultThemeUri) : this() => this.ThemeUr = defaultThemeUri;

        public ThemeResourceDictionary(ResourceDictionary defaultThemeResources) : this() => this.ThemeResources = defaultThemeResources;
    }
}
