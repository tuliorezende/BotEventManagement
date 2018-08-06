using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface ICrudElementsWIthEventFilter<T>
    {
        void Create(T element);
        List<T> GetAll(string eventId);
        T GetById(string elementId, string eventId);
        void Delete(string elementId);
        void Update(T element);
    }
}
