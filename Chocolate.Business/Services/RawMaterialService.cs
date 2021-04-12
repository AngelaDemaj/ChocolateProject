using AutoMapper;
using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chocolate.Business.Services
{
    public class RawMaterialService : IRawMaterialService
    {
        private readonly ChocolateDbContext _context;
        private readonly IMapper _mapper;

        public RawMaterialService(ChocolateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RawMaterialViewModel> GetRawMaterial(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var rawMaterial = await _context.RawMaterials
                .SingleOrDefaultAsync(m => m.Id == id);

            if (rawMaterial == null)
            {
                return null;
            }

            var viewModel = _mapper.Map<RawMaterialViewModel>(rawMaterial);

            return viewModel;
        }

        public Task<RawMaterialViewModel> GetRawMaterialWithIncludes(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RawMaterialViewModel> GetRelatedEntities()
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateRawMaterial(RawMaterialViewModel viewModel)
        {
            var rawMaterial = _mapper.Map<RawMaterial>(viewModel);
            _context.RawMaterials.Add(rawMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRawMaterial(int id, RawMaterialViewModel viewModel)
        {
            var rawMaterial = _mapper.Map<RawMaterial>(viewModel);
            rawMaterial.Id = id;
            _context.RawMaterials.Update(rawMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRawMaterial(int? id)
        {
            var rawMaterial = await _context.RawMaterials.FindAsync(id);

            _context.RawMaterials.Remove(rawMaterial);
            await _context.SaveChangesAsync();
        }
    }
}