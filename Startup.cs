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
            //injeçao de dependencia ^
            // Deve ser implementado para que quando for solicitado esse serviço, seja criado a instancia do catalogo
            //services.AddTransient<ICatalogo, Catalogo>();
            //services.AddTransient<IRelatorio, Relatorio>();

            //Gerando instancias utilizando o scoped(A cada vez que o browser for recarregado)
            //services.AddScoped<ICatalogo, Catalogo>();
            //services.AddScoped<IRelatorio, Relatorio>();


            // Agora utilizando o Singleton...havera apenas uma unica instancia durente toda a execuçao da aplicação
            var catalogo = new Catalogo();
            services.AddSingleton<ICatalogo>(catalogo);
            services.AddSingleton<IRelatorio>(new Relatorio(catalogo));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

            app.Run(async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
