using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Billing_Cycle
	{
		AdmisInternalDataContext context;
		public Tbl_Billing_Cycle(AdmisInternalDataContext pcontext = null)
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
		public int add(int Billing_Cycle_Type)
		{
			try{
				Billing_Cycle objBilling_Cycle=new Billing_Cycle();
				objBilling_Cycle.Billing_Cycle_Type=Billing_Cycle_Type;
				context.Billing_Cycles.InsertOnSubmit(objBilling_Cycle);
				context.SubmitChanges();
				return objBilling_Cycle.Billing_Cycle_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Billing_Cycle_Id,int Billing_Cycle_Type)
		{
			try{
				Billing_Cycle objBilling_Cycle = (from i in context.Billing_Cycles where i.Billing_Cycle_Id == Billing_Cycle_Id select i).SingleOrDefault();
				if (objBilling_Cycle != null)
				{
					objBilling_Cycle.Billing_Cycle_Type=Billing_Cycle_Type;
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
		 public Billing_Cycle selectOne(int Billing_Cycle_Id)
		{
			try
			{
				return (from i in context.Billing_Cycles where i.Billing_Cycle_Id == Billing_Cycle_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Billing_Cycle> selectAll()
		{
			try
			{
				return (from i in context.Billing_Cycles  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

