using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_InLock_webAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
               // Adiciona o servi�o dos Controllers
               .AddControllers();

            // Adiciona o servi�o do Swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "InLock.WebAPI", 
                    Version = "v1" 
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os par�metros de valida��o do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Valida quem est� solicitando
                        ValidateIssuer = true,

                        // Valida quem est� recebendo
                        ValidateAudience = true,

                        // Define se o tempo de expira��o ser� validado
                        ValidateLifetime = true,

                        // Forma de criptografia e ainda valida a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock.WebAPI-Chave-Autenticacao")),

                        // Valida o tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Nome do issuer, de onde est� vindo
                        ValidIssuer = "InLock.WebAPI",

                        // Nome do audience, para onde est� indo
                        ValidAudience = "InLock.WebAPI"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InLock.WebAPI");
                //Iniciando a home com o Swagger
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // Habilita a autentica��o
            app.UseAuthentication();

            // Habilita a autoriza��o
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
