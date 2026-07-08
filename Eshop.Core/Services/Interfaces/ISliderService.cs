using Eshop.Data.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Interfaces
{
    public interface ISliderService : IDisposable
    {
        List<Slider> GetAllSliders();

        List<Slider> GetActiveSliders();

        void AddSlider(Slider slider);

        void UpdateSlider(Slider slider);

        Slider GetSliderById(int sliderId);

    }
}
