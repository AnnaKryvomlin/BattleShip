using BattleShip.DataAccess.Interfaces;
using BattleShip.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Configurations
{
    public static class UnitOfWorkConfig
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
