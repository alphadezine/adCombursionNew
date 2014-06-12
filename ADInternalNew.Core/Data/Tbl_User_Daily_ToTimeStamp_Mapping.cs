using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Daily_ToTimeStamp_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Daily_ToTimeStamp_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Login_Id,int Time_Stamp_Id,int Daily_Log_Status_Id)
		{
			try{
				User_Daily_ToTimeStamp_Mapping objUser_Daily_ToTimeStamp_Mapping=new User_Daily_ToTimeStamp_Mapping();
				objUser_Daily_ToTimeStamp_Mapping.Login_Id=Login_Id;
				objUser_Daily_ToTimeStamp_Mapping.Time_Stamp_Id=Time_Stamp_Id;
				objUser_Daily_ToTimeStamp_Mapping.Daily_Log_Status_Id=Daily_Log_Status_Id;
				context.User_Daily_ToTimeStamp_Mappings.InsertOnSubmit(objUser_Daily_ToTimeStamp_Mapping);
				context.SubmitChanges();
				return objUser_Daily_ToTimeStamp_Mapping.User_Daily_ToTimeStamp_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Daily_ToTimeStamp_Mapping_Id,int Login_Id,int Time_Stamp_Id,int Daily_Log_Status_Id)
		{
			try{
				User_Daily_ToTimeStamp_Mapping objUser_Daily_ToTimeStamp_Mapping = (from i in context.User_Daily_ToTimeStamp_Mappings where i.User_Daily_ToTimeStamp_Mapping_Id == User_Daily_ToTimeStamp_Mapping_Id select i).SingleOrDefault();
				if (objUser_Daily_ToTimeStamp_Mapping != null)
				{
					objUser_Daily_ToTimeStamp_Mapping.Login_Id=Login_Id;
					objUser_Daily_ToTimeStamp_Mapping.Time_Stamp_Id=Time_Stamp_Id;
					objUser_Daily_ToTimeStamp_Mapping.Daily_Log_Status_Id=Daily_Log_Status_Id;
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
		 public User_Daily_ToTimeStamp_Mapping selectOne(int User_Daily_ToTimeStamp_Mapping_Id)
		{
			try
			{
				return (from i in context.User_Daily_ToTimeStamp_Mappings where i.User_Daily_ToTimeStamp_Mapping_Id == User_Daily_ToTimeStamp_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Daily_ToTimeStamp_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Daily_ToTimeStamp_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

