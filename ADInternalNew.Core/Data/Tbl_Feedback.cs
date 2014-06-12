using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Feedback
	{
		AdmisInternalDataContext context;
		public Tbl_Feedback(AdmisInternalDataContext pcontext = null)
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
		public int add(string Feedback_Note,int Feedback_Rating,int Order_Detail_Id,int Feedback_For_User_Id,int Feedback_Giver_User_Id)
		{
			try{
				Feedback objFeedback=new Feedback();
				objFeedback.Feedback_Note=Feedback_Note;
				objFeedback.Feedback_Rating=Feedback_Rating;
				objFeedback.Order_Detail_Id=Order_Detail_Id;
				objFeedback.Feedback_For_User_Id=Feedback_For_User_Id;
				objFeedback.Feedback_Giver_User_Id=Feedback_Giver_User_Id;
				context.Feedbacks.InsertOnSubmit(objFeedback);
				context.SubmitChanges();
				return objFeedback.Feedback_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Feedback_Id,string Feedback_Note,int Feedback_Rating,int Order_Detail_Id,int Feedback_For_User_Id,int Feedback_Giver_User_Id)
		{
			try{
				Feedback objFeedback = (from i in context.Feedbacks where i.Feedback_Id == Feedback_Id select i).SingleOrDefault();
				if (objFeedback != null)
				{
					objFeedback.Feedback_Note=Feedback_Note;
					objFeedback.Feedback_Rating=Feedback_Rating;
					objFeedback.Order_Detail_Id=Order_Detail_Id;
					objFeedback.Feedback_For_User_Id=Feedback_For_User_Id;
					objFeedback.Feedback_Giver_User_Id=Feedback_Giver_User_Id;
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
		 public Feedback selectOne(int Feedback_Id)
		{
			try
			{
				return (from i in context.Feedbacks where i.Feedback_Id == Feedback_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Feedback> selectAll()
		{
			try
			{
				return (from i in context.Feedbacks  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

