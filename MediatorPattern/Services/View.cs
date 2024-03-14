using MediatorPattern.DbContexts;
using MediatorPattern.EntityModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Services
{
    public class View : IRequest<IEnumerable<Register>>
    {
        public class GetAllHandler : IRequestHandler<View, IEnumerable<Register>>
        {
            private readonly UploadFileContext _context;
            public GetAllHandler(UploadFileContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Register>> Handle(View request, CancellationToken cancellationToken)
            {
                return await _context.Registers.AsNoTracking().ToListAsync();
            }
        }
    }
}
