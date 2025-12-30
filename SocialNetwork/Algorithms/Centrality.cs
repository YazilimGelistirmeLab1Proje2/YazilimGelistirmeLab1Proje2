using SocialNetworkAnalysis.Model;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace SocialNetwork.Algorithms

{
    public class Centrality
    {
        public UserNode FindMostPopularUser(Graph graph)
        {
            UserNode bestUser = null;
            double maxScore = -1;


            foreach (var node in graph.Nodes.Values)
            {
                if (node.ConnectionCount > maxScore)
                {
                    maxScore = node.ConnectionCount;
                    bestUser = node;
                }

            }
            return bestUser;
        }
    }
}