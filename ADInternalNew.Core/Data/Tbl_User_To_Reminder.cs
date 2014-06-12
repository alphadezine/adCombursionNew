using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_To_Reminder
	{
		AdmisInternalDataContext context;
		public Tbl_User_To_Reminder(AdmisInternalDataContext pcontext = null)
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
		public int add(int Reminder_Id,int User_Id)
		{
			try{
				User_To_Reminder objUser_To_Reminder=new User_To_Reminder();
				objUser_To_Reminder.Reminder_Id=Reminder_Id;
				objUser_To_Reminder.User_Id=User_Id;
				context.User_To_Reminders.InsertOnSubmit(objUser_To_Reminder);
				context.SubmitChanges();
				return objUser_To_Reminder.User_Reminder_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Reminder_Id,int Reminder_Id,int User_Id)
		{
			try{
				User_To_Reminder objUser_To_Reminder = (from i in context.User_To_Reminders where i.User_Reminder_Id == User_Reminder_Id select i).SingleOrDefault();
				if (objUser_To_Reminder != null)
				{
					objUser_To_Reminder.Reminder_Id=Reminder_Id;
					objUser_To_Reminder.User_Id=User_Id;
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
		 public User_To_Reminder selectOne(int User_Reminder_Id)
		{
			try
			{
				return (from i in context.User_To_Reminders where i.User_Reminder_Id == User_Reminder_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_To_Reminder> selectAll()
		{
			try
			{
				return (from i in context.User_To_Reminders  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

