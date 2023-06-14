namespace DesignPatterns.Patterns.FacadePattern
{
    // This is the facade
    public class Computer
    {
        private CPU cpu;
        private Memory memory;
        private HardDrive hardDrive;

        public Computer()
        {
            this.cpu = new CPU();
            this.memory = new Memory();
            this.hardDrive = new HardDrive();
        }

        public void Start()
        {
            cpu.Freeze();
            Thread.Sleep(1000);
            memory.Load(0, hardDrive.Read(0, 1024));
            Thread.Sleep(1000);
            cpu.Jump(0);
            Thread.Sleep(1000);
            cpu.Execute();
        }
    }
}
