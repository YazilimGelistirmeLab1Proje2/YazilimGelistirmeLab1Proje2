using System;
using System.IO;
using System.Windows.Forms;
using SocialNetworkAnalysis.Model;

namespace SocialNetworkAnalysis.Model
{
    public class FileManager
    {
        public Graph LoadGraphFromCSV(string filePath)
        {
            Graph graph = new Graph();

            try
            {
                var lines = File.ReadAllLines(filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(';');

                    if (parts.Length >= 4)
                    {
                        int id = int.Parse(parts[0]);

                        string username = "User " + id;

                        double active = double.Parse(parts[1]);      
                        double interaction = double.Parse(parts[2]); 
                        double connection = double.Parse(parts[3]);  

                        
                        UserNode node = new UserNode(id, username, active, interaction, connection);

                        
                        Random rnd = new Random(id);
                        node.X = rnd.Next(50, 600);
                        node.Y = rnd.Next(50, 450);

                        graph.AddNode(node);
                    }
                }

                
                for (int i = 1; i < lines.Length; i++)
                {
                    
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(';');
                    int sourceId = int.Parse(parts[0]);

                    
                    if (parts.Length > 4 && parts[4].Length > 0)
                    {
                        var targetIds = parts[4].Split(',');
                        foreach (var targetIdStr in targetIds)
                        {
                            
                            if (int.TryParse(targetIdStr, out int targetId))
                            {
                                graph.AddEdge(sourceId, targetId);
                            }
                        }
                    }
                }

                return graph;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message);
                return null;
            }
        }
    }
}