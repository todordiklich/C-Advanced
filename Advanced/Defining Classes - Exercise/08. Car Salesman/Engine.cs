using System.Text;

namespace _08._Car_Salesman
{
    public class Engine
    {

        public Engine(string model, string power, int displacement = 0, string efficiency = "n/a")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public string Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"  {Model}:")
                .AppendLine($"    Power: {Power}")
                .AppendLine($"    Displacement: {(Displacement != 0 ? Displacement.ToString() : "n/a")}")
                .AppendLine($"    Efficiency: {Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
