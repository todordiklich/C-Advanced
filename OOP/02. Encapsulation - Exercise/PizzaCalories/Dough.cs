using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double DEFAULT_CAL_PER_GRAM = 2;

        private string flourType;
        private string bakingTechnique;

        private double flourTypePerGram;
        private double bakingTechniquePerGram;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                switch (value.ToLower())
                {
                    case nameof(FlourTypeEnum.white):
                        this.flourTypePerGram = (double)FlourTypeEnum.white / 100;
                        break;
                    case nameof(FlourTypeEnum.wholegrain):
                        this.flourTypePerGram = (double)FlourTypeEnum.wholegrain / 100;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                switch (value.ToLower())
                {
                    case nameof(BakingTechniqueEnum.chewy):
                        this.bakingTechniquePerGram = (double)BakingTechniqueEnum.chewy / 100;
                        break;
                    case nameof(BakingTechniqueEnum.crispy):
                        this.bakingTechniquePerGram = (double)BakingTechniqueEnum.crispy / 100;
                        break;
                    case nameof(BakingTechniqueEnum.homemade):
                        this.bakingTechniquePerGram = (double)BakingTechniqueEnum.homemade / 100;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double Weight 
        {
            get => this.weight;

            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200]");
                }

                this.weight = value;
            }
        }
        public double Calories => this.Weight * DEFAULT_CAL_PER_GRAM * this.flourTypePerGram * this.bakingTechniquePerGram;
    }
}
