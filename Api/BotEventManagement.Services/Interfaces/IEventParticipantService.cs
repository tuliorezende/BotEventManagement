using BotEventManagement.Services.Model.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface IEventParticipantService<T> : ICrudElements<T>
    {
        void CreateFile(byte[] participantsSheet);
    }
}
