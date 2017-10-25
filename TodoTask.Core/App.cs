using MvvmCross.Platform.IoC;
using TodoTask.Core.Helpers.Database;

namespace TodoTask.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();
            var dbCreator = new DBCreator();
            dbCreator.FillDatabaseIfNeed();
        }
    }
}