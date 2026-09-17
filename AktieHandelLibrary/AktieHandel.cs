namespace AktieHandelLibrary
{
    public class AktieHandel
    {
        private int _id;
        private string _name;
        private double _handelsPris;
        private int _antal;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Navn
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Navn cannot be null or whitespace.");
                }
                ;
                if (value.Length < 4)
                {
                    throw new ArgumentOutOfRangeException("Navn must be at least 3 characters long.");
                }
                _name = value;
            }
        }
        public double HandelsPris
        {
            get { return _handelsPris; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("HandelsPris cannot be negative.");
                }
                _handelsPris = value;
            }
        }
        public int Antal
        {
            get { return _antal; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Antal cannot be negative.");
                }
                _antal = value;
            }
        }
    }
}
