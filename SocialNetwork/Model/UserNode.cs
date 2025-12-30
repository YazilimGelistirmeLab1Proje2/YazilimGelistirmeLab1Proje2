using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SocialNetworkAnalysis.Model
{
    public class UserNode
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public double ActiveScore { get; set; }  // Aktiflik 
        public double InteractionCount { get; set; } // Etkileşim Sayısı
        public double ConnectionCount { get; set; } // Bağlantı Sayısı

        public int X { get; set; }
        public int Y { get; set; }

        public Color UserNodeColor { get; set; } = Color.CornflowerBlue;

        public List<Edge> OutgoingEdges { get; set; }
        public UserNode()
        {
            OutgoingEdges = new List<Edge>();
        }

        public UserNode(int id, string username, double active, double interaction, double connection)
        {
            Id = id;
            UserName = username;
            ActiveScore = active;
            InteractionCount = interaction;
            ConnectionCount = connection;
            OutgoingEdges = new List<Edge>();
        }
        public override string ToString()
        {
            return $"UserNode {Id} : Aktiflik ={ActiveScore}, Etkileşim={InteractionCount}, Bağlantı={ConnectionCount}";
        }
    }
}
