using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Text;
namespace Tax_Calculations
{
    public partial class _Default : Page
    {
        public  HttpClient client = new HttpClient();
        protected Tax_Context context;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                context = new Tax_Context();
            }
        }

        protected  void btnSubmit_Click(object sender, EventArgs e)
        {           
            try
            {
                string PostalCode = txtPostCode.Text;
                WorkerClass1 NewWorkerClass = new WorkerClass1();
                string TaxType =NewWorkerClass.GetTaxType(PostalCode);
                decimal Salary = decimal.Parse(txtSalary.Text);
                decimal TaxOwed = 0;
                switch(TaxType)
                {
                    case "Progressive":
                        TaxOwed = NewWorkerClass.ProgressiveRate(Salary);
                        txtResult.Text = "Total Tax Owed = R" + TaxOwed.ToString();
                        string Success1 = NewWorkerClass.SaveTax(TaxOwed, Salary, PostalCode);
                        break;
                    case "Flat Value":
                        TaxOwed = NewWorkerClass.FlatValue(Salary);
                        txtResult.Text = "Total Tax Owed = R" + TaxOwed.ToString();
                        string Success2 = NewWorkerClass.SaveTax(TaxOwed, Salary, PostalCode);
                        break;
                    case "Flat Rate":
                        TaxOwed = NewWorkerClass.FlatRate(Salary);
                        txtResult.Text = "Total Tax Owed = R" + TaxOwed.ToString();
                        string Success3 = NewWorkerClass.SaveTax(TaxOwed, Salary, PostalCode);
                        break;
                    case "Postal Code Not Found":
                        txtResult.Text = "Postal Code Not Found";
                        break;
                }
                
             
            }
            catch(Exception ex)
            {

            }
        }
        
       
    }
}