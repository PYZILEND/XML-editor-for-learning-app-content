using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Content
{
    public class Challenge : Entry
    {
        public enum Type { question, options, gaps, order};

        private Type challengeType;
        private List<string> answers;

        public Challenge(int id, string text, Type type, List<string> answers)
        {
            this.id = id;
            this.text = text;
            this.challengeType = type;
            this.answers = answers;
        }


        public void SetChallengeType(Type type)
        {
            this.challengeType = type;
        }

        public Type GetChallengeType()
        {
            return challengeType;
        }

        public List<string> GetAnswers()
        {
            return answers;
        }

        public void SetAnswers(List<string> answers)
        {
            this.answers = answers;
        }
    }
}
