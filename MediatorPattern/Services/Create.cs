using MediatorPattern.DbContexts;
using MediatorPattern.EntityModels;
using MediatR;

namespace MediatorPattern.Services
{
    public class Create : IRequest<bool>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? Mobile { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public class CreateRegisterHandler : IRequestHandler<Create, bool>
        {
            private UploadFileContext _context;
            public CreateRegisterHandler(UploadFileContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Create request, CancellationToken cancellationToken)
            {
                var CreateData = new Register()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Mobile = request.Mobile,
                    Address = request.Address,
                    Email = request.Email,
                    Password = request.Password,
                    Gender = request.Gender
                };
                var SavedData = await _context.Registers.AddAsync(CreateData);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
