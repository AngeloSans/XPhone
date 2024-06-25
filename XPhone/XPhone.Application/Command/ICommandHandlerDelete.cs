using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPhone.Application.Command
{
    public interface ICommandHandlerDelete<TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}
