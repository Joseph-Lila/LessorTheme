using System;
using System.Collections.Generic;
using Coursework.Domain.Interfaces;

namespace Coursework.DAL.Interfaces;

public interface IRepository<T>
    where T : IHaveId
{
    List<T> GetCollection(); //получение коллекции объектов
    T? GetItem(int id); // получение одного объекта по id
    void Create(T item); // создание объекта
    void Update(T old, T @new); // обновление объекта
    void Delete(int id); // удаление объекта по id
}