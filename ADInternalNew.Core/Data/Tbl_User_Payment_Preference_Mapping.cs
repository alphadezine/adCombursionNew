using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Payment_Preference_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Payment_Preference_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_To_Preference_Id,int Payment_Mode_Id)
		{
			try{
				User_Payment_Preference_Mapping objUser_Payment_Preference_Mapping=new User_Payment_Preference_Mapping();
				objUser_Payment_Preference_Mapping.User_To_Preference_Id=User_To_Preference_Id;
				objUser_Payment_Preference_Mapping.Payment_Mode_Id=Payment_Mode_Id;
				context.User_Payment_Preference_Mappings.InsertOnSubmit(objUser_Payment_Preference_Mapping);
				context.SubmitChanges();
				return objUser_Payment_Preference_Mapping.User_Payment_Preferenc_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Payment_Preferenc_Mapping_Id,int User_To_Preference_Id,int Payment_Mode_Id)
		{
			try{
				User_Payment_Preference_Mapping objUser_Payment_Preference_Mapping = (from i in context.User_Payment_Preference_Mappings where i.User_Payment_Preferenc_Mapping_Id == User_Payment_Preferenc_Mapping_Id select i).SingleOrDefault();
				if (objUser_Payment_Preference_Mapping != null)
				{
					objUser_Payment_Preference_Mapping.User_To_Preference_Id=User_To_Preference_Id;
					objUser_Payment_Preference_Mapping.Payment_Mode_Id=Payment_Mode_Id;
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
		 public User_Payment_Preference_Mapping selectOne(int User_Payment_Preferenc_Mapping_Id)
		{
			try
			{
				return (from i in context.User_Payment_Preference_Mappings where i.User_Payment_Preferenc_Mapping_Id == User_Payment_Preferenc_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Payment_Preference_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Payment_Preference_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

