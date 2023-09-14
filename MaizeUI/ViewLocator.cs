using Avalonia.Controls;
using Avalonia.Controls.Templates;
using MaizeUI.ViewModels;
using System;

namespace MaizeUI
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data == null)
            {
                return null; // Or you might want to return a default Control here
            }

            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control?)Activator.CreateInstance(type);
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
