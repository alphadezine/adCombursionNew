using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Shift
	{
		AdmisInternalDataContext context;
		public Tbl_Shift(AdmisInternalDataContext pcontext = null)
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
		public int add(int Shift_Time_Hr,int Shift_Time_Min)
		{
			try{
				Shift objShift=new Shift();
				objShift.Shift_Time_Hr=Shift_Time_Hr;
				objShift.Shift_Time_Min=Shift_Time_Min;
				context.Shifts.InsertOnSubmit(objShift);
				context.SubmitChanges();
				return objShift.Shift_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Shift_Id,int Shift_Time_Hr,int Shift_Time_Min)
		{
			try{
				Shift objShift = (from i in context.Shifts where i.Shift_Id == Shift_Id select i).SingleOrDefault();
				if (objShift != null)
				{
					objShift.Shift_Time_Hr=Shift_Time_Hr;
					objShift.Shift_Time_Min=Shift_Time_Min;
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
		 public Shift selectOne(int Shift_Id)
		{
			try
			{
				return (from i in context.Shifts where i.Shift_Id == Shift_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Shift> selectAll()
		{
			try
			{
				return (from i in context.Shifts  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

