namespace DesignPatterns.Patterns.BuilderPattern
{
    public class CottageBuilder : IHouseBuilder
    {
        private House _house;

        public CottageBuilder()
        {
            _house = new House();
        }

        public void BuildFoundation()
        {
            _house.Foundation = "Concrete";
        }


        public void BuildStructure()
        {
            _house.Structure = "Wood";
        }
        public void BuildRoof()
        {
            _house.Roof = "Shingles";
        }

        public House GetHouse()
        {
            return _house;
        }
    }
}
