using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_Status_Questionnaire_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Order_Status_Questionnaire_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_Status_Id,int Questionnaire_Id)
		{
			try{
				Order_Status_Questionnaire_Mapping objOrder_Status_Questionnaire_Mapping=new Order_Status_Questionnaire_Mapping();
				objOrder_Status_Questionnaire_Mapping.Order_Status_Id=Order_Status_Id;
				objOrder_Status_Questionnaire_Mapping.Questionnaire_Id=Questionnaire_Id;
				context.Order_Status_Questionnaire_Mappings.InsertOnSubmit(objOrder_Status_Questionnaire_Mapping);
				context.SubmitChanges();
				return objOrder_Status_Questionnaire_Mapping.Order_Status_Questionnaire_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_Status_Questionnaire_Mapping_Id,int Order_Status_Id,int Questionnaire_Id)
		{
			try{
				Order_Status_Questionnaire_Mapping objOrder_Status_Questionnaire_Mapping = (from i in context.Order_Status_Questionnaire_Mappings where i.Order_Status_Questionnaire_Mapping_Id == Order_Status_Questionnaire_Mapping_Id select i).SingleOrDefault();
				if (objOrder_Status_Questionnaire_Mapping != null)
				{
					objOrder_Status_Questionnaire_Mapping.Order_Status_Id=Order_Status_Id;
					objOrder_Status_Questionnaire_Mapping.Questionnaire_Id=Questionnaire_Id;
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
		 public Order_Status_Questionnaire_Mapping selectOne(int Order_Status_Questionnaire_Mapping_Id)
		{
			try
			{
				return (from i in context.Order_Status_Questionnaire_Mappings where i.Order_Status_Questionnaire_Mapping_Id == Order_Status_Questionnaire_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_Status_Questionnaire_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Order_Status_Questionnaire_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

