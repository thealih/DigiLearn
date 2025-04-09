using Common.Application;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;

namespace UserModule.Core.Commands.Notifications.Delete;

public class DeleteNotificationCommandHandler : IBaseCommandHandler<DeleteNotificationCommand>
{
    private readonly UserContext _userContext;

    public DeleteNotificationCommandHandler(UserContext context)
    {
        _userContext = context;
    }

    public async Task<OperationResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification =
            await _userContext.Notifications.FirstOrDefaultAsync(
                a => a.UserId == request.UserId &&
                     a.Id == request.NotificationId, cancellationToken);

        if (notification == null) return OperationResult.NotFound();

        _userContext.Notifications.Remove(notification);
        await _userContext.SaveChangesAsync(cancellationToken);

        return OperationResult.Success();
    }
}