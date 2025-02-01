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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialmedia;

        public SocialMediaManager(ISocialMediaDal socialMedia)
        {
            _socialmedia = socialMedia;
        }

        public void Delete(SocialMedia t)
        {
            _socialmedia.Delete(t);
        }

        public List<SocialMedia> GetAll()
        {
            return _socialmedia.GetAll();
        }

        public SocialMedia GetById(int id)
        {
            return _socialmedia.GetById(id);
        }

        public void Insert(SocialMedia t)
        {
            _socialmedia.Insert(t);
        }

        public void Update(SocialMedia t)
        {
            _socialmedia.Update(t);
        }
    }
}
