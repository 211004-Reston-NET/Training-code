//Sets the house class to be under the HouseFunction namespace
namespace HouseFunction
{
    //public will make this class available for all
    public class House
    {
        //private will make this field belong to just this C# code and nowhere else
        public string owner; 
        private string ghost;
        private int roomCount;

        public House()
        {
            owner = "Stephen";
            ghost = "Casper";
            roomCount = 1;
        }

        //Creates a property that is attached to a field
        public string Owner 
        { 
            get
            {
                return owner;
            } 
            
            set
            {
                owner = value + " Owner";
            } 
        }

        //Creates a property
        public string MiceName { get; set; }

        public override string ToString()
        {
            return $"Owner's name: {owner} and ghost's name: {ghost}";
        }
    }
}