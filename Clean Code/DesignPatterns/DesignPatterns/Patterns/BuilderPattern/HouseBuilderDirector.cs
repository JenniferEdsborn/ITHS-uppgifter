namespace DesignPatterns.Patterns.BuilderPattern
{
    public class HouseBuilderDirector
    {
        private IHouseBuilder _builder;

        public HouseBuilderDirector(IHouseBuilder builder)
        {
            _builder = builder;
        }

        public void BuildHouse()
        {
            _builder.BuildFoundation();
            _builder.BuildStructure();
            _builder.BuildRoof();
        }

        public House GetHouse()
        {
            return _builder.GetHouse();
        }
    }
}
