using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratoria.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View1 : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
    propertyName: nameof(Title),
    returnType: typeof(string),
    declaringType: typeof(ContentWithHeader),
    defaultValue: null);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty ControlContentProperty = BindableProperty.Create(
    propertyName: nameof(ControlContent),
    returnType: typeof(string),
    declaringType: typeof(ContentWithHeader),
    defaultValue: null);

        public string ControlContent

        {
            get { return (string)GetValue(ControlContentProperty); }
            set { SetValue(ControlContentProperty, value); }
        }

        public View1()
        {
            InitializeComponent();
        }
    }
}