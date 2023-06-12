namespace DesignPatterns.Patterns.BuilderPattern
{
    public class MansionBuilder : IHouseBuilder
    {
        private House _house;

        public MansionBuilder()
        {
            _house = new House();
        }

        public void BuildFoundation()
        {
            _house.Foundation = "Money";
        }


        public void BuildStructure()
        {
            _house.Structure = "Brick";
        }
        public void BuildRoof()
        {
            _house.Roof = "Slate";
        }

        public House GetHouse()
        {
            return _house;
        }
    }
}
