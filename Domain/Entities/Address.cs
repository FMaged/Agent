using Domain.Exceptions;
using Domain.Events;

namespace Domain.Entities;



//Why storing it in the Database with ID
public class Address : BaseEntity<int>
{
    public override int Id => Address_ID;
    public int Address_ID { get; private set; }
    public string PLZ { get; private set; }
    public string Town { get; private set; }
    public string Street { get; private set; }
    public string House_Number { get; private set; }

    private Address()
    {
        Address_ID = default!;
        PLZ = default!;
        Town = default!;
        Street = default!;
        House_Number = default!;

    }
    public static Address Create(string plz, string town, string street, string houseNumber)
    {
        Validate(plz, town, street, houseNumber);
        return new Address
        {
            PLZ = plz.Trim(),
            Town = town.Trim(),
            Street = street.Trim(),
            House_Number = houseNumber.Trim()
        };
    }
    public static Address FromDatabase(int id, string plz, string town, string street, string houseNumber)
    {
        return new Address
        {
            Address_ID = id,
            PLZ = plz,
            Town = town,
            Street = street,
            House_Number = houseNumber
        };
    }

    public void UpdateAddress(string plz, string town, string street, string houseNumber, int Id= 0)
    {
        Address oldAddress = this;
        Validate(plz, town, street, houseNumber);
        PLZ = plz;
        Town = town;
        Street = street;
        House_Number = houseNumber;




        AddDomainEvent(new AddressChangedEvent(oldAddress, this));
    }



    private static void Validate(string plz, string town, string street, string houseNumber,int Id= 0)
    {
        
        if (string.IsNullOrWhiteSpace(street)) throw InvalidAddressException.MissingStreet();
        if(string.IsNullOrWhiteSpace(houseNumber)) throw InvalidAddressException.MissingHouseNumber();
        if (string.IsNullOrWhiteSpace(plz)) throw InvalidAddressException.MissingPLZ();
        if(string.IsNullOrWhiteSpace(town)) throw InvalidAddressException.MissingTown();

        


        if (plz.Length != 5 || !int.TryParse(plz, out _)) throw InvalidAddressException.InvalidPLZ(plz);

        // validation...






    }




    public override string ToString()
    {
        return $"Address => Id:{Address_ID}, PLZ: {PLZ}, Town: {Town}, Street: {Street}, House Number: {House_Number}.";
    }

}
