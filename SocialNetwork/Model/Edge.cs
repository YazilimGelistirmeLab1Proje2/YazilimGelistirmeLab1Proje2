using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalysis.Model
{
    public class Edge
    {
        public UserNode Source { get; set; }
        public UserNode Target { get; set; }
        public double Weight { get; set; } // Ağırlık (örneğin, etkileşim sayısı

        public Edge()
        {
            
        }
        public Edge(UserNode source, UserNode target)
        {
            Source = source;
            Target = target;
            Weight = CalculateWeight();
        }
        private double CalculateWeight()
        {
            double diffActive = Math.Abs(Source.ActiveScore - Target.ActiveScore);
            double diffInteract = Math.Abs(Source.InteractionCount - Target.InteractionCount);
            double diffConnect = Math.Abs(Source.ConnectionCount - Target.ConnectionCount);

            double weight = 1.0 / (1.0 + Math.Sqrt(diffActive * diffActive + diffInteract * diffInteract + diffConnect * diffConnect));

            if (weight == 0)
            {
                return 1.0;
            }

            // HATA 2 DÜZELTİLDİ: Metodun en altına bunu eklemezsen "Not all code paths return a value" hatası alırsın.
            return weight;
        }

    }
}
