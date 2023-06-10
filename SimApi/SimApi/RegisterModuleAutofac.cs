using Autofac;
using Autofac.Core;
using SimApi.Operation.CategorydapperService;
using SimApi.Operation;
using SimApi.Data.Repository;

namespace SimApi.Service
{
    public class RegisterModuleAutofac :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserLogService>().As<IUserLogService>()
              .InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>()
             .InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>()
             .InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>()
            .InstancePerLifetimeScope();
            builder.RegisterType<AccountService>().As<IAccountService>()
          .InstancePerLifetimeScope();
            builder.RegisterType<TransactionService>().As<ITransactionService>()
        .InstancePerLifetimeScope();
            builder.RegisterType<TransactionReportService>().As<ITransactionReportService>()
       .InstancePerLifetimeScope();
            builder.RegisterType<DapperAccountService>().As<IDapperAccountService>()
     .InstancePerLifetimeScope();
            builder.RegisterType<DapperCategoryService>().As<IDapperCategoryService>()
    .InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
    .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
   .InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>()
  .InstancePerLifetimeScope();




          





            // Other Lifetime
            // Transient
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .InstancePerDependency();

            //// Scoped
            //builder.RegisterType<StudentManager>().As<IStudentManager>()
            //    .InstancePerLifetimeScope();


            //// Singleton
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .SingleInstance();
        }
    }
}
