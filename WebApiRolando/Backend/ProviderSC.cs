using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiRolando.DataAccess;
using WebApiRolando.Models.Providers;

namespace WebApiRolando.Backend
{
    public class ProviderSC : BaseSC
    {
        public List<ProvidersDTO> GetAllProvidersList()
        {
            var providers = DataContext.Providers.Select(s => new ProvidersDTO
            {
                Id = s.Id,
                ProviderName = s.ProviderName,
                Telephone = s.Phone,
            }).ToList();

            return providers;


        }


    

        public long AddNewProvider(string providerName, string telephone)
        {
            var newProvider = new Providers();
            newProvider.Phone = telephone;
            newProvider.ProviderName = providerName;
            DataContext.Providers.Add(newProvider);
            DataContext.SaveChanges();
            DataContext.Entry(newProvider).GetDatabaseValues();
            return newProvider.Id;

        }
    }
}