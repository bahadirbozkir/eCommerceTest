using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.BL.Dto.Response
{
    public class CalculateResponse
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public decimal AffectedTotal { get; set; }
        public List<BasketItemsResponse> BasketItems { get; set; }
    }
}
