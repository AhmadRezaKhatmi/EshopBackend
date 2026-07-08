using Eshop.Core.Services.Interfaces;
using Eshop.Data.Entities.Site;
using Eshop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Implementations
{
    public class SliderService : ISliderService
    {
        #region Constructor

        private readonly IGenericRepository<Slider> _sliderRepository;
        public SliderService(IGenericRepository<Slider> sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        #endregion

        #region Slider

        public void AddSlider(Slider slider)
        {
            _sliderRepository.AddEntity(slider);
            _sliderRepository.SaveChanges();
        }

        public List<Slider> GetActiveSliders()
        {
            return _sliderRepository.GetEntitiesQuery().
                Where(x => x.IsDelete != true)
                .ToList();
        }

        public List<Slider> GetAllSliders()
        {
            return _sliderRepository.GetEntitiesQuery().ToList();
        }

        public Slider GetSliderById(int sliderId)
        {
            return _sliderRepository.GetEntityById(sliderId);
        }

        public void UpdateSlider(Slider slider)
        {
            _sliderRepository.UpdateEntity(slider);
            _sliderRepository.SaveChanges();
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            _sliderRepository.Dispose();
        }
        #endregion
    }
}
