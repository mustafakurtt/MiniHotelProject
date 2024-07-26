using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BaseContext>().InstancePerLifetimeScope();

        builder.RegisterType<RoomDal>().As<IRoomDal>().SingleInstance();
        builder.RegisterType<RoomTypeDal>().As<IRoomTypeDal>().SingleInstance();

        builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
        builder.RegisterType<RoomTypeManager>().As<IRoomTypeService>().SingleInstance();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}