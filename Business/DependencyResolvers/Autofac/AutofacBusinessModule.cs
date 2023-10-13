using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Constructer da IProductService şeklinde bişey isterse biz ona product manager veriyor olacağız.
            //kategory
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            //Mael -öğünler
            builder.RegisterType<MealManager>().As<IMealService>();
            builder.RegisterType<EfMealDal>().As<IMealDal>();
            //Food -besinler Listesi
            builder.RegisterType<FoodManager>().As<IFoodService>();
            builder.RegisterType<EfFoodDal>().As<IFoodDal>();
        }
    }
}
