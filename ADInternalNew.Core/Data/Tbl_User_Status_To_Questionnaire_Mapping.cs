using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Status_To_Questionnaire_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Status_To_Questionnaire_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_Status_Id,int Questionnaire_Id)
		{
			try{
				User_Status_To_Questionnaire_Mapping objUser_Status_To_Questionnaire_Mapping=new User_Status_To_Questionnaire_Mapping();
				objUser_Status_To_Questionnaire_Mapping.User_Status_Id=User_Status_Id;
				objUser_Status_To_Questionnaire_Mapping.Questionnaire_Id=Questionnaire_Id;
				context.User_Status_To_Questionnaire_Mappings.InsertOnSubmit(objUser_Status_To_Questionnaire_Mapping);
				context.SubmitChanges();
				return objUser_Status_To_Questionnaire_Mapping.User_Status_To_Questionnaire_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Status_To_Questionnaire_Mapping_Id,int User_Status_Id,int Questionnaire_Id)
		{
			try{
				User_Status_To_Questionnaire_Mapping objUser_Status_To_Questionnaire_Mapping = (from i in context.User_Status_To_Questionnaire_Mappings where i.User_Status_To_Questionnaire_Mapping_Id == User_Status_To_Questionnaire_Mapping_Id select i).SingleOrDefault();
				if (objUser_Status_To_Questionnaire_Mapping != null)
				{
					objUser_Status_To_Questionnaire_Mapping.User_Status_Id=User_Status_Id;
					objUser_Status_To_Questionnaire_Mapping.Questionnaire_Id=Questionnaire_Id;
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
		 public User_Status_To_Questionnaire_Mapping selectOne(int User_Status_To_Questionnaire_Mapping_Id)
		{
			try
			{
				return (from i in context.User_Status_To_Questionnaire_Mappings where i.User_Status_To_Questionnaire_Mapping_Id == User_Status_To_Questionnaire_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Status_To_Questionnaire_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Status_To_Questionnaire_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

