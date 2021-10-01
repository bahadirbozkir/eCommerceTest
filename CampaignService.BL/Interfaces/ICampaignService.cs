using CampaignService.BL.Dto.Request;
using CampaignService.BL.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampaignService.BL.Interfaces
{
    public interface ICampaignService
    {
        Task<CalculateResponse> Calculate(CalculateRequest request);
    }
}
