namespace Coords.Domain.Errors
{
    public static class CreateCoordErrors
    {
        public static string DetailsRequired => "Details is required.";
        public static string LatitudeRequired => "Latitude is required.";
        public static string LongitudeRequired => "Longitude is required.";
        public static string PhoneNumberRequired => "PhoneNumber is required.";
        public static string PhoneNumberLength => "PhoneNumber must be equal to 13 characters.";
        public static string PhoneNumberInvalid => "PhoneNumber is not valid.";
    }
}
