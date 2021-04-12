using Chocolate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Business.Services.Interfaces
{
    public interface IMeetingService
    {
       Task<Meeting> CreateMeeting(Meeting meeting);
       Task<Meeting> GetMeeting(int? id);
    }
}
