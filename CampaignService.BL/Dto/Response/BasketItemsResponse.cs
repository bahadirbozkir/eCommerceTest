using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignService.BL.Dto.Response
{
    public class BasketItemsResponse
    {
        public BasketItemsResponse()
        {
            AppliedCampaigns = new List<AppliedCampaignResponse>();
        }

        public long Id { get; set; }

        public long BasketId { get; set; }

        public long ProductId { get; set; }


        public int Quantity { get; set; }

        public decimal NewPrice { get; set; }

        public string ProductName { get; set; }

        public decimal Total { get; set; }

        public decimal AffectedTotal { get; set; }

        public List<AppliedCampaignResponse> AppliedCampaigns { get; set; }
    }
}
