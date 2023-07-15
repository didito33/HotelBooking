namespace HotelBooking.Common
{
    static public class DataConstants
    {

        public static class CategoryConstants
        {
            public const int NameMaxLength = 50;
        }
        //Category constants

        //Hotel constants
        public static class HotelConstants
        {
            public const int HotelNameMinLength = 10;
            public const int HotelNameMaxLength = 50;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
        }
        public static class RoomConstants
        {
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const double PricePerDayMin = 0;
            public const double PricePerDayMax = 5000;
        }
    }
}
