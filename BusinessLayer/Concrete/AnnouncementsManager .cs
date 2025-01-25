using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementsManager : IAnnouncementsService
    {
        private readonly IAnnouncementsDal _AnnouncementssDal;

        public AnnouncementsManager(IAnnouncementsDal services)
        {
            _AnnouncementssDal = services;
        }

        public void Delete(Announcement t)
        {
            _AnnouncementssDal.Delete(t);
        }

        public List<Announcement> GetAll()
        {
           return  _AnnouncementssDal.GetAll();
        }

        public Announcement GetById(int id)
        {
           return _AnnouncementssDal.GetById(id);
        }

        public void Insert(Announcement t)
        {
            _AnnouncementssDal.Insert(t);
        }

        public void Update(Announcement t)
        {
            _AnnouncementssDal.Update(t);
        }
    }
}
