using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Status_Time_Stamp_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Status_Time_Stamp_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_Id_By,int User_Id_Of,int User_Status_Id,int Time_Stamp_Id)
		{
			try{
				User_Status_Time_Stamp_Mapping objUser_Status_Time_Stamp_Mapping=new User_Status_Time_Stamp_Mapping();
				objUser_Status_Time_Stamp_Mapping.User_Id_By=User_Id_By;
				objUser_Status_Time_Stamp_Mapping.User_Id_Of=User_Id_Of;
				objUser_Status_Time_Stamp_Mapping.User_Status_Id=User_Status_Id;
				objUser_Status_Time_Stamp_Mapping.Time_Stamp_Id=Time_Stamp_Id;
				context.User_Status_Time_Stamp_Mappings.InsertOnSubmit(objUser_Status_Time_Stamp_Mapping);
				context.SubmitChanges();
				return objUser_Status_Time_Stamp_Mapping.User_Status_Time_Stamp_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Status_Time_Stamp_Mapping_Id,int User_Id_By,int User_Id_Of,int User_Status_Id,int Time_Stamp_Id)
		{
			try{
				User_Status_Time_Stamp_Mapping objUser_Status_Time_Stamp_Mapping = (from i in context.User_Status_Time_Stamp_Mappings where i.User_Status_Time_Stamp_Mapping_Id == User_Status_Time_Stamp_Mapping_Id select i).SingleOrDefault();
				if (objUser_Status_Time_Stamp_Mapping != null)
				{
					objUser_Status_Time_Stamp_Mapping.User_Id_By=User_Id_By;
					objUser_Status_Time_Stamp_Mapping.User_Id_Of=User_Id_Of;
					objUser_Status_Time_Stamp_Mapping.User_Status_Id=User_Status_Id;
					objUser_Status_Time_Stamp_Mapping.Time_Stamp_Id=Time_Stamp_Id;
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
		 public User_Status_Time_Stamp_Mapping selectOne(int User_Status_Time_Stamp_Mapping_Id)
		{
			try
			{
				return (from i in context.User_Status_Time_Stamp_Mappings where i.User_Status_Time_Stamp_Mapping_Id == User_Status_Time_Stamp_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Status_Time_Stamp_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Status_Time_Stamp_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

