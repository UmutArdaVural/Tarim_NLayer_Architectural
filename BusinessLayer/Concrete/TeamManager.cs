using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TeamManager : ITeamsService
    {
        private readonly ITeamsDal _teams;

        public TeamManager(ITeamsDal teamDal)
        {
            _teams = teamDal;
        }

        // fonsiyon atamaları 
        public void Delete(Team t)
        {
            _teams.Delete(t);
        }

        public List<Team> GetAll()
        {
            return _teams.GetAll();
        }

        public Team GetById(int id)
        {
            return _teams.GetById(id);
        }

        public void Insert(Team t)
        {
            _teams.Insert(t);
        }

        public void Update(Team t)
        {
           _teams.Update(t);
        }
    }
}
