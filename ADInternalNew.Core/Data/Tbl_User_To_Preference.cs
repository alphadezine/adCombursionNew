using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_To_Preference
	{
		AdmisInternalDataContext context;
		public Tbl_User_To_Preference(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_Id,int Preference_Id,bool bool_value)
		{
			try{
				User_To_Preference objUser_To_Preference=new User_To_Preference();
				objUser_To_Preference.User_Id=User_Id;
				objUser_To_Preference.Preference_Id=Preference_Id;
				objUser_To_Preference.bool_value=bool_value;
				context.User_To_Preferences.InsertOnSubmit(objUser_To_Preference);
				context.SubmitChanges();
				return objUser_To_Preference.User_To_Preference_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_To_Preference_Id,int User_Id,int Preference_Id,bool bool_value)
		{
			try{
				User_To_Preference objUser_To_Preference = (from i in context.User_To_Preferences where i.User_To_Preference_Id == User_To_Preference_Id select i).SingleOrDefault();
				if (objUser_To_Preference != null)
				{
					objUser_To_Preference.User_Id=User_Id;
					objUser_To_Preference.Preference_Id=Preference_Id;
					objUser_To_Preference.bool_value=bool_value;
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
		 public User_To_Preference selectOne(int User_To_Preference_Id)
		{
			try
			{
				return (from i in context.User_To_Preferences where i.User_To_Preference_Id == User_To_Preference_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_To_Preference> selectAll()
		{
			try
			{
				return (from i in context.User_To_Preferences  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

