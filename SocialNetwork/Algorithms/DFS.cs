using SocialNetworkAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Algorithms
{
    public class DFS
    {
        public List<UserNode> DFSExecute(UserNode startNode)
        {
            // BFS'den tek farkı: Queue yerine STACK kullanılır.
            Stack<UserNode> stack = new Stack<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            List<UserNode> result = new List<UserNode>();

            if (startNode == null) return result;

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                UserNode currentUser = stack.Pop();

                if (!visited.Contains(currentUser))
                {
                    visited.Add(currentUser);
                    result.Add(currentUser);

                    // Komşuları gez
                    // Not: Stack ters çevirdiği için komşuları tersten eklemek 
                    // bazen gezme sırasını daha mantıklı yapar ama zorunlu değil.
                    foreach (var edge in currentUser.OutgoingEdges)
                    {
                        if (!visited.Contains(edge.Target))
                        {
                            stack.Push(edge.Target);
                        }
                    }
                }
            }
            return result;
        }
    }
}