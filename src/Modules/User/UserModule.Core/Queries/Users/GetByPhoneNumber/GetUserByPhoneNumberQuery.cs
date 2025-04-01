using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using UserModule.Core.Queries._DTOs;
using UserModule.Data;

namespace UserModule.Core.Queries.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery (string PhoneNumber):IQuery<UserDto?>;

public class GetUserByPhoneNumberHandler:IQueryHandler<GetUserByPhoneNumberQuery , UserDto?>
{
    private UserContext _context;
    private IMapper _mapper;
    

    public GetUserByPhoneNumberHandler(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber , cancellationToken);
        if (user == null)
        {
            return null;
        }

        return _mapper.Map<UserDto>(user);
    }
}