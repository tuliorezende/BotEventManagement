using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface ICrudElementsWIthEventFilter<T>
    {
        void Create(string eventId, T element);
        List<T> GetAll(string eventId);
        T GetById(string elementId, string eventId);
        void Delete(string eventId, string elementId);
        void Update(T element);
    }
}
