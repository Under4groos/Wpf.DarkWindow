using System.Windows;

namespace Wpf.DarkWindow.Helper
{
    public static class SysDependencyProperty<T>
    {

        public static DependencyProperty RegisterA(string name, Type propertyType, Type ownerType, Action<T, DependencyPropertyChangedEventArgs> EventArgs)
        {

            return DependencyProperty.Register(
               name,
               propertyType,
               ownerType,
               new FrameworkPropertyMetadata((DependencyObject d, DependencyPropertyChangedEventArgs e) =>
               {
                   if (d is T t)
                   {
                       EventArgs?.Invoke(t, e);
                   }
               }));

        }
        public static DependencyProperty RegisterW(string name, Type propertyType, Type ownerType, object value, Action<T, DependencyPropertyChangedEventArgs> EventArgs)
        {

            return DependencyProperty.Register(
               name,
               propertyType,
               ownerType,
               new FrameworkPropertyMetadata(value, (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
               {
                   if (d is T t)
                   {
                       EventArgs?.Invoke(t, e);
                   }
               }));

        }
    }
}
