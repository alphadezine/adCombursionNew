using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Reminder_Type
	{
		AdmisInternalDataContext context;
		public Tbl_Reminder_Type(AdmisInternalDataContext pcontext = null)
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
		public int add(string RType,string Reminder_Message)
		{
			try{
				Reminder_Type objReminder_Type=new Reminder_Type();
				objReminder_Type.RType=RType;
				objReminder_Type.Reminder_Message=Reminder_Message;
				context.Reminder_Types.InsertOnSubmit(objReminder_Type);
				context.SubmitChanges();
				return objReminder_Type.Reminder_Type_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Reminder_Type_Id,string RType,string Reminder_Message)
		{
			try{
				Reminder_Type objReminder_Type = (from i in context.Reminder_Types where i.Reminder_Type_Id == Reminder_Type_Id select i).SingleOrDefault();
				if (objReminder_Type != null)
				{
					objReminder_Type.RType=RType;
					objReminder_Type.Reminder_Message=Reminder_Message;
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
		 public Reminder_Type selectOne(int Reminder_Type_Id)
		{
			try
			{
				return (from i in context.Reminder_Types where i.Reminder_Type_Id == Reminder_Type_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Reminder_Type> selectAll()
		{
			try
			{
				return (from i in context.Reminder_Types  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

