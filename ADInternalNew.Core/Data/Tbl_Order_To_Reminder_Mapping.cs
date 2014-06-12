using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_To_Reminder_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Order_To_Reminder_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_Detail_Id,int Reminder_Id)
		{
			try{
				Order_To_Reminder_Mapping objOrder_To_Reminder_Mapping=new Order_To_Reminder_Mapping();
				objOrder_To_Reminder_Mapping.Order_Detail_Id=Order_Detail_Id;
				objOrder_To_Reminder_Mapping.Reminder_Id=Reminder_Id;
				context.Order_To_Reminder_Mappings.InsertOnSubmit(objOrder_To_Reminder_Mapping);
				context.SubmitChanges();
				return objOrder_To_Reminder_Mapping.Order_To_Reminder_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_To_Reminder_Mapping_Id,int Order_Detail_Id,int Reminder_Id)
		{
			try{
				Order_To_Reminder_Mapping objOrder_To_Reminder_Mapping = (from i in context.Order_To_Reminder_Mappings where i.Order_To_Reminder_Mapping_Id == Order_To_Reminder_Mapping_Id select i).SingleOrDefault();
				if (objOrder_To_Reminder_Mapping != null)
				{
					objOrder_To_Reminder_Mapping.Order_Detail_Id=Order_Detail_Id;
					objOrder_To_Reminder_Mapping.Reminder_Id=Reminder_Id;
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
		 public Order_To_Reminder_Mapping selectOne(int Order_To_Reminder_Mapping_Id)
		{
			try
			{
				return (from i in context.Order_To_Reminder_Mappings where i.Order_To_Reminder_Mapping_Id == Order_To_Reminder_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_To_Reminder_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Order_To_Reminder_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

