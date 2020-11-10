using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestCustomControlChildContent
{
    public partial class CustomPopupLayoutControl : ContentView
    {
        public CustomPopupLayoutControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ButtonClickCommandProperty =
            BindableProperty.Create(nameof(ButtonClickCommand), typeof(ICommand), typeof(CustomPopupLayoutControl));

        public ICommand ButtonClickCommand
        {
            get => (ICommand)GetValue(ButtonClickCommandProperty);
            set => SetValue(ButtonClickCommandProperty, value);
        }

        public static BindableProperty ButtonClickParameterProperty =
            BindableProperty.Create(nameof(ButtonClickParameter), typeof(object), typeof(CustomPopupLayoutControl));

        public object ButtonClickParameter
        {
            get => (object)GetValue(ButtonClickParameterProperty);
            set => SetValue(ButtonClickParameterProperty, value);
        }


        public static BindableProperty ButtonTitleProperty =
            BindableProperty.Create(nameof(ButtonTitle), typeof(object), typeof(CustomPopupLayoutControl), string.Empty);

        public string ButtonTitle
        {
            get => (string)GetValue(ButtonTitleProperty);
            set => SetValue(ButtonTitleProperty, value);
        }


        public static BindableProperty ChildLayoutProperty =
            BindableProperty.Create(nameof(ChildLayout), typeof(View), typeof(CustomPopupLayoutControl), propertyChanged: OnChildLayoutChanged);

        public View ChildLayout
        {
            get => (View)GetValue(ChildLayoutProperty);
            set => SetValue(ChildLayoutProperty, value);
        }

        static void OnChildLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Property changed implementation goes here

            var Custom = bindable as CustomPopupLayoutControl;

            //child is the value that pass from viewmodel
            var child = newValue as View;

            // do something you want , like add it to stacklayout
            var stack = Custom.Inner as StackLayout;

            stack.Children.Add(child);
        }
    }
}
