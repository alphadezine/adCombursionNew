using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_To_Level_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_To_Level_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_Id,int Level_To_Skill_Id,int Skill_Rating)
		{
			try{
				User_To_Level_Mapping objUser_To_Level_Mapping=new User_To_Level_Mapping();
				objUser_To_Level_Mapping.User_Id=User_Id;
				objUser_To_Level_Mapping.Level_To_Skill_Id=Level_To_Skill_Id;
				objUser_To_Level_Mapping.Skill_Rating=Skill_Rating;
				context.User_To_Level_Mappings.InsertOnSubmit(objUser_To_Level_Mapping);
				context.SubmitChanges();
				return objUser_To_Level_Mapping.User_To_Level_Mapping_iD;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_To_Level_Mapping_iD,int User_Id,int Level_To_Skill_Id,int Skill_Rating)
		{
			try{
				User_To_Level_Mapping objUser_To_Level_Mapping = (from i in context.User_To_Level_Mappings where i.User_To_Level_Mapping_iD == User_To_Level_Mapping_iD select i).SingleOrDefault();
				if (objUser_To_Level_Mapping != null)
				{
					objUser_To_Level_Mapping.User_Id=User_Id;
					objUser_To_Level_Mapping.Level_To_Skill_Id=Level_To_Skill_Id;
					objUser_To_Level_Mapping.Skill_Rating=Skill_Rating;
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
		 public User_To_Level_Mapping selectOne(int User_To_Level_Mapping_iD)
		{
			try
			{
				return (from i in context.User_To_Level_Mappings where i.User_To_Level_Mapping_iD == User_To_Level_Mapping_iD select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_To_Level_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_To_Level_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

