using System;
using StructureMap;

namespace PayrollProcessor.Core
{
    public static class IoCContainer
    {
        private static Container Container = new Container();

        public static void Register(Type interfaceType, Type concreteType)
        {
            Container.Configure(c => c.For(interfaceType).Use(concreteType));
        }

        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
