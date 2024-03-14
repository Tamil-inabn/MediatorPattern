using MediatorPattern.DbContexts;
using MediatorPattern.EntityModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Services
{
    public class ViewById : IRequest<Register>
    {
        public int id { get; set; }
        public class GetDataByIdHandler : IRequestHandler<ViewById, Register>
        {
            private readonly UploadFileContext _context;
            public GetDataByIdHandler(UploadFileContext context)
            {
                _context = context;
            }

            public async Task<Register> Handle(ViewById request, CancellationToken cancellationToken)
            {
                var product = await _context.Registers.FirstOrDefaultAsync(m => m.Id == request.id);
                if (product != null)
                {
                    return product;
                }
                return default;
            }
        }
    }
}
