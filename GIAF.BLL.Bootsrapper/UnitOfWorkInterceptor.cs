using System;
using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using GIAF.BLL.Service.API;
using GIAF.InfraStructure.Aspects;
using GIAF.InfraStructure.UnitOfWork;

namespace GIAF.BLL.Bootsrapper
{
    public class UnitOfWorkInterceptor : BaseAspectsHandler, IInterceptor
    {
        private readonly DbContext Context;

        public UnitOfWorkInterceptor(DbContext ctx)
        {
            Context = ctx;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                if (CheckTransactionalStatus(invocation.Method))
                {
                    if (UnitOfWork.Current == null)
                        UnitOfWork.Current = new UnitOfWork(Context);

                    using (UnitOfWork.Current)
                    {
                        invocation.Proceed();                       
                        UnitOfWork.Current.Commit();
                    }
                }
                else
                {
                    invocation.Proceed();
                }

                var auditLogger = Task.Factory.StartNew(() => base.Logger(invocation));
                auditLogger.Wait();                
            }
            catch (Exception ex)
            {
                base.LogWithException(invocation, ex);
            }
            finally
            {
                UnitOfWork.Current = null;
            }
        }

        private bool CheckTransactionalStatus(MethodInfo methodInfo)
        {
            foreach (var item in methodInfo.CustomAttributes)
            {
                if (item.AttributeType == typeof(NonTransactionalAttribute))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
