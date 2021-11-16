using Ninject;
using System;
using System.Collections.Generic;

namespace NinjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository<int>>().To<IntRepository>().InSingletonScope();
            kernel.Bind<IRepository<string>>().To<StringRepository>().InSingletonScope();
            kernel.Bind<DataManager>().ToSelf().InSingletonScope();

            DataManager dataManager = kernel.Get<DataManager>();

            for (int i = 0; i < 5; i++)
            {
                dataManager.CreateInt(i * 10);
                dataManager.CreateString(i.ToString());
            }
            List<string> slist = (List<string>)dataManager.GetStrings();
            List<int> ilist = (List<int>)dataManager.GetInts();

            foreach (int i in ilist)
            {
                Console.WriteLine(i.ToString());
            }

            foreach (string s in slist)
            {
                Console.WriteLine(s);
            }
        }

    }
}
