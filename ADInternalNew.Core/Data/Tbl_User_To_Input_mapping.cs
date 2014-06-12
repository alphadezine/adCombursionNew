using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_To_Input_mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_To_Input_mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int questionnaire_id,int user_id,int timestamp_id)
		{
			try{
				User_To_Input_mapping objUser_To_Input_mapping=new User_To_Input_mapping();
				objUser_To_Input_mapping.questionnaire_id=questionnaire_id;
				objUser_To_Input_mapping.user_id=user_id;
				objUser_To_Input_mapping.timestamp_id=timestamp_id;
				context.User_To_Input_mappings.InsertOnSubmit(objUser_To_Input_mapping);
				context.SubmitChanges();
				return objUser_To_Input_mapping.user_to_input_mapping_id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int user_to_input_mapping_id,int questionnaire_id,int user_id,int timestamp_id)
		{
			try{
				User_To_Input_mapping objUser_To_Input_mapping = (from i in context.User_To_Input_mappings where i.user_to_input_mapping_id == user_to_input_mapping_id select i).SingleOrDefault();
				if (objUser_To_Input_mapping != null)
				{
					objUser_To_Input_mapping.questionnaire_id=questionnaire_id;
					objUser_To_Input_mapping.user_id=user_id;
					objUser_To_Input_mapping.timestamp_id=timestamp_id;
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
		 public User_To_Input_mapping selectOne(int user_to_input_mapping_id)
		{
			try
			{
				return (from i in context.User_To_Input_mappings where i.user_to_input_mapping_id == user_to_input_mapping_id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_To_Input_mapping> selectAll()
		{
			try
			{
				return (from i in context.User_To_Input_mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

