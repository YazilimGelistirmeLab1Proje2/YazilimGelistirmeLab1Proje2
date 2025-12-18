using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkAnalysis.Model;

namespace SocialNetworkAnalysis.Algorithms
{
    public interface IGraphAlgorithm
    {
        string Name { get; }

        void Execute(Model.Graph graph, UserNode startNode, UserNode endNode = null);

        string GetResult();
    }
}
