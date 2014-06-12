using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Functionality
	{
		AdmisInternalDataContext context;
		public Tbl_Functionality(AdmisInternalDataContext pcontext = null)
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
		public int add(string Functionality_Name)
		{
			try{
				Functionality objFunctionality=new Functionality();
				objFunctionality.Functionality_Name=Functionality_Name;
				context.Functionalities.InsertOnSubmit(objFunctionality);
				context.SubmitChanges();
				return objFunctionality.Functionality_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Functionality_Id,string Functionality_Name)
		{
			try{
				Functionality objFunctionality = (from i in context.Functionalities where i.Functionality_Id == Functionality_Id select i).SingleOrDefault();
				if (objFunctionality != null)
				{
					objFunctionality.Functionality_Name=Functionality_Name;
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
		 public Functionality selectOne(int Functionality_Id)
		{
			try
			{
				return (from i in context.Functionalities where i.Functionality_Id == Functionality_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Functionality> selectAll()
		{
			try
			{
				return (from i in context.Functionalities  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

