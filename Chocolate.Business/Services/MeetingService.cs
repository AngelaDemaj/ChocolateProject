
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ChocolateDbContext _context;

        public MeetingService(ChocolateDbContext context)
        {
            _context = context;
        }

        public async Task<Meeting> CreateMeeting(Meeting meeting)
        {
            var createMeeting =  _context.Add(meeting);
           
            await _context.SaveChangesAsync();

            return meeting;
        }

        public async Task<Meeting> GetMeeting(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return null;
            }

            return meeting;
        }
    }
}
