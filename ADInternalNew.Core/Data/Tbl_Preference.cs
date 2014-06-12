using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Preference
	{
		AdmisInternalDataContext context;
		public Tbl_Preference(AdmisInternalDataContext pcontext = null)
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
		public int add(string Preference_Name)
		{
			try{
				Preference objPreference=new Preference();
				objPreference.Preference_Name=Preference_Name;
				context.Preferences.InsertOnSubmit(objPreference);
				context.SubmitChanges();
				return objPreference.Preference_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Preference_Id,string Preference_Name)
		{
			try{
				Preference objPreference = (from i in context.Preferences where i.Preference_Id == Preference_Id select i).SingleOrDefault();
				if (objPreference != null)
				{
					objPreference.Preference_Name=Preference_Name;
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
		 public Preference selectOne(int Preference_Id)
		{
			try
			{
				return (from i in context.Preferences where i.Preference_Id == Preference_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Preference> selectAll()
		{
			try
			{
				return (from i in context.Preferences  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

