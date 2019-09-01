using System.Globalization;

namespace CarList
{
    class ValueConverter
    {
        public string Convert(double input)
        {
            //CultureInfo culture = new CultureInfo("nl-BE");
            //CultureInfo.DefaultThreadCurrentCulture = culture;

            return input.ToString("C2", CultureInfo.DefaultThreadCurrentCulture);

        }
    }
}
