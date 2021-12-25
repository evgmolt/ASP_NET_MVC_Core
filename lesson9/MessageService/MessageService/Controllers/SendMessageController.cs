using MessageService.Data;
using MessageService.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly IGate _gate;
        private readonly MessageServiceContext _context;
        public SendMessageController(IGate gate, MessageServiceContext context)
        {
            _gate = gate;
            _context = context;
        }
        public async void Index()
        {
            var users = _context.User.ToList();
            await _gate.SendMessage("", "", users);
        }
    }
}
