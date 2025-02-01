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
    public class ImageManager : IImagesService
    {
        private readonly IImagesDal _imagess;

        public ImageManager(IImagesDal ImagesDal)
        {
            _imagess = ImagesDal;
        }

        public void Delete(Image t)
        {
            _imagess.Delete(t);
        }

        public List<Image> GetAll()
        {
            return _imagess.GetAll();
        }

        public Image GetById(int id)
        {
            return _imagess.GetById(id);
        }

        public void Insert(Image t)
        {
            _imagess.Insert(t);
        }

        public void Update(Image t)
        {
            _imagess.Update(t);
        }
    }
}
