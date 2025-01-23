namespace Domain.ValueObjects
{
    public class Address
    {
        public int Address_ID {  get;} 
        public int PLZ { get;}
        public string Town { get;}
        public string Street { get;}
        public string House_Number { get;}

        public Address(int plz, string town, string street, string house_Number) 
        {

            PLZ = plz;
            Town= town;
            Street= street;
            House_Number= house_Number;
        }
        public Address(int address_ID,int plz, string town, string street, string house_Number)
        {

            Address_ID=address_ID;
            PLZ = plz;
            Town = town;
            Street = street;
            House_Number = house_Number;
        }

        private void _ValidateAddressData()
        {
            // Validate the Address and then Trow InvalidAddressException





        }


    }
}
