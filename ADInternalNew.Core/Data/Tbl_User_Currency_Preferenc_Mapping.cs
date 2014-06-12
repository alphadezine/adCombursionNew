using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Currency_Preferenc_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Currency_Preferenc_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_To_Preference_Id,int Currency_Id)
		{
			try{
				User_Currency_Preferenc_Mapping objUser_Currency_Preferenc_Mapping=new User_Currency_Preferenc_Mapping();
				objUser_Currency_Preferenc_Mapping.User_To_Preference_Id=User_To_Preference_Id;
				objUser_Currency_Preferenc_Mapping.Currency_Id=Currency_Id;
				context.User_Currency_Preferenc_Mappings.InsertOnSubmit(objUser_Currency_Preferenc_Mapping);
				context.SubmitChanges();
				return objUser_Currency_Preferenc_Mapping.User_Currency_Preferenc_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Currency_Preferenc_Mapping_Id,int User_To_Preference_Id,int Currency_Id)
		{
			try{
				User_Currency_Preferenc_Mapping objUser_Currency_Preferenc_Mapping = (from i in context.User_Currency_Preferenc_Mappings where i.User_Currency_Preferenc_Mapping_Id == User_Currency_Preferenc_Mapping_Id select i).SingleOrDefault();
				if (objUser_Currency_Preferenc_Mapping != null)
				{
					objUser_Currency_Preferenc_Mapping.User_To_Preference_Id=User_To_Preference_Id;
					objUser_Currency_Preferenc_Mapping.Currency_Id=Currency_Id;
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
		 public User_Currency_Preferenc_Mapping selectOne(int User_Currency_Preferenc_Mapping_Id)
		{
			try
			{
				return (from i in context.User_Currency_Preferenc_Mappings where i.User_Currency_Preferenc_Mapping_Id == User_Currency_Preferenc_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Currency_Preferenc_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Currency_Preferenc_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

