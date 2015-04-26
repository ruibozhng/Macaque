using Macaque.Common.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessComponent
{
    public static class ExceptionHelper
    {
        public static void HandleException(Exception ex)
        {
            HandleException(ex, Constants.ExceptionPolicy);
        }

        public static void HandleException(Exception ex, string policy)
        {
            Boolean rethrow = false;
            try
            {
                rethrow = ExceptionPolicy.HandleException(ex, policy);
            }
            catch (Exception e)
            {
                string errorMsg = "An unexpected exception occured while " +
                    "calling HandleException with policy " + policy + ". ";

                throw new Exception(errorMsg);
            }
            //if (rethrow)
            //{
            //    throw ex;
            //}
        }
    }
}
