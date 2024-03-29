using CarBookProject.Dto.Dtos.Reservation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardRecentBuyersComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardRecentBuyersComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Reservations/GetReservationsWithInfo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationWithInfoDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
