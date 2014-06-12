using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_Detail
	{
		AdmisInternalDataContext context;
		public Tbl_Order_Detail(AdmisInternalDataContext pcontext = null)
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
		public int add(string Order_Name,int Client_User_Id,int Order_Type_Id,string Priority,bool Order_Budget,int PO_Number_Needed,int IsNewOrder,int IsRevised,int Order_Status_Id,bool IsDiscountApplied)
		{
			try{
				Order_Detail objOrder_Detail=new Order_Detail();
				objOrder_Detail.Order_Name=Order_Name;
				objOrder_Detail.Client_User_Id=Client_User_Id;
				objOrder_Detail.Order_Type_Id=Order_Type_Id;
				objOrder_Detail.Priority=Priority;
				objOrder_Detail.Order_Budget=Order_Budget;
				objOrder_Detail.PO_Number_Needed=PO_Number_Needed;
				objOrder_Detail.IsNewOrder=IsNewOrder;
				objOrder_Detail.IsRevised=IsRevised;
				objOrder_Detail.Order_Status_Id=Order_Status_Id;
				objOrder_Detail.IsDiscountApplied=IsDiscountApplied;
				context.Order_Details.InsertOnSubmit(objOrder_Detail);
				context.SubmitChanges();
				return objOrder_Detail.Order_Detail_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_Detail_Id,string Order_Name,int Client_User_Id,int Order_Type_Id,string Priority,bool Order_Budget,int PO_Number_Needed,int IsNewOrder,int IsRevised,int Order_Status_Id,bool IsDiscountApplied)
		{
			try{
				Order_Detail objOrder_Detail = (from i in context.Order_Details where i.Order_Detail_Id == Order_Detail_Id select i).SingleOrDefault();
				if (objOrder_Detail != null)
				{
					objOrder_Detail.Order_Name=Order_Name;
					objOrder_Detail.Client_User_Id=Client_User_Id;
					objOrder_Detail.Order_Type_Id=Order_Type_Id;
					objOrder_Detail.Priority=Priority;
					objOrder_Detail.Order_Budget=Order_Budget;
					objOrder_Detail.PO_Number_Needed=PO_Number_Needed;
					objOrder_Detail.IsNewOrder=IsNewOrder;
					objOrder_Detail.IsRevised=IsRevised;
					objOrder_Detail.Order_Status_Id=Order_Status_Id;
					objOrder_Detail.IsDiscountApplied=IsDiscountApplied;
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
		 public Order_Detail selectOne(int Order_Detail_Id)
		{
			try
			{
				return (from i in context.Order_Details where i.Order_Detail_Id == Order_Detail_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_Detail> selectAll()
		{
			try
			{
				return (from i in context.Order_Details  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

