using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Country
	{
		AdmisInternalDataContext context;
		public Tbl_Country(AdmisInternalDataContext pcontext = null)
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
		public int add(string Country_Name)
		{
			try{
				Country objCountry=new Country();
				objCountry.Country_Name=Country_Name;
				context.Countries.InsertOnSubmit(objCountry);
				context.SubmitChanges();
				return objCountry.Country_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Country_Id,string Country_Name)
		{
			try{
				Country objCountry = (from i in context.Countries where i.Country_Id == Country_Id select i).SingleOrDefault();
				if (objCountry != null)
				{
					objCountry.Country_Name=Country_Name;
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
		 public Country selectOne(int Country_Id)
		{
			try
			{
				return (from i in context.Countries where i.Country_Id == Country_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Country> selectAll()
		{
			try
			{
				return (from i in context.Countries  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

