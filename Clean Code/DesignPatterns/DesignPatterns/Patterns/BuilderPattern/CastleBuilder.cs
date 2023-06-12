namespace DesignPatterns.Patterns.BuilderPattern
{
    public class CastleBuilder : IHouseBuilder
    {
        private House _house;

        public CastleBuilder()
        {
            _house = new House();
        }

        public void BuildFoundation()
        {
            _house.Foundation = "Stone";
        }


        public void BuildStructure()
        {
            _house.Structure = "Gold";
        }
        public void BuildRoof()
        {
            _house.Roof = "Diamonds";
        }

        public House GetHouse()
        {
            return _house;
        }
    }
}
