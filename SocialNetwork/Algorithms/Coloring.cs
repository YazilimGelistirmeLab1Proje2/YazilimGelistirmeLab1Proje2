using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkAnalysis.Model;

namespace SocialNetworkAnalysis.Algorithms
{
    public class Coloring : IGraphAlgorithm
    {
        public string Name => "Coloring Algorithm";

        private List<Color> _palette;

        public Coloring()
        {
            _palette = new List<Color>
            {
                Color.Red, Color.Blue, Color.Green, Color.Orange,
                Color.Purple, Color.Brown, Color.Pink, Color.Teal,
                Color.Magenta, Color.Gold
            };
        }
        public void Execute(Model.Graph graph, Model.UserNode startNode = null, Model.UserNode endNode = null)
        {
            // Bu kısma Welsh-Powell algoritması uygulanabilir.
        }
        public string GetResult()
        {
            return "Coloring algorithm executed.";
        }
    }
}
