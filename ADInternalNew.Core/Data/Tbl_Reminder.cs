using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Reminder
	{
		AdmisInternalDataContext context;
		public Tbl_Reminder(AdmisInternalDataContext pcontext = null)
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
		public int add(int Time_Stamp_Id,int Reminder_Type_Id)
		{
			try{
				Reminder objReminder=new Reminder();
				objReminder.Time_Stamp_Id=Time_Stamp_Id;
				objReminder.Reminder_Type_Id=Reminder_Type_Id;
				context.Reminders.InsertOnSubmit(objReminder);
				context.SubmitChanges();
				return objReminder.Reminder_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Reminder_Id,int Time_Stamp_Id,int Reminder_Type_Id)
		{
			try{
				Reminder objReminder = (from i in context.Reminders where i.Reminder_Id == Reminder_Id select i).SingleOrDefault();
				if (objReminder != null)
				{
					objReminder.Time_Stamp_Id=Time_Stamp_Id;
					objReminder.Reminder_Type_Id=Reminder_Type_Id;
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
		 public Reminder selectOne(int Reminder_Id)
		{
			try
			{
				return (from i in context.Reminders where i.Reminder_Id == Reminder_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Reminder> selectAll()
		{
			try
			{
				return (from i in context.Reminders  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

