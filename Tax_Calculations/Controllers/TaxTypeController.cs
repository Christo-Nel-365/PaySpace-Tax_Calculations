using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


    public class TaxTypeController : ApiController
    {
    protected Tax_Context context;
   
     
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      
        [Route("api/TaxType/{PCode}")]
        public string Get(string PCode)
        {
            context = new Tax_Context();
        string TaxType = context.Postal_Code_tbl.SingleOrDefault(a => a.Postal_Code == PCode).Tax_Calculation_Type.Tax_Calc_Type.ToString();
        return TaxType;

        }

        

}