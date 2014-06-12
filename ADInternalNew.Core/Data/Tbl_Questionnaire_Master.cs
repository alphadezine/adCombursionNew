using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Questionnaire_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Questionnaire_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(string Questionnaire_Value)
		{
			try{
				Questionnaire_Master objQuestionnaire_Master=new Questionnaire_Master();
				objQuestionnaire_Master.Questionnaire_Value=Questionnaire_Value;
				context.Questionnaire_Masters.InsertOnSubmit(objQuestionnaire_Master);
				context.SubmitChanges();
				return objQuestionnaire_Master.Questionnaire_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Questionnaire_Id,string Questionnaire_Value)
		{
			try{
				Questionnaire_Master objQuestionnaire_Master = (from i in context.Questionnaire_Masters where i.Questionnaire_Id == Questionnaire_Id select i).SingleOrDefault();
				if (objQuestionnaire_Master != null)
				{
					objQuestionnaire_Master.Questionnaire_Value=Questionnaire_Value;
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
		 public Questionnaire_Master selectOne(int Questionnaire_Id)
		{
			try
			{
				return (from i in context.Questionnaire_Masters where i.Questionnaire_Id == Questionnaire_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Questionnaire_Master> selectAll()
		{
			try
			{
				return (from i in context.Questionnaire_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

