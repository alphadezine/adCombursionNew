using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_To_Shift_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_To_Shift_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_Id,int Shift_Start_Time,int Shift_End_Time,DateTime Start_Date,int Current_Status)
		{
			try{
				User_To_Shift_Mapping objUser_To_Shift_Mapping=new User_To_Shift_Mapping();
				objUser_To_Shift_Mapping.User_Id=User_Id;
				objUser_To_Shift_Mapping.Shift_Start_Time=Shift_Start_Time;
				objUser_To_Shift_Mapping.Shift_End_Time=Shift_End_Time;
				objUser_To_Shift_Mapping.Start_Date=Start_Date;
				objUser_To_Shift_Mapping.Current_Status=Current_Status;
				context.User_To_Shift_Mappings.InsertOnSubmit(objUser_To_Shift_Mapping);
				context.SubmitChanges();
				return objUser_To_Shift_Mapping.User_To_Shift_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_To_Shift_Mapping_Id,int User_Id,int Shift_Start_Time,int Shift_End_Time,DateTime Start_Date,int Current_Status)
		{
			try{
				User_To_Shift_Mapping objUser_To_Shift_Mapping = (from i in context.User_To_Shift_Mappings where i.User_To_Shift_Mapping_Id == User_To_Shift_Mapping_Id select i).SingleOrDefault();
				if (objUser_To_Shift_Mapping != null)
				{
					objUser_To_Shift_Mapping.User_Id=User_Id;
					objUser_To_Shift_Mapping.Shift_Start_Time=Shift_Start_Time;
					objUser_To_Shift_Mapping.Shift_End_Time=Shift_End_Time;
					objUser_To_Shift_Mapping.Start_Date=Start_Date;
					objUser_To_Shift_Mapping.Current_Status=Current_Status;
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
		 public User_To_Shift_Mapping selectOne(int User_To_Shift_Mapping_Id)
		{
			try
			{
				return (from i in context.User_To_Shift_Mappings where i.User_To_Shift_Mapping_Id == User_To_Shift_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_To_Shift_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_To_Shift_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
