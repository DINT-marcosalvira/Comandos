﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Comandos
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(CustomCommands), new InputGestureCollection()
        {
            new  KeyGesture(Key.S, ModifierKeys.Control)
        });

        public static readonly RoutedUICommand Clear = new RoutedUICommand("Clear", "Clear", typeof(CustomCommands), new InputGestureCollection()
        {
            new  KeyGesture(Key.V, ModifierKeys.Alt)
        });
        
    }
}
