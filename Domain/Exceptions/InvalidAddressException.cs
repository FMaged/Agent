namespace Domain.Exceptions
{
    [Serializable]
    internal class InvalidAddressException : DomainException
    {
        public InvalidAddressException(string message, string errorCode) : base(message, errorCode) 
        { 
        }


        public InvalidAddressException(string message, string errorCode ,Exception InnerException): base(message,errorCode, InnerException) 
        {
        }

        public static InvalidAddressException MissingStreet()
                => new InvalidAddressException("Street name is required",
                                               "ADDRESS_MISSING_STREET");
        public static InvalidAddressException MissingPLZ()
               => new InvalidAddressException("PLZ name is required",
                                              "ADDRESS_MISSING_PLZ");
        public static InvalidAddressException MissingHouseNumber()
        => new InvalidAddressException("House Number is required",
                                       "ADDRESS_MISSING_HOUSE_NUMBER");
        public static InvalidAddressException MissingTown()
               => new InvalidAddressException("Town name is required",
                                               "ADDRESS_MISSING_TOWN");




        public static InvalidAddressException InvalidPLZ(string PLZ)
            => new InvalidAddressException($"Postal code '{PLZ}' is invalid",
                                            "ADDRESS_INVALID_POSTAL_CODE");

        public static InvalidAddressException InvalidStreet(string street)
            => new InvalidAddressException($"Street '{street}' is not supported",
                                            "ADDRESS_INVALID_STREET");
        public static InvalidAddressException InvalidHouseNumber(string houseNumber)
            => new InvalidAddressException($"HouseNumber '{houseNumber}' is invalid",
                                            "ADDRESS_INVALID_HOUSE_NUMBER");
        public static InvalidAddressException InvalidTown(string town)
            => new InvalidAddressException($"Town '{town}' is Invalid",
                                            "ADDRESS_INVALID_TOWN");

    }

}
