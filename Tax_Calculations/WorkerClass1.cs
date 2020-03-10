using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
namespace Tax_Calculations
{
    public class WorkerClass1
    {
        protected Tax_Context context =  new Tax_Context();
        public string GetTaxType(string PCode)
        {
            string TaxType = "";
            try
            {
                TaxType = context.Postal_Code_tbl.SingleOrDefault(a => a.Postal_Code == PCode).Tax_Calculation_Type.Tax_Calc_Type.ToString();
            }
            catch
            {
                TaxType = "Postal Code Not Found";
            }
           
            return TaxType;

        }
        public string SaveTax(Decimal TaxPayable1,Decimal Salary1,String PostalCode1)
        {
            //save the tax values to the db
            string ReturnString = "";
            try
            {
                var NewTaxPayable = new Tax_Payable
                {
                    Tax_Payable1 = TaxPayable1,
                    TimeStamp = DateTime.Now,
                    Salary = Salary1,
                    Postal_Code = PostalCode1
                };
                context.Tax_Payable.Add(NewTaxPayable);
                context.SaveChanges();
                ReturnString= "Success";
            }
            catch(Exception ex)
            {
                ReturnString = ex.InnerException.ToString();
            }
            return ReturnString;
            
        }
        public decimal FlatValue(decimal Salary)
        {
            Decimal FlatValueThreshold = GetFlatValueThreshold();
            Decimal TaxOwed = 0;
            if(Salary>FlatValueThreshold)
            {
                //get the flat rate tax
                TaxOwed = GetFlatValue();
            }
            else
            {
                //if salary less than the threshold then work out the percentage tax
                Decimal FlatvalPerc = GetFlatValuePercentage();
                TaxOwed = Salary * (FlatvalPerc / 100);
            }
            return TaxOwed;
        }
        public decimal GetFlatValueThreshold()
        {
            //get the Flat value threshold
            decimal Threshold = 0;
            try
            {
                string Threshold1 = context.Flat_Value_tbl.SingleOrDefault(a => a.Flat_Value_Threshold > 0).Flat_Value_Threshold.ToString();
                Threshold = decimal.Parse(Threshold1);
            }
            catch
            {
                Threshold = 0;
            }
            return Threshold;
        }
        public decimal GetFlatValue()
        {
            //get the flat value tax
            decimal FlatValue = 0;
            try
            {
                string FlatValue1 = context.Flat_Value_tbl.SingleOrDefault(a => a.Flate_Value > 0).Flate_Value.ToString();
                FlatValue = decimal.Parse(FlatValue1);
            }
            catch
            {
                FlatValue = 0;
            }
            return FlatValue;
        }
        public decimal GetFlatValuePercentage()
        {
            //get the threshold percentage
            decimal FlatValPerc = 0;
            try
            {
                string FlatValuePerc1 = context.Flat_Value_tbl.SingleOrDefault(a => a.Flat_Value_Percentage > 0).Flat_Value_Percentage.ToString();
                FlatValPerc = decimal.Parse(FlatValuePerc1);
            }
            catch
            {
                FlatValPerc = 0;
            }
            return FlatValPerc;
        }

        public decimal FlatRate(decimal Salary)
        {
            Decimal FlatRate1 = 0;
            try
            {
                //Calculates the fix rate percentage of the salary
                string FlatRatePerc = context.Flat_Rate_tbl.SingleOrDefault(a => a.Flate_Rate > 0).Flate_Rate.ToString();
                FlatRate1 = decimal.Parse(FlatRatePerc);
                FlatRate1 = Salary * (FlatRate1 / 100);
            }
            catch
            {
                FlatRate1 = 0;
            }
            return FlatRate1;
        }
        public decimal ProgressiveRate(decimal Salary)
        {
            Decimal ProgressiveRate1 = 0;
            try
            {
                //Gets a list of all the tax brackets that the salary falls into
                var PRates = context.Progressive_Rate_tbl.Where(a => a.From_Amt < Salary).OrderByDescending(s => s.From_Amt).ToList();
                bool FirstValue = true;
                foreach(var Rates1 in PRates)
                {
                    if(FirstValue==true)
                    {
                        //Calculates the tax for the portion of the salary that falls into the last tax bracket
                        decimal Perc1 =decimal.Parse(Rates1.Rate.ToString());
                        decimal MinValue = decimal.Parse(Rates1.From_Amt.ToString());
                        ProgressiveRate1 = (Salary - MinValue) * (Perc1 / 100);
                        FirstValue = false;
                    }
                    else
                    {
                        //Calculates the tax for all the remaining tax brackets that the salary falls into
                        decimal Perc1 = decimal.Parse(Rates1.Rate.ToString());
                        decimal MaxValue = decimal.Parse(Rates1.To_Amt.ToString());
                        ProgressiveRate1 = ProgressiveRate1 + (MaxValue * (Perc1 / 100));
                    }
                }
            }
            catch (Exception)
            {

                ProgressiveRate1 = 0;
            }
            return ProgressiveRate1;
        }
    }
}