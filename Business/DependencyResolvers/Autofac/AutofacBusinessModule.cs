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

            //customer
            builder.RegisterType<AdultCustomerManager>().As<IAdultCustomerService>();
            builder.RegisterType<EfAdultCustomerDal>().As<IAdultCustomerDal>();

            //customerdetail
            builder.RegisterType<AdultCustomerDetailManager>().As<IAdultCustomerDetailService>();
            builder.RegisterType<EfAdultCustomerDetailDal>().As<IAdultCustomerDetailDal>();

            //Adultmeeting

            builder.RegisterType<AdultMeetingManager>().As<IAdultMeetingService>();
            builder.RegisterType<EfAdultMeetingDal>().As<IAdultMeetingDal>();

            //customerFolder 
            builder.RegisterType<CustomerFolderManager>().As<ICustomerFolderService>();
            builder.RegisterType<EfCustomerFolderDal>().As<ICustomerFolderDal>();

            //GeneraldietList 
            builder.RegisterType<GeneralDietListManager>().As<IGeneralDietListService>();
            builder.RegisterType<EfGeneralDietListDal>().As<IGeneralDietListDal>();

            //GeneraldietList 
            builder.RegisterType<DietPlanManager>().As<IDietPlanService>();
            builder.RegisterType<EfDietPlanDal>().As<IDietPlanDal>();

            //hastalıklar için 
            builder.RegisterType<DiseaseManager>().As<IDiseaseService>();
            builder.RegisterType<EfDiseaseDal>().As<IDiseaseDal>();

            //Danışan Dİyet listesi
            builder.RegisterType<CustomerDietListManager>().As<ICustomerDietListService>();
            builder.RegisterType<EfCustomerDietListDal>().As<ICustomerDietListDal>();
            // Danışan Diyetplan 
            builder.RegisterType<CustomerDietPlanManager>().As<ICustomerDietPlanService>();
            builder.RegisterType<EfCustomerDietPlanDal>().As<ICustomerDietPlanDal>();

            //User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            //AppoinmetCalendar 
            builder.RegisterType<AppoinmentCalendarManager>().As<IAppoinmentCalendarService>();
            builder.RegisterType<EfAppoinmentCalendarDal>().As<IAppoinmentCalendarDal>();
        }
    }
}
