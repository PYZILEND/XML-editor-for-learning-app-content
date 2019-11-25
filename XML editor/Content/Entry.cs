using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLEditor.Content
{
    public abstract class Entry
    {
        protected string text;
        protected int id;
        protected bool isOpen;

        public int GetId()
        {
            return id;
        }

        public string GetText()
        {
            return text;
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        public bool IsOpen()
        {
            return isOpen;
        }

        public void SetOpen(bool value)
        {
            isOpen = value;
        }
    }
}
