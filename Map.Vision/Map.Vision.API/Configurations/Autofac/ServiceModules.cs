using Autofac;
using AutoMapper;
using Divergic.Configuration.Autofac;
using Map.Vision.API.Configurations.AutoMapper;
using Map.Vision.BI.Options;
using System;
using Map.Vision.BI.Interfaces;
using Map.Vision.BI.Services;

namespace Map.Vision.API.Configurations.Autofac
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Sensors>()
                .As<IAdmin>();

            builder.RegisterType<Sensors>()
                .As<ISensors>();

            builder.RegisterType<Sensors>()
                .As<ISensorGeocoding>();

            builder.RegisterType<DataSend>()
                .As<IDataSend>();

            builder.RegisterType<Attachments>()
                .As<IAttachments>();

            builder.RegisterType<Geocoding>()
                .As<IGeocoding>();

            builder.RegisterType<FormatterFileToAttachment>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var resolver = new EnvironmentJsonResolver<Config>("appsettings.json", $"appsettings.{env}.json");
            var module = new ConfigurationModule(resolver);

            builder.RegisterModule(module);
        }
    }
}
