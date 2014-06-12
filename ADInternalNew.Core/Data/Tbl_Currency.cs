using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Currency
	{
		AdmisInternalDataContext context;
		public Tbl_Currency(AdmisInternalDataContext pcontext = null)
		{
			if (context == null)
			{
				context = new AdmisInternalDataContext();
			}
			else
			{
				context = pcontext;
			}
		}
		public int add(string Currency_Name)
		{
			try{
				Currency objCurrency=new Currency();
				objCurrency.Currency_Name=Currency_Name;
				context.Currencies.InsertOnSubmit(objCurrency);
				context.SubmitChanges();
				return objCurrency.Currency_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Currency_Id,string Currency_Name)
		{
			try{
				Currency objCurrency = (from i in context.Currencies where i.Currency_Id == Currency_Id select i).SingleOrDefault();
				if (objCurrency != null)
				{
					objCurrency.Currency_Name=Currency_Name;
					context.SubmitChanges();
					return true;
				}
				else
				{
					return false;
				}
 			}
			catch (Exception ex)
			{
				return false;
			}
		}
		 public Currency selectOne(int Currency_Id)
		{
			try
			{
				return (from i in context.Currencies where i.Currency_Id == Currency_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Currency> selectAll()
		{
			try
			{
				return (from i in context.Currencies  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

