using AngleSharp.Dom;
using Common.Query.Filter;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile.Tickets
{
    public class IndexModel : BaseRazorFilter<TicketFilterParams>
    {
        private ITicketService _ticketService;

        public IndexModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public TicketFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult =await _ticketService.GetTicketByFilter(new TicketFilterParams()
            {
                UserId = User.GetUserId(),
                Take = FilterParams.Take,
                PageId = FilterParams.PageId
            });
        }
    }
}
