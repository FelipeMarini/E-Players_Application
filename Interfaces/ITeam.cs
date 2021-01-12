using System.Collections.Generic;
using E_Players_Application.Models;

namespace E_Players_Application.Interfaces
{
    public interface ITeam
    {
         
        void Create(Team t);


        List<Team> ReadAll();


        void Update(Team t);


        void Delete(int id);

    
    
    }
}