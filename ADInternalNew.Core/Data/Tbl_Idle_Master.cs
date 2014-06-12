using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Idle_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Idle_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(int Login_Id,int Duration)
		{
			try{
				Idle_Master objIdle_Master=new Idle_Master();
				objIdle_Master.Login_Id=Login_Id;
				objIdle_Master.Duration=Duration;
				context.Idle_Masters.InsertOnSubmit(objIdle_Master);
				context.SubmitChanges();
				return objIdle_Master.Idle_Master_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Idle_Master_Id,int Login_Id,int Duration)
		{
			try{
				Idle_Master objIdle_Master = (from i in context.Idle_Masters where i.Idle_Master_Id == Idle_Master_Id select i).SingleOrDefault();
				if (objIdle_Master != null)
				{
					objIdle_Master.Login_Id=Login_Id;
					objIdle_Master.Duration=Duration;
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
		 public Idle_Master selectOne(int Idle_Master_Id)
		{
			try
			{
				return (from i in context.Idle_Masters where i.Idle_Master_Id == Idle_Master_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Idle_Master> selectAll()
		{
			try
			{
				return (from i in context.Idle_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

