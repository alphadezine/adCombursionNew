using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Daily_Log_Status
	{
		AdmisInternalDataContext context;
		public Tbl_Daily_Log_Status(AdmisInternalDataContext pcontext = null)
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
		public int add(string Daily_Log_Status_Name)
		{
			try{
				Daily_Log_Status objDaily_Log_Status=new Daily_Log_Status();
				objDaily_Log_Status.Daily_Log_Status_Name=Daily_Log_Status_Name;
				context.Daily_Log_Status.InsertOnSubmit(objDaily_Log_Status);
				context.SubmitChanges();
				return objDaily_Log_Status.Daily_Log_Status_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Daily_Log_Status_Id,string Daily_Log_Status_Name)
		{
			try{
				Daily_Log_Status objDaily_Log_Status = (from i in context.Daily_Log_Status where i.Daily_Log_Status_Id == Daily_Log_Status_Id select i).SingleOrDefault();
				if (objDaily_Log_Status != null)
				{
					objDaily_Log_Status.Daily_Log_Status_Name=Daily_Log_Status_Name;
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
		 public Daily_Log_Status selectOne(int Daily_Log_Status_Id)
		{
			try
			{
				return (from i in context.Daily_Log_Status where i.Daily_Log_Status_Id == Daily_Log_Status_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Daily_Log_Status> selectAll()
		{
			try
			{
				return (from i in context.Daily_Log_Status  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

