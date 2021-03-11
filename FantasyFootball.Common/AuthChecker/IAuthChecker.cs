using System;

namespace FantasyFootball.Common.AuthChecker
{
    public interface IAuthChecker
    {
        Guid GetCallerId();
    }
}
