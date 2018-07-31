using System;
using System.Collections.Generic;
using System.Text;

namespace BotEventManagement.Services.Interfaces
{
    public interface ICrudElements<T>
    {
        void Create(T element);
        List<T> GetAll();
        T GetById(string elementId);
        void Delete(string elementId);
        void Update(T element);
    }
}
