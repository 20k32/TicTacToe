using Presentation.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TicTacToe.Behaviors
{
    public static class UniformSizingBehavior
    {
        private static FrameworkElement _sizeChangeElement;
        private static FrameworkElement _parentContainer;

        private const string PARENT_CONTAINER_PROPERTY_NAME = "ParentContainer";
        private const string IS_BEHAVIOR_ENABLED_PROPERTY_NAME = "IsBehaviorEnabled";

        public static readonly DependencyProperty IsBehaviorEnabledProperty = DependencyProperty.RegisterAttached(
            IS_BEHAVIOR_ENABLED_PROPERTY_NAME,
            typeof(bool),
            typeof(UniformSizingBehavior),
            new PropertyMetadata(OnUniformSizingBehaviorIsEnabledPropertyChanged));

        public static void SetIsBehaviorEnabled(UIElement target, bool value) => target.SetValue(IsBehaviorEnabledProperty, value);

        public static bool GetIsBehaviorEnabled(UIElement target) => (bool)target.GetValue(IsBehaviorEnabledProperty);

        private static void OnUniformSizingBehaviorIsEnabledPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool value)
            {
                if (value)
                {
                    _sizeChangeElement = d as FrameworkElement;

                    WindowHelper.MainWindowSizeChanged -= OnWindowHelperMainWindowSizeChanged;
                    WindowHelper.MainWindowSizeChanged += OnWindowHelperMainWindowSizeChanged;
                }
                else
                {
                    _sizeChangeElement = default;
                    WindowHelper.MainWindowSizeChanged -= OnWindowHelperMainWindowSizeChanged;
                }
            }
        }

        public static readonly DependencyProperty ParentContainerProperty = DependencyProperty.RegisterAttached(
           PARENT_CONTAINER_PROPERTY_NAME,
           typeof(FrameworkElement),
           typeof(UniformSizingBehavior),
           new PropertyMetadata(OnParentContainerPropertyChanged));

        public static void SetParentContainer(UIElement target, FrameworkElement value) => target.SetValue(ParentContainerProperty, value);

        public static FrameworkElement GetParentContainer(UIElement target) => (FrameworkElement)target.GetValue(ParentContainerProperty);

        private static void OnParentContainerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is FrameworkElement value)
            {
                _parentContainer = value;
            }
        }

        public static void OnWindowHelperMainWindowSizeChanged(Size newSize)
        {
            if (_parentContainer is not null)
            {
                var uniformSizeValue = Math.Min(_parentContainer.ActualWidth, _parentContainer.ActualHeight);

                _sizeChangeElement.Width = uniformSizeValue;
                _sizeChangeElement.Height = uniformSizeValue;
            }
        }
    }
}
