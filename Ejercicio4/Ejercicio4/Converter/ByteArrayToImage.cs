﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;

namespace Ejercicio4.Converter
{
    public class ByteArrayToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSource = null; //Se valida que el objeto  a convertir no vallan a ser nulos
            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }
            return retSource;
        }

        public object ConvertBack(object value,
               Type targetType,
               object parameter,
               System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}

