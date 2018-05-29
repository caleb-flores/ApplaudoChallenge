using ApplaudoChallenge.ContractResolver;
using ApplaudoChallenge.Data;
using ApplaudoChallenge.Repositories;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Person = ApplaudoChallenge.Models.Person;

namespace ApplaudoChallenge
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
            services.AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase("persons"); });

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new PersonContractResolver();
                    
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            GenerateFakeData(context);
            app.UseMvc();
        }

        void GenerateFakeData(ApplicationDbContext context)
        {
            var personFaker = new Faker<Person>()
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f=> f.Person.LastName)
                .RuleFor(p => p.Disabled, f => f.Random.Bool());

            var persons = personFaker.Generate(100);
            context.AddRange(persons);
            context.SaveChanges();
        }
    }
}
