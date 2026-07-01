using Eshop.Core.Services.Implementations;
using Eshop.Core.Utilities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{

    public class SliderController : SiteBaseController
    {

        #region Constructor
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        #endregion


        #region Slider

        [HttpGet("GetActiveSliders")]
        public IActionResult GetActiveSliders()
        {
            var sliders= _sliderService.GetActiveSliders();

            return JsonResponseStatus.Success(sliders);
        }

        #endregion

    }
}
