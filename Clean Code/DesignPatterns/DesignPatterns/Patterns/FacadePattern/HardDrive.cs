using System.Text;

namespace DesignPatterns.Patterns.FacadePattern
{
    public class HardDrive
    {
        public byte[] Read(long position, int size)
        {
            Console.WriteLine($"Reading data from position {position}");
            return Encoding.ASCII.GetBytes("Hard drive data: ");
        }
    }
}
