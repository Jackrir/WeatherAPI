using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Layer.Interfaces
{
    public interface IMeasureManager
    {

        IEnumerable<Measure> Get();

        Measure GetById(string name, DateTime dateTime);

        Task<bool> Add(Measure newMeasure);

        Task<bool> Update(Measure updateMeasure);

        Task<bool> Delete(string name, DateTime dateTime);
    }
}
