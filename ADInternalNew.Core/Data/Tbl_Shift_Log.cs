using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Shift_Log
	{
		AdmisInternalDataContext context;
		public Tbl_Shift_Log(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_To_Shift_Mapping_Id,DateTime End_Date)
		{
			try{
				Shift_Log objShift_Log=new Shift_Log();
				objShift_Log.User_To_Shift_Mapping_Id=User_To_Shift_Mapping_Id;
				objShift_Log.End_Date=End_Date;
				context.Shift_Logs.InsertOnSubmit(objShift_Log);
				context.SubmitChanges();
				return objShift_Log.Shift_Log_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Shift_Log_Id,int User_To_Shift_Mapping_Id,DateTime End_Date)
		{
			try{
				Shift_Log objShift_Log = (from i in context.Shift_Logs where i.Shift_Log_Id == Shift_Log_Id select i).SingleOrDefault();
				if (objShift_Log != null)
				{
					objShift_Log.User_To_Shift_Mapping_Id=User_To_Shift_Mapping_Id;
					objShift_Log.End_Date=End_Date;
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
		 public Shift_Log selectOne(int Shift_Log_Id)
		{
			try
			{
				return (from i in context.Shift_Logs where i.Shift_Log_Id == Shift_Log_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Shift_Log> selectAll()
		{
			try
			{
				return (from i in context.Shift_Logs  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

