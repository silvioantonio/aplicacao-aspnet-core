using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Deve ser implementado para que quando for solicitado esse serviço, seja criado a instancia do catalogo
            services.AddTransient<ICatalogo, Catalogo>();

            //injeçao d dependencia ^
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = new Relatorio(catalogo);

            app.Run(async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
