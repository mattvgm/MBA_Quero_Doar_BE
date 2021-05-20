using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using source.Models;
using source.Service;
using source.Service.Data;
using source.Service.Interfaces;
using source.Service.Repository;

namespace source
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INoSql, NoSql>();

            services.AddScoped<DoadorService>();
            services.AddScoped<DoadorRepository>();
            services.AddScoped<IRepository<Doador>, DoadorRepository>();

            services.AddScoped<EmpresaService>();
            services.AddScoped<EmpresaRepository>();
            services.AddScoped<IRepository<Empresa>, EmpresaRepository>();

            services.AddScoped<InstituicaoService>();
            services.AddScoped<InstituicaoRepository>();
            services.AddScoped<IRepository<Instituicao>, InstituicaoRepository>();

            services.AddScoped<PagamentoService>();
            services.AddScoped<PagamentoRepository>();
            services.AddScoped<IRepository<Pagamento>, PagamentoRepository>();

            services.AddScoped<SetorAtuacaoService>();
            services.AddScoped<SetorAtuacaoRepository>();
            services.AddScoped<IRepository<SetorAtuacao>, SetorAtuacaoRepository>();

            services.AddScoped<DoacaoService>();
            services.AddScoped<DoacaoRepository>();
            services.AddScoped<IRepository<Doacao>, DoacaoRepository>();

            services.AddScoped<CupomService>();
            services.AddScoped<CupomRepository>();
            services.AddScoped<IRepository<Cupom>, CupomRepository>();

            services.AddScoped<MeusCuponsRepository>();
            services.AddScoped<IRepository<MeusCupons>, MeusCuponsRepository>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "source", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "source v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}