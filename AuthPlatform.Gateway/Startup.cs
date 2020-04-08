using AhphOcelot;
using AuthPlatform.Model;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using SqlSugar;
using System;
using System.Linq;

namespace AuthPlatform.Gateway
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
            services.AddControllers();

            //InitTables();   //初始化表（临时处理）

            var authenticationProviderKey = "TestKey";
            Action<IdentityServerAuthenticationOptions> gatewayoptions = o =>
            {
                o.Authority = "http://localhost:7777";
                o.ApiName = "mpc_gateway";
                o.RequireHttpsMetadata = false;
            };

            services.AddAuthentication()
                .AddIdentityServerAuthentication(authenticationProviderKey, gatewayoptions);

            Action<IdentityServerAuthenticationOptions> options = o =>
            {
                o.Authority = "http://localhost:7777"; //IdentityServer地址
                o.RequireHttpsMetadata = false;
                o.ApiName = "gateway_admin"; //网关管理的名称，对应的为客户端授权的scope
            };
            services.AddOcelot().AddAhphOcelot(option =>
            {
                option.DbConnectionStrings = "";
                //option.RedisConnectionStrings = new List<string>() {        Configuration["CzarConfig:RedisConnectionStrings"]};
                //option.EnableTimer = true;//启用定时任务
                //option.TimerDelay = 10 * 000;//周期10秒
                //option.ClientAuthorization = true;
                //option.ClientRateLimit = true;
            });
            //.UseMySql()
            //.AddAdministration("/CzarOcelot", options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAhphOcelot().Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void InitTables()
        {
            try
            {
                using (SqlSugarClient masterSqlSugarClient = CreateConnection("Server=120.132.21.98;Database=GatewayTest;User=root;Password=123456;"))
                {
                    Type[] modelTypes = TypeReflector.ReflectType((type) =>
                    {
                        if (type.GetInterface(typeof(IEntity).FullName) == null || type.IsInterface || type.IsAbstract)
                            return false;

                        if (type == typeof(IEntity))
                            return false;

                        return true;
                    });

                    masterSqlSugarClient.CodeFirst.InitTables(modelTypes);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static SqlSugarClient CreateConnection(string connectionString, bool isShadSanmeThread = false)
        {
            SqlSugarClient sqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = isShadSanmeThread,
                //标记该数据库链接是否为线程共享
                IsShardSameThread = isShadSanmeThread
            });

#if OUTPUT_SQL
            sqlSugarClient.Aop.OnLogExecuting = (sql, parameters) =>
            {
                Console.WriteLine(GetSqlLog(sql, parameters));
            };
#endif

            sqlSugarClient.Aop.OnError = (sqlSugarException) =>
            {
                //m_log.Error($"message: {sqlSugarException.Message}{Environment.NewLine}stack_trace: {sqlSugarException.StackTrace}{Environment.NewLine}{GetSqlLog(sqlSugarException.Sql, (SugarParameter[])sqlSugarException.Parametres)}");
            };

            return sqlSugarClient;
        }

        private static string GetSqlLog(string sql, SugarParameter[] sugarParameters)
        {
            return string.Format("sql: {1}{0}parameter: {0}{2}",
                                 Environment.NewLine,
                                 sql,
                                 string.Join(Environment.NewLine, sugarParameters.Select(sugarParameter => $"{sugarParameter.ParameterName}: {sugarParameter.Value}")));
        }
    }
}
