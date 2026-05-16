using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Core
{
    public static class Constants
    {
        private const string CROSS_RESOURCE_NAME = "Cross";
        private const string CIRCLE_RESOURCE_NAME = "Circle";

        public static Geometry Cross { get; private set; }
        public static Geometry Circle { get; private set; }

        public static void InitializeConstantsOnUiThread()
        {
            Cross = Application.Current.Resources[CROSS_RESOURCE_NAME] as Geometry;
            Circle = Application.Current.Resources[CIRCLE_RESOURCE_NAME] as Geometry;
        }
    }
}
