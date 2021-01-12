using System.Collections.Generic;
using System.IO;
using E_Players_Application.Interfaces;

namespace E_Players_Application.Models
{
    public class Team : EPlayersBase , ITeam
    {
        
        public int IdTeam { get; set; }
        
        public string Name { get; set; }
        
        public string Image { get; set; }

        
        private const string PATH = "Database/Team.csv";


        public Team()
        {

            CreateFolderAndFile(PATH);

        }

        
        public string PrepareCSV(Team t)
        {

            return $"{t.IdTeam};{t.Name};{t.Image}";

        }

        
        
        public void Create(Team t)
        {
            
            string[] lines = { PrepareCSV(t) };
            
            File.AppendAllLines(PATH,lines);

        }

        
        public List<Team> ReadAll()
        {
            
            List<Team> teamsList = new List<Team>(); 

            string[] lines = File.ReadAllLines(PATH);

            
            foreach (var item in lines)
            {

                string[] line = item.Split(";");

                
                Team team = new Team();

                team.IdTeam = int.Parse(line[0]);  
                team.Name = line[1];
                team.Image = line[2];

                teamsList.Add(team);

            }

            return teamsList;
        
        }

        
        public void Update(Team t)
        {
            
            List<string> linesUpdate = ReadAllLinesCSV(PATH);
        

            linesUpdate.RemoveAll( x => x.Split(";")[0] == t.IdTeam.ToString() ); 
        

            linesUpdate.Add( PrepareCSV(t) );


            RewriteCSV(PATH,linesUpdate);

        }
    
    
        
        public void Delete(int id)
        {
            
            List<string> linesUpdate = ReadAllLinesCSV(PATH);
        

            linesUpdate.RemoveAll( x => x.Split(";")[0] == id.ToString() ); 
        
            
            RewriteCSV(PATH,linesUpdate);
        
        }


    
    
    }
}