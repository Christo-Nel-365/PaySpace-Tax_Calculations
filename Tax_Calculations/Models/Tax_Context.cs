using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;


public class Tax_Context: TaxDBEntities
{
        public Tax_Context()
        {

        }
    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbEntityValidationException ex)
        {
            // Retrieve the error messages as a list of strings.
            List<string> lstErrors = ex.EntityValidationErrors.SelectMany(c => c.ValidationErrors).ToList()
                .Select(v => v.PropertyName + " : " + v.ErrorMessage).ToList();

            var sError = "";
            foreach (var errorMessage in lstErrors)
            {
                sError += errorMessage + "\n";
            }

            var exception = new Exception(sError, ex);


            

            throw;
        }
    }

}
