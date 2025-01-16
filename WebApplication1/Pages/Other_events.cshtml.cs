using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class Other_eventsModel : PageModel
    {
        private readonly ILogger<Other_eventsModel> _logger;
        private readonly AppDbContext _context;

        public Other_eventsModel(ILogger<Other_eventsModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Events> OtherEvents { get; set; }

        public async Task OnGetAsync()
        {
            // �������� Id ��������� "����", "�����" � "�������"
            var excludedCategories = await _context.Category
                .Where(c => c.NameCategory == "����" || c.NameCategory == "�����" || c.NameCategory == "��������")
                .Select(c => c.Id)
                .ToListAsync();

            // �������� ��� �������, �������� ������� �� ��������� ���������
            OtherEvents = await _context.Events
                .Where(e => !excludedCategories.Contains(e.Category))
                .ToListAsync();
        }
    }
}


