using MediatorPattern.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Services
{
    public class Update : IRequest<bool>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? Mobile { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public class UpdateHandler : IRequestHandler<Update, bool>
        {
            private readonly UploadFileContext _context;
            public UpdateHandler(UploadFileContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Update request, CancellationToken cancellationToken)
            {
                var RegisterData = await _context.Registers.FirstOrDefaultAsync(m => m.Id == request.Id);
                if (RegisterData == null)
                {
                    return default;
                }
                RegisterData.FirstName = request.FirstName;
                RegisterData.LastName = request.LastName;
                RegisterData.Email = request.Email;
                RegisterData.Password = request.Password;
                RegisterData.Mobile = request.Mobile;
                RegisterData.Gender = request.Gender;
                RegisterData.Address = request.Address;
                var SavedData = _context.Registers.Update(RegisterData);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
