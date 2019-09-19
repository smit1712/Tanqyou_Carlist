using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
namespace CarList
{
    class ValidateLicensePlateBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: "Command", returnType: typeof(ICommand), declaringType: typeof(ValidateLicensePlateBehavior));
        const string KentegenRegex = @"^(\w{1,3}-\w{1,3}-\w{1,3})$";

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(ValidateLicensePlateBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        //public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValidProperty", typeof(bool), typeof(ValidateLicensePlateBehavior), null);
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.BindingContextChanged +=
              (sender, _) => this.BindingContext = ((BindableObject)sender).BindingContext;

            bindable.TextChanged += HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, KentegenRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;

        }
    }

}

