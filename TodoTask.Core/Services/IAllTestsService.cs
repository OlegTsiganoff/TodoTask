using System;
using System.Collections.Generic;

namespace TodoTask.Core.ViewModels
{
    public interface IAllTestsService
    {
        Type NextViewModelType(TestViewModel currentViewModel);

        IList<Type> All { get; }
    }
}