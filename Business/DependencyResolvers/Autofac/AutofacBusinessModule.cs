using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Business.Profiles;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
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

        builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
        builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();

        builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

        builder.RegisterType<RoomTypeManager>().As<IRoomTypeService>().SingleInstance();
        builder.RegisterType<RoomTypeDal>().As<IRoomTypeDal>().SingleInstance();

        builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
        builder.RegisterType<RoomDal>().As<IRoomDal>().SingleInstance();

        builder.RegisterType<RoomTypeBusinessRules>().SingleInstance();

        builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        builder.Register(context => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RoomProfile>();
            cfg.AddProfile<RoomTypeProfile>();
            cfg.AddProfile<ModerationProfile>();
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<OperationClaimProfile>();
        })).AsSelf().SingleInstance();

        builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();


        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}