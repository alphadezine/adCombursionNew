using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_City
	{
		AdmisInternalDataContext context;
		public Tbl_City(AdmisInternalDataContext pcontext = null)
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
		public int add(string City_Name)
		{
			try{
				City objCity=new City();
				objCity.City_Name=City_Name;
				context.Cities.InsertOnSubmit(objCity);
				context.SubmitChanges();
				return objCity.City_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int City_Id,string City_Name)
		{
			try{
				City objCity = (from i in context.Cities where i.City_Id == City_Id select i).SingleOrDefault();
				if (objCity != null)
				{
					objCity.City_Name=City_Name;
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
		 public City selectOne(int City_Id)
		{
			try
			{
				return (from i in context.Cities where i.City_Id == City_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<City> selectAll()
		{
			try
			{
				return (from i in context.Cities  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

