using StructureMap;
using OdeToFood.Models;
namespace OdeToFood {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IDbContext>().Use<OdeToFoodDB>();

                        });
            return ObjectFactory.Container;
        }
    }
}