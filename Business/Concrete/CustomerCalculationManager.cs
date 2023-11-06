using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerCalculationManager : ICustomerCalculationService
    {
        IAdultCustomerDetailDal _customerDetailDal;

        public CustomerCalculationManager(IAdultCustomerDetailDal customerDetailDal)
        {
            _customerDetailDal = customerDetailDal;
        }

        public IResult CustomerCalgulationValues(AdultCustomer adultCustomer)
        {
            //bu kısımda analiz hesaplamalrı yapılcak
            double boyMetre = adultCustomer.Size / 100.0;
            double vki = adultCustomer.Kilo / (boyMetre * boyMetre);
            // VKİ'ye dayalı vücut yağ oranı tahmini
            double vucutYagOrani = 0;
            double bmh = 0;
            string vki_comment;
            // VKİ değerini yorumlayın


            if (adultCustomer.Gender.Equals("Erkek"))
            {
                vucutYagOrani = 1.20 * vki + 0.23 * Convert.ToDouble(adultCustomer.Age) - 16.2;
                bmh = 88.362 + (13.397 * Convert.ToDouble(adultCustomer.Kilo)) + (4.799 * Convert.ToDouble(adultCustomer.Size)) - (5.677 * Convert.ToDouble(adultCustomer.Age));

            }
            else if (adultCustomer.Gender.Equals("Kadın"))
            {
                vucutYagOrani = 1.20 * vki + 0.23 * Convert.ToDouble(adultCustomer.Age) - 5.4;
                bmh = 447.593 + (9.247 * Convert.ToDouble(adultCustomer.Kilo)) + (3.098 * Convert.ToDouble(adultCustomer.Size)) - (4.330 * Convert.ToDouble(adultCustomer.Age));
            }



            if (vki < 18.5)
            {
                vki_comment = "Zayıf";

            }
            else if (vki >= 18.5 && vki <= 24.9)
            {
                vki_comment = "Normal";
            }
            else if (vki >= 25 && vki <= 29.9)
            {
                vki_comment = "Fazla kilolu";

            }
            else if (vki >= 30 && vki <= 34.9)
            {
                vki_comment = "Obez (Tip I)";
            }
            else if (vki >= 35 && vki <= 39.9)
            {
                vki_comment = "Obez (Tip II)";
            }
            else
            {
                vki_comment = "İleri derecede obez (Tip III)";
            }

            AdultCustomerDetail adultCustomerDetail = new AdultCustomerDetail();
           adultCustomerDetail.AdultCustomerID = adultCustomer.AdultCustomerID;
           adultCustomerDetail.BMH_value = Convert.ToDecimal(bmh);
           adultCustomerDetail.Vki_comment = vki_comment;
           adultCustomerDetail.Vki_value = Convert.ToDecimal(vki);
            adultCustomerDetail.BodyFatIndex = Convert.ToDecimal(vucutYagOrani);
            _customerDetailDal.ADD(adultCustomerDetail);
            return new SuccessResult(Messages.Added);
        }
    }
}
