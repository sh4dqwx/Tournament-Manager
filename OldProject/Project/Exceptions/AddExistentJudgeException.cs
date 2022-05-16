using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    public class AddExistentJudgeException : Exception
    {
        private string judgeName, judgeSurname, judgeCategory;

        public AddExistentJudgeException(string judgeName, string judgeSurname, string judgeCategory) : base()
        {
            this.judgeName = judgeName;
            this.judgeSurname = judgeSurname;
            this.judgeCategory = judgeCategory;
        }

        public string getJudgeName()
        {
            return judgeName;
        }
        public string getJudgeSurname()
        {
            return judgeSurname;
        }
        public string getJudgeCategory()
        {
            return judgeCategory;
        }
    }
}
