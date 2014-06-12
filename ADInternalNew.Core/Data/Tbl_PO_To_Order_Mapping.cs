using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_PO_To_Order_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_PO_To_Order_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int order_detail_id,string po_number)
		{
			try{
				PO_To_Order_Mapping objPO_To_Order_Mapping=new PO_To_Order_Mapping();
				objPO_To_Order_Mapping.order_detail_id=order_detail_id;
				objPO_To_Order_Mapping.po_number=po_number;
				context.PO_To_Order_Mappings.InsertOnSubmit(objPO_To_Order_Mapping);
				context.SubmitChanges();
				return objPO_To_Order_Mapping.PO_to_order_mapping_id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int PO_to_order_mapping_id,int order_detail_id,string po_number)
		{
			try{
				PO_To_Order_Mapping objPO_To_Order_Mapping = (from i in context.PO_To_Order_Mappings where i.PO_to_order_mapping_id == PO_to_order_mapping_id select i).SingleOrDefault();
				if (objPO_To_Order_Mapping != null)
				{
					objPO_To_Order_Mapping.order_detail_id=order_detail_id;
					objPO_To_Order_Mapping.po_number=po_number;
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
		 public PO_To_Order_Mapping selectOne(int PO_to_order_mapping_id)
		{
			try
			{
				return (from i in context.PO_To_Order_Mappings where i.PO_to_order_mapping_id == PO_to_order_mapping_id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<PO_To_Order_Mapping> selectAll()
		{
			try
			{
				return (from i in context.PO_To_Order_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

