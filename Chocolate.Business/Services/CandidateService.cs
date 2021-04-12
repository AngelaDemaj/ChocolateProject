using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Chocolate.Business.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;
        public CandidateService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateViewModel> GetCandidate(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var viewModel = await FindCandidateWithInclusions(id);

            if(viewModel == null)
            {
                return null;
            }

            viewModel.Address = await _context.Addresses.FirstOrDefaultAsync(c => c.CandidateId == id);
            viewModel.Phone = await _context.Phones.FirstOrDefaultAsync(c => c.CandidateId == id);
            viewModel.Email = await _context.Emails.FirstOrDefaultAsync(c => c.CandidateId == id);
            viewModel.Position = await _context.CandidatePositions
                .Include(cp => cp.Position)
                .Where(cp => cp.CandidateId == id)
                .Select(cp => cp.Position)
                .FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<CandidateViewModel> FindCandidateWithInclusions(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var candidate = await _context.Candidates
                .Include(c => c.Addresses)
                .Include(c => c.Emails)
                .Include(c => c.Phones)
                .Include(c => c.CandidatePositions)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (candidate == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<CandidateViewModel>(candidate);

            return viewModel;
        }

        public async Task CreateCandidateInfo(CandidateViewModel viewModel, int id)
        {
            var address = _mapper.Map<Address>(viewModel.Address);
            address.CandidateId = id;
            await _context.Addresses.AddAsync(address);

            var phone = _mapper.Map<Phone>(viewModel.Phone);
            phone.CandidateId = id;
            await _context.Phones.AddAsync(phone);

            var email = _mapper.Map<Email>(viewModel.Email);
            email.CandidateId = id;
            await _context.Emails.AddAsync(email);

            var candidatePosition = new CandidatePosition();
            candidatePosition.PositionId = viewModel.PositionId;
            candidatePosition.CandidateId = id;
            await _context.CandidatePositions.AddAsync(candidatePosition);

            await _context.SaveChangesAsync();
        }

        public async Task<CandidateViewModel> GetRelatedEntities()
        {
            var viewModel = new CandidateViewModel()
            {
                Positions = await _context.Positions.ToListAsync()
            };

            return viewModel;
        }

        public async Task<Candidate> CreateCandidate(CandidateViewModel viewModel)
        {
            var candidate = _mapper.Map<Candidate>(viewModel);
            _context.Add(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        public async Task UpdateCandidate(CandidateViewModel viewModel, int id)
        {
            var candidate = _mapper.Map<Candidate>(viewModel);
            _context.Update(candidate);

            var address = await _context.Addresses.FirstAsync(a => a.CandidateId == id);
            address.Location = viewModel.Address.Location;
            address.AddressNumber = viewModel.Address.AddressNumber;
            address.Country = viewModel.Address.Country;
            address.Comments = viewModel.Address.Comments;
            address.PostCode = viewModel.Address.PostCode;
            _context.Addresses.Update(address);

            var phone = await _context.Phones.FirstAsync(p => p.CandidateId == id);
            phone.Number = viewModel.Phone.Number;
            phone.PhoneType = viewModel.Phone.PhoneType;
            _context.Phones.Update(phone);

            var email = await _context.Emails.FirstAsync(e => e.CandidateId == id);
            email.Mail = viewModel.Email.Mail;
            email.MailType = viewModel.Email.MailType;
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCandidate(int? id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.CandidateId == id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }

            var email = await _context.Emails.SingleOrDefaultAsync(e => e.CandidateId == id);
            if (email != null)
            {
                _context.Emails.Remove(email);
            }

            var phone = await _context.Phones.SingleOrDefaultAsync(p => p.CandidateId == id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }

            var candidatePosition = await _context.CandidatePositions.SingleOrDefaultAsync(c => c.CandidateId == id);
            if(candidatePosition != null)
            {
                _context.CandidatePositions.Remove(candidatePosition);
            }

            var candidate = await _context.Candidates.FindAsync(id);
            _context.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<FileViewModel> GetFile(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);

            return new FileViewModel
            {
                FileStream = candidate.CV,
                FileName = candidate.FileName
            };
        }

    }
}