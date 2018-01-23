using BookStore.BookService.DataAccess;
using BookStore.BookService.Design.Abstractions.DataAccess;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BookStore.BookService.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            container.Register<IBookDao, BookDao>();
            container.Register<IGenreDao, GenreDao>();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}
