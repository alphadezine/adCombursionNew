using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_State
	{
		AdmisInternalDataContext context;
		public Tbl_State(AdmisInternalDataContext pcontext = null)
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
		public int add(string State_Name)
		{
			try{
				State objState=new State();
				objState.State_Name=State_Name;
				context.States.InsertOnSubmit(objState);
				context.SubmitChanges();
				return objState.State_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int State_Id,string State_Name)
		{
			try{
				State objState = (from i in context.States where i.State_Id == State_Id select i).SingleOrDefault();
				if (objState != null)
				{
					objState.State_Name=State_Name;
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
		 public State selectOne(int State_Id)
		{
			try
			{
				return (from i in context.States where i.State_Id == State_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<State> selectAll()
		{
			try
			{
				return (from i in context.States  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

