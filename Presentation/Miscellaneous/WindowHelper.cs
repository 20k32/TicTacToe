using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Presentation.Miscellaneous
{
    public static class WindowHelper
    {
        private static Window mainWindow;

        public static event Action<Size> MainWindowSizeChanged;
        public static event Action Loaded;

        public static Window MainWindow
        {
            get => mainWindow;
            set
            {
                mainWindow = value;

                mainWindow.SizeChanged += OnMainWindowSizeChanged;
                mainWindow.Loaded += OnMainWindowLoaded;
                mainWindow.Closing += OnMainWindowClosing;
            }
        }

        private static void OnMainWindowClosing(object sender, CancelEventArgs e)
        {
            if (sender is Window window)
            {
                window.Closing -= OnMainWindowClosing;
                window.Loaded -= OnMainWindowLoaded;
                window.SizeChanged -= OnMainWindowSizeChanged;
            }
        }

        private static void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is Window window)
            {
                Loaded?.Invoke();
            }
        }

        private static void OnMainWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is Window window)
            {
                MainWindowSizeChanged?.Invoke(e.NewSize);
            }
        }
    }
}
