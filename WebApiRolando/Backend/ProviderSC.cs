using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}