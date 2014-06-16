using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADInternalNew.DAL;
using ADInternalNew.CORE;
namespace ADInternalNew.Models
{
    public class OrderModel
    {
        AdmisInternalDataContext context;
        public OrderModel(AdmisInternalDataContext pcontext = null)
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
    }

    public class OrderSearch
    {
        public string ordername { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public List<Order_Status> listorderstatus { get; set; }
        public List<Order_Type> listordertype { get; set; }
        public List<User> listcompany { get; set; }
        public List<User> listuser { get; set; }
        public int paymentstatus { get; set; }
    }
}