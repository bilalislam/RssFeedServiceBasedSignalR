using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace GIAF.InfraStructure.Aspects
{
    public abstract class BaseAspectsHandler
    {
        /// <summary>
        /// save the all exceptions as syncronize
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="ex"></param>
        protected virtual void LogWithException(IInvocation invocation, Exception ex)
        {

        }

        /// <summary>
        /// save the all transactions as asyncronize
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        protected virtual void Logger(IInvocation invocation)
        {
          
        }
    }
}
