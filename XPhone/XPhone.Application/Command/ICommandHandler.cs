using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Application.Command
{
    public interface ICommandHandler<TCommand>
    {
        Task<Guid> HandlerAsync(TCommand command);
    }
}
