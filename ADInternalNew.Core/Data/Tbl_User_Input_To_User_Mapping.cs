using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Input_To_User_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Input_To_User_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int user_to_input_mapping_id,int User_Id)
		{
			try{
				User_Input_To_User_Mapping objUser_Input_To_User_Mapping=new User_Input_To_User_Mapping();
				objUser_Input_To_User_Mapping.user_to_input_mapping_id=user_to_input_mapping_id;
				objUser_Input_To_User_Mapping.User_Id=User_Id;
				context.User_Input_To_User_Mappings.InsertOnSubmit(objUser_Input_To_User_Mapping);
				context.SubmitChanges();
				return objUser_Input_To_User_Mapping.User_Input_To_User_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Input_To_User_Mapping_Id,int user_to_input_mapping_id,int User_Id)
		{
			try{
				User_Input_To_User_Mapping objUser_Input_To_User_Mapping = (from i in context.User_Input_To_User_Mappings where i.User_Input_To_User_Mapping_Id == User_Input_To_User_Mapping_Id select i).SingleOrDefault();
				if (objUser_Input_To_User_Mapping != null)
				{
					objUser_Input_To_User_Mapping.user_to_input_mapping_id=user_to_input_mapping_id;
					objUser_Input_To_User_Mapping.User_Id=User_Id;
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
		 public User_Input_To_User_Mapping selectOne(int User_Input_To_User_Mapping_Id)
		{
			try
			{
				return (from i in context.User_Input_To_User_Mappings where i.User_Input_To_User_Mapping_Id == User_Input_To_User_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Input_To_User_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Input_To_User_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

