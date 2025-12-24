using SocialNetworkAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Algorithms
{
    public class BFS
    {
        public List<UserNode> BFSExecute(UserNode startNode)
        {
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            List<UserNode> result = new List<UserNode>();

            if (startNode == null)
                return result;

           
            queue.Enqueue(startNode);
            visited.Add(startNode); 

            while (queue.Count > 0)
            {
                
                UserNode currentUser = queue.Dequeue();

                result.Add(currentUser);

                if (currentUser.OutgoingEdges != null)
                {
                    foreach (var edge in currentUser.OutgoingEdges)
                    {
                        UserNode neighbor = edge.Target;

                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);  
                            queue.Enqueue(neighbor); 
                        }
                    }
                }
            }

            return result;
        }
        public string GetResult()
        {
            return "BFS işlemi tamamlandı.";
        }
    }
}
