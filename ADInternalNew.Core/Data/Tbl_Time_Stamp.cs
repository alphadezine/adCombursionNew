using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Time_Stamp
	{
		AdmisInternalDataContext context;
		public Tbl_Time_Stamp(AdmisInternalDataContext pcontext = null)
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
		public int add(DateTime Time_Stamp_Value)
		{
			try{
				Time_Stamp objTime_Stamp=new Time_Stamp();
				objTime_Stamp.Time_Stamp_Value=Time_Stamp_Value;
				context.Time_Stamps.InsertOnSubmit(objTime_Stamp);
				context.SubmitChanges();
				return objTime_Stamp.Time_Stamp_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Time_Stamp_Id,DateTime Time_Stamp_Value)
		{
			try{
				Time_Stamp objTime_Stamp = (from i in context.Time_Stamps where i.Time_Stamp_Id == Time_Stamp_Id select i).SingleOrDefault();
				if (objTime_Stamp != null)
				{
					objTime_Stamp.Time_Stamp_Value=Time_Stamp_Value;
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
		 public Time_Stamp selectOne(int Time_Stamp_Id)
		{
			try
			{
				return (from i in context.Time_Stamps where i.Time_Stamp_Id == Time_Stamp_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Time_Stamp> selectAll()
		{
			try
			{
				return (from i in context.Time_Stamps  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

