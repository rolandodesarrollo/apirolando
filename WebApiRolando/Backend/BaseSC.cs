
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiRolando.DataAccess;

namespace WebApiRolando.Backend
{
    public class BaseSC
    {
        public AxosnetTestEntities DataContext = new AxosnetTestEntities();
    }
}