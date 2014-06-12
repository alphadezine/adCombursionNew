using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Comp_Off_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Comp_Off_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(int Login_Id,int Duration,string Reason_Of_Comp_Off)
		{
			try{
				Comp_Off_Master objComp_Off_Master=new Comp_Off_Master();
				objComp_Off_Master.Login_Id=Login_Id;
				objComp_Off_Master.Duration=Duration;
				objComp_Off_Master.Reason_Of_Comp_Off=Reason_Of_Comp_Off;
				context.Comp_Off_Masters.InsertOnSubmit(objComp_Off_Master);
				context.SubmitChanges();
				return objComp_Off_Master.Comp_Off_Master_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Comp_Off_Master_Id,int Login_Id,int Duration,string Reason_Of_Comp_Off)
		{
			try{
				Comp_Off_Master objComp_Off_Master = (from i in context.Comp_Off_Masters where i.Comp_Off_Master_Id == Comp_Off_Master_Id select i).SingleOrDefault();
				if (objComp_Off_Master != null)
				{
					objComp_Off_Master.Login_Id=Login_Id;
					objComp_Off_Master.Duration=Duration;
					objComp_Off_Master.Reason_Of_Comp_Off=Reason_Of_Comp_Off;
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
		 public Comp_Off_Master selectOne(int Comp_Off_Master_Id)
		{
			try
			{
				return (from i in context.Comp_Off_Masters where i.Comp_Off_Master_Id == Comp_Off_Master_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Comp_Off_Master> selectAll()
		{
			try
			{
				return (from i in context.Comp_Off_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

