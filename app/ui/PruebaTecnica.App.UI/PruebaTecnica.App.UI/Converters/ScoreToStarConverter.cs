using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace PruebaTecnica.App.UI.Converters
{
    public class ScoreToStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal scoreDecimal)
            {
                int score = (int)scoreDecimal;

                List<ImageSource> stars = new List<ImageSource>();

                for (int i = 0; i < score; i++)
                {
                    stars.Add(ImageSource.FromFile("star.png"));
                }

                return stars;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
