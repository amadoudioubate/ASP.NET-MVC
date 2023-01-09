namespace _02_PassingDataToView.Models
{
    public class Personnage
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Personnage(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
