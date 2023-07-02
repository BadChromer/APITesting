namespace RestAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UserModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Username == model.Username &&
                   Email == model.Email &&
                   EqualityComparer<Address>.Default.Equals(Address, model.Address) &&
                   Phone == model.Phone &&
                   Website == model.Website &&
                   EqualityComparer<Company>.Default.Equals(Company, model.Company);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Username, Email, Address, Phone, Website, Company);
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Address address &&
                   Street == address.Street &&
                   Suite == address.Suite &&
                   City == address.City &&
                   Zipcode == address.Zipcode &&
                   EqualityComparer<Geo>.Default.Equals(Geo, address.Geo);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Suite, City, Zipcode, Geo);
        }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Geo geo &&
                   Lat == geo.Lat &&
                   Lng == geo.Lng;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lat, Lng);
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Company company &&
                   Name == company.Name &&
                   CatchPhrase == company.CatchPhrase &&
                   Bs == company.Bs;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, CatchPhrase, Bs);
        }
    }
}