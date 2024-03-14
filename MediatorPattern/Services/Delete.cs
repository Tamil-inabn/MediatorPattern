using MediatorPattern.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Services
{
    public class Delete : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteHandler : IRequestHandler<Delete, int>
        {
            private readonly UploadFileContext _context;
            public DeleteHandler(UploadFileContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Delete request, CancellationToken cancellationToken)
            {
                var Delete = await _context.Registers.FirstOrDefaultAsync(m => m.Id == request.Id);
                if (Delete == null)
                {
                    return 0;
                }
                _context.Registers.Remove(Delete);
                _context.SaveChanges();
                return 1;
            }
        }
    }
}
