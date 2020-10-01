using System;
using System.Collections.Generic;
using System.Text;
using VGTDataStore.Core.Models;
using VGTDataStore.Core.Models.Enums;

namespace VGTDataStore.Core.Interfaces
{
    public interface IGameSessionsDataStore
    {
        IDictionary<Guid, PokerGameSession> GameSessions { get; }

        IDictionary<Guid, GameSessionUsers> GameSessionUsers { get; }

        Dictionary<Guid, PokerGameSession> GetSessions();

        Dictionary<Guid, GameSessionUsers> GetSessionUsers();

        Guid AddSession(PokerGameSession session);

        Guid AddGameSessionUser(Guid sessionId, Guid userId, int place, UserRolesForPoker role, int startingChips);

        bool ChangeStatus(Guid sessionId, Guid userId, PokerPlayerStatus status);
    }
}
